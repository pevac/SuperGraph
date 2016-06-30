using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupperGraph.Models
{
    public class Edge
    {
        public Edge(Node leftNode, Node rightNode)
        {
            ++Count;
            LeftNode = leftNode;
            RightNode = rightNode;
            EdgeId = Count;
        }

        public  int EdgeId { get; }
        public static int Count { get;  set; }
        public Node LeftNode { get; }
        public Node RightNode { get; }
        public bool IsDirect { get; }
    }
}
