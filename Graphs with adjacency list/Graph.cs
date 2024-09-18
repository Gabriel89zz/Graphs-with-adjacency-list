using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_with_adjacency_list
{
    internal class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
        public bool Weighted
        {
            get
            {
                // Verifica si alguna arista tiene un peso diferente de 0
                return Nodes.Any(node => node.Edges.Any(edge => edge.Weight != 0));
            }
        }
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
            //adjMatrix = new int[0, 0];
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }
            
        public void AddEdge(Node fromNode, Node toNode, int weight = 0, bool isDirected = true)
        {
          
            if (fromNode != null && toNode != null && Nodes.Contains(fromNode) && Nodes.Contains(toNode))
            {
                // Agregar la arista del nodo 'fromNode' al nodo 'toNode'
                Edge edge = new Edge(fromNode, toNode, weight);
                fromNode.AddEdge(toNode, weight);
                Edges.Add(edge);

                // Si el grafo no es dirigido, agregar también la arista en el sentido contrario
                if (!isDirected)
                {
                    Edge reverseEdge = new Edge(toNode, fromNode, weight);
                    toNode.AddEdge(fromNode, weight);
                    Edges.Add(reverseEdge);
                }
            }
        }

        public void RemoveEdge(Node fromNode, Node toNode, bool isDirected = true)
        {
            if (fromNode != null && toNode != null)
            {
                // Remover la arista de la lista de aristas del grafo
                Edges.RemoveAll(e => e.From == fromNode && e.To == toNode);

                // Remover la arista de la lista de aristas del nodo 'from'
                fromNode.Edges.RemoveAll(e => e.To == toNode);

                // Si el grafo no es dirigido, eliminar también la arista en sentido contrario
                if (!isDirected)
                {
                    // Remover la arista inversa (de 'toNode' a 'fromNode')
                    Edges.RemoveAll(e => e.From == toNode && e.To == fromNode);

                    // Remover la arista de la lista de aristas del nodo 'to'
                    toNode.Edges.RemoveAll(e => e.To == fromNode);
                }
            }
        }

        public void RemoveNode(Node nodeToRemove)
        {
            if (nodeToRemove != null)
            {
                // Eliminar todas las aristas asociadas al nodo
                // Remover todas las aristas donde el nodo es el origen
                Edges.RemoveAll(e => e.From == nodeToRemove);
                // Remover todas las aristas donde el nodo es el destino
                Edges.RemoveAll(e => e.To == nodeToRemove);

                // Asegúrate de eliminar las aristas en la lista de aristas de cada nodo
                foreach (var node in Nodes)
                {
                    node.Edges.RemoveAll(e => e.To == nodeToRemove || e.From == nodeToRemove);
                }

                // Remover el nodo de la lista de nodos
                Nodes.Remove(nodeToRemove);
            }
        }

        public Dictionary<string, List<string>> GetAdjacencyList()
        {
            var adjacencyList = new Dictionary<string, List<string>>();

            foreach (var node in Nodes)
            {
                var adjacentNodes = node.Edges.Select(e => e.To.Name).ToList();
                adjacencyList[node.Name] = adjacentNodes;
            }

            return adjacencyList;
        }

        public Dictionary<string, List<(string toNode, int weight)>> GetAdjacencyListWithWeights()
        {
            var adjacencyList = new Dictionary<string, List<(string toNode, int weight)>>();

            foreach (var node in Nodes)
            {
                var adjacentNodes = node.Edges.Select(e => (e.To.Name, e.Weight)).ToList();
                adjacencyList[node.Name] = adjacentNodes;
            }

            return adjacencyList;
        }


        //no se para que sirve
        public List<string> GetEdges()
        {
            return Edges.Select(e => e.ToString()).ToList();
        }

        public string DFS(Node startNode)
        {
            if (startNode == null || !Nodes.Contains(startNode)) return string.Empty;

            List<Node> visited = new List<Node>();  // Lista de nodos visitados
            StringBuilder result = new StringBuilder();  // Para acumular el resultado

            DFSRecursive(startNode, visited, result);

            return result.ToString();
        }

        private void DFSRecursive(Node currentNode, List<Node> visited, StringBuilder result)
        {
            // Marcar el nodo como visitado
            visited.Add(currentNode);

            // Agregar el nodo actual al resultado
            if (result.Length > 0)
            {
                result.Append(" → ");  // Añadir flecha entre nodos
            }
            result.Append(currentNode.Name);

            // Recorrer los nodos adyacentes
            foreach (Edge edge in currentNode.Edges)
            {
                Node adjacentNode = edge.To;
                if (!visited.Contains(adjacentNode))
                {
                    DFSRecursive(adjacentNode, visited, result);  // Llamada recursiva
                }
            }
        }

        public string BFS(Node startNode)
        {
            if (startNode == null || !Nodes.Contains(startNode)) return string.Empty;

            List<Node> visited = new List<Node>();  // Lista de nodos visitados
            Queue<Node> queue = new Queue<Node>();  // Cola para el recorrido
            StringBuilder result = new StringBuilder();  // Para acumular el resultado

            queue.Enqueue(startNode);  // Agregar el nodo de inicio a la cola

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();  // Obtener el nodo al frente de la cola

                if (!visited.Contains(currentNode))
                {
                    // Agregar el nodo actual al resultado
                    if (result.Length > 0)
                    {
                        result.Append(" → ");  // Añadir flecha entre nodos
                    }
                    result.Append(currentNode.Name);

                    visited.Add(currentNode);  // Marcar el nodo como visitado

                    // Encolar los nodos adyacentes no visitados
                    foreach (Edge edge in currentNode.Edges)
                    {
                        Node adjacentNode = edge.To;
                        if (!visited.Contains(adjacentNode) && !queue.Contains(adjacentNode))
                        {
                            queue.Enqueue(adjacentNode);  // Agregar a la cola si no ha sido visitado
                        }
                    }
                }
            }

            return result.ToString();  // Devolver el resultado en formato "1 → 2 → 3"
        }
    }
}
