using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace SupperGraph.Controls
{
    /// <summary>
    /// Class that implements a workaround for a Silverlight XAML parser
    /// limitation that prevents the following syntax from working:
    ///    &lt;Setter PropertyForBinding="IsSelected" Value="{Binding IsSelected}"/&gt;
    /// </summary>
    [ContentProperty(Name = "Values")]
    public class SetterValueBindingHelper
    {
        private Collection<SetterValueBindingHelper> _values;

        /// <summary>
        /// Type where property for binding located.
        /// Type parameter used to specify the type of an attached
        /// DependencyProperty as an assembly-qualified name, full name, or
        /// short name.
        /// </summary>
        public string TypeForBinding
        {
            get; set;
        }

        /// <summary>
        /// PropertyForBinding name for the normal/attached DependencyProperty on which
        /// to set the Binding.
        /// </summary>
        public string PropertyForBinding { get; set; }

        /// <summary>
        /// Binding to set on the specified property.
        /// </summary>
        public Binding Binding { get; set; }

        /// <summary>
        /// Collection of SetterValueBindingHelper instances to apply to the
        /// target element.
        /// </summary>
        /// <remarks>
        /// Used when multiple Bindings need to be applied to the same element.
        /// </remarks>
        public Collection<SetterValueBindingHelper> Values => _values ?? (_values = new Collection<SetterValueBindingHelper>());

        /// <summary>
        /// Gets the value of the PropertyBinding attached DependencyProperty.
        /// </summary>
        /// <param name="element">Element for which to get the property.</param>
        /// <returns>Value of PropertyBinding attached DependencyProperty.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "SetBinding is only available on FrameworkElement.")]
        public static SetterValueBindingHelper GetPropertyBinding(FrameworkElement element)
        {
            if (null == element)
            {
                throw new ArgumentNullException(nameof(element));
            }
            return (SetterValueBindingHelper)element.GetValue(PropertyBindingProperty);
        }

        /// <summary>
        /// Sets the value of the PropertyBinding attached DependencyProperty.
        /// </summary>
        /// <param name="element">Element on which to set the property.</param>
        /// <param name="value">Value forPropertyBinding attached DependencyProperty.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "SetBinding is only available on FrameworkElement.")]
        public static void SetPropertyBinding(FrameworkElement element, SetterValueBindingHelper value)
        {
            if (null == element)
            {
                throw new ArgumentNullException(nameof(element));
            }
            element.SetValue(PropertyBindingProperty, value);
        }

        /// <summary>
        /// PropertyBinding attached DependencyProperty.
        /// </summary>
        public static readonly DependencyProperty PropertyBindingProperty =
            DependencyProperty.RegisterAttached(
                "PropertyBinding",
                typeof(SetterValueBindingHelper),
                typeof(SetterValueBindingHelper),
                new PropertyMetadata(null, OnPropertyBindingPropertyChanged));

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the value of the PropertyBinding attached DependencyProperty.
        /// </summary>
        /// <param name="element">Element for which to get the property.</param>
        /// <returns>Value of PropertyBinding attached DependencyProperty.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "SetBinding is only available on FrameworkElement.")]
        public static SetterValueBindingHelper GetPropertyBinding2(FrameworkElement element)
        {
            if (null == element)
            {
                throw new ArgumentNullException(nameof(element));
            }
            return (SetterValueBindingHelper)element.GetValue(PropertyBindingProperty2);
        }

        /// <summary>
        /// Sets the value of the PropertyBinding attached DependencyProperty.
        /// </summary>
        /// <param name="element">Element on which to set the property.</param>
        /// <param name="value">Value forPropertyBinding attached DependencyProperty.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "SetBinding is only available on FrameworkElement.")]
        public static void SetPropertyBinding2(FrameworkElement element, SetterValueBindingHelper value)
        {
            if (null == element)
            {
                throw new ArgumentNullException(nameof(element));
            }
            element.SetValue(PropertyBindingProperty2, value);
        }

        /// <summary>
        /// PropertyBinding attached DependencyProperty.
        /// </summary>
        public static readonly DependencyProperty PropertyBindingProperty2 =
            DependencyProperty.RegisterAttached(
                "PropertyBinding2",
                typeof(SetterValueBindingHelper),
                typeof(SetterValueBindingHelper),
                new PropertyMetadata(null, OnPropertyBindingPropertyChanged));

        /// <summary>
        /// Change handler for the PropertyBinding attached DependencyProperty.
        /// </summary>
        /// <param name="d">Object on which the property was changed.</param>
        /// <param name="e">PropertyForBinding change arguments.</param>
        private static void OnPropertyBindingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Get/validate parameters
            var element = (FrameworkElement)d;
            var item = (SetterValueBindingHelper)(e.NewValue);

            if ((null == item.Values) || (0 == item.Values.Count))
            {
                // No children; apply the relevant binding
                ApplyBinding(element, item);
            }
            else
            {
                // Apply the bindings of each child
                foreach (var child in item.Values)
                {
                    if ((null != item.PropertyForBinding) || (null != item.Binding))
                    {
                        throw new ArgumentException(
                            "A SetterValueBindingHelper with Values may not have its PropertyForBinding or Binding set.");
                    }
                    if (0 != child.Values.Count)
                    {
                        throw new ArgumentException(
                            "Values of a SetterValueBindingHelper may not have Values themselves.");
                    }
                    ApplyBinding(element, child);
                }
            }
        }

        /// <summary>
        /// Applies the Binding represented by the SetterValueBindingHelper.
        /// </summary>
        /// <param name="element">Element to apply the Binding to.</param>
        /// <param name="item">SetterValueBindingHelper representing the Binding.</param>
        private static void ApplyBinding(FrameworkElement element, SetterValueBindingHelper item)
        {
            if ((null == item.PropertyForBinding) || (null == item.Binding))
            {
                throw new ArgumentException(
                    "SetterValueBindingHelper's PropertyForBinding and Binding must both be set to non-null values.");
            }

            // Get the type on which to set the Binding
            TypeInfo typeForBinding = null;
            if (String.IsNullOrWhiteSpace(item.TypeForBinding))
            {
                // No type specified; setting for the specified element
                typeForBinding = element.GetType()?.GetTypeInfo();
            }
            else
            {
                // Try to get the type from the type system
                typeForBinding = System.Type.GetType(item.TypeForBinding)?.GetTypeInfo();
                if (null == typeForBinding)
                {
                    // Search for the type in the list of assemblies
                    foreach (var assembly in DefaultAssembliesToSearch)
                    {
                        typeForBinding = assembly.DefinedTypes
                            .FirstOrDefault(t => (t.FullName == item.TypeForBinding) || (t.Name == item.TypeForBinding));
                        if (typeForBinding != null) { break; }
                    }
                    if (typeForBinding == null)
                    {
                        // Unable to find the requested type anywhere
                        throw new ArgumentException(String.Format(CultureInfo.CurrentCulture,
                            "Unable to access type \"{0}\". Try using an assembly qualified type name.",
                            item.TypeForBinding));
                    }
                }
            }

            // Get the DependencyProperty for which to set the Binding
            var field = typeForBinding?.DeclaredProperties.FirstOrDefault(i => i.Name == item.PropertyForBinding + "Property");
            // BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);

            var property = field?.GetValue(null) as DependencyProperty;
            if (property == null)
            {
                // Unable to find the requsted property
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    "Unable to access DependencyProperty \"{0}\" on type \"{1}\".",
                    item.PropertyForBinding, typeForBinding.Name));
            }

            // Set the specified Binding on the specified property
            element.SetBinding(property, item.Binding);
        }

        /// <summary>
        /// Returns a stream of assemblies to search for the provided type name.
        /// </summary>
        private static IEnumerable<Assembly> DefaultAssembliesToSearch => new[] { typeof(Control).GetTypeInfo().Assembly };

    }
}
