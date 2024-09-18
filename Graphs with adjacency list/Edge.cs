using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_with_adjacency_list
{
    internal class Edge
    {
        public Node From { get; set; }
        public Node To { get; set; }
        public int Weight { get; set; }

        public Edge(Node from, Node to, int weight = 0)
        {
            From = from;
            To = to;
            Weight = weight;
        }
        
        public override string ToString()
        {
            return From.Name + " -> " + To.Name + " (Peso: " + Weight + ")";
        }
    }
}
