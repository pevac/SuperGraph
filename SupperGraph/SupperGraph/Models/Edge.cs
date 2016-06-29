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
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public Node LeftNode { get; }
        public Node RightNode { get; }
    }
}
