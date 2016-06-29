using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SupperGraph.Models;

namespace SupperGraph.Controls
{
    public class GraphPartsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NodeDataTemplate { get; set; }
        public DataTemplate EdgeDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {

            DataTemplate template;
            if (item is Node)
            {
                template = this.NodeDataTemplate;
            }
            else if (item is Edge)
            {
                template = this.EdgeDataTemplate;
            }
            else
            {
                throw new ArgumentException("Wrong item type!", nameof(item));
            }
            return template;
        }
    }
}
