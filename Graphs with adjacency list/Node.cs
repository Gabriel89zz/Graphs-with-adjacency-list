using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Graphs_with_adjacency_list
{
    internal class Node
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }

        public Node(string name)
        {
            Name = name;
            Edges = new List<Edge>();
        }

        public void AddEdge(Node to, int weight = 0)
        {
            Edge edge = new Edge(this, to, weight);
            Edges.Add(edge);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
