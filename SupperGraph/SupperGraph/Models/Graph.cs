using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToolkit.Collections;

namespace SupperGraph.Models
{
    public class Graph
    {
        private const string NoSuchNodeErrorString = "No such node!";

        public Graph() : this(null) { }
        public Graph(MtObservableCollection<Node> nodes)
        {
            Nodes = nodes ?? new MtObservableCollection<Node>();
        }

        public MtObservableCollection<Node> Nodes { get; set; }

        public void AddNode(Node nodes)
        {
            Nodes.Add(nodes);
        }

        public Node FindByValue(int id)
        {
            return Nodes.First(node => node.NodeId == id);
        }

        public void AddUndirectedEdge(int fromNodeValue, int toNodeValue)
        {
            AdDirectedEdge(fromNodeValue, toNodeValue);
            AdDirectedEdge(toNodeValue, fromNodeValue);
        }

        public void AdDirectedEdge(int fromNodeValue, int toNodeValue)
        {
            #region Parameters Validation
            if (!this.ContainsNode(fromNodeValue))
            {
                throw new ArgumentException(NoSuchNodeErrorString, nameof(fromNodeValue));
            }

            if (!this.ContainsNode(toNodeValue))
            {
                throw new ArgumentException(NoSuchNodeErrorString, nameof(toNodeValue));
            }
            #endregion
            FindByValue(fromNodeValue).Neighbors.Add(FindByValue(toNodeValue));
        }

        public bool RemoveNode(int id)
        {
            var nodeToRemove = FindByValue(id);
            if (nodeToRemove == null)
            {
                return false;
            }
            Nodes.Remove(nodeToRemove);

            foreach (var node in Nodes)
            {
                var gnode = node;
                var index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    gnode.Neighbors.RemoveAt(index);
                }
            }

            return true;
        }

        public void DeleteGraph()
        {
            Nodes.Clear();
            Edges.Clear();
            Node.Count = 0;
        }

        public bool ContainsNode(int nodeValue)
        {
            return FindByValue(nodeValue) != null;
        }
        public MtObservableCollection<Edge> Edges
        {
            get
            {
                var edges = new MtObservableCollection<Edge>();
                foreach (var vertex in Nodes)
                {
                    foreach (var node in vertex.Neighbors)
                    {
                        edges.Add(new Edge(vertex, node));
                    }
                }
                return edges;
            }
        }
    }
}
