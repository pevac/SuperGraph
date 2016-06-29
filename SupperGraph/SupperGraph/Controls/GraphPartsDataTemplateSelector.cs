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
        public DataTemplate LoopDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {

            DataTemplate template;
            if (item is Node)
            {
                template = this.NodeDataTemplate;
            }
            else if (item is Edge)
            {
                var edge = (Edge) item;
                template = edge.LeftNode.NodeId == edge.RightNode.NodeId ? LoopDataTemplate : this.EdgeDataTemplate;
            }
            else
            {
                throw new ArgumentException("Wrong item type!", nameof(item));
            }
            return template;
        }
    }
}
