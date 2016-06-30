using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using MyToolkit.Collections;

namespace SupperGraph.Models
{
    public class Node
    {
        public Node() { }

        public Node(Node node)
        {
            this.X = node.X;
            this.Y = node.Y;
            NodeId = node.NodeId;
        }


        public Node(Point point)
        {
            ++Count;
            this.X = point.X;
            this.Y = point.Y;
            NodeId = Count;
            this.Name = Count.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public int NodeId { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public static int Count { get;  set; }

        public MtObservableCollection<Node> Neighbors { get; set; } = new MtObservableCollection<Node>();
    }
}
