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
        public bool IsWeighted
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
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void AddEdge(Node fromNode, Node toNode, bool isDirected = true)
        {
            if (fromNode != null && toNode != null && Nodes.Contains(fromNode) && Nodes.Contains(toNode))
            {
                // Verificar si la arista ya existe
                bool edgeExists = fromNode.Edges.Any(e => e.To == toNode);
                if (edgeExists)
                {
                    // La arista ya existe, no se hace nada
                    return;
                }

                // Agregar la arista del nodo 'fromNode' al nodo 'toNode'
                Edge edge = new Edge(fromNode, toNode);
                fromNode.AddEdge(toNode);
                Edges.Add(edge);

                // Si el grafo no es dirigido, agregar también la arista en el sentido contrario
                if (!isDirected)
                {
                    // Verificar si la arista inversa ya existe
                    bool reverseEdgeExists = toNode.Edges.Any(e => e.To == fromNode);
                    if (!reverseEdgeExists)
                    {
                        Edge reverseEdge = new Edge(toNode, fromNode);
                        toNode.AddEdge(fromNode);
                        Edges.Add(reverseEdge);
                    }
                }
            }
        }

        public void AddWeightedEdge(Node fromNode, Node toNode, int weight, bool isDirected = true)
        {
            if (fromNode != null && toNode != null && Nodes.Contains(fromNode) && Nodes.Contains(toNode))
            {
                // Verificar si la arista ya existe con el mismo peso
                bool edgeExists = fromNode.Edges.Any(e => e.To == toNode && e.Weight == weight);
                if (edgeExists)
                {
                    // La arista ya existe, no se hace nada
                    return;
                }

                // Agregar la arista del nodo 'fromNode' al nodo 'toNode' con el peso dado
                Edge edge = new Edge(fromNode, toNode, weight);
                fromNode.AddEdge(toNode, weight);
                Edges.Add(edge);

                // Si el grafo no es dirigido, agregar también la arista en el sentido contrario
                if (!isDirected)
                {
                    // Verificar si la arista inversa ya existe con el mismo peso
                    bool reverseEdgeExists = toNode.Edges.Any(e => e.To == fromNode && e.Weight == weight);
                    if (!reverseEdgeExists)
                    {
                        Edge reverseEdge = new Edge(toNode, fromNode, weight);
                        toNode.AddEdge(fromNode, weight);
                        Edges.Add(reverseEdge);
                    }
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

        public List<List<string>> GetAdjacencyList()
        {
            // Crear una lista de listas para almacenar las listas de adyacencia
            List<List<string>> adjacencyList = new List<List<string>>();

            // Crear un diccionario para mapear nombres de nodos a índices en la lista
            Dictionary<string, int> nodeIndexMap = new Dictionary<string, int>();

            // Llenar el mapa y la lista de adyacencia
            for (int i = 0; i < Nodes.Count; i++)
            {
                var node = Nodes[i];
                // Agregar el índice del nodo al mapa
                nodeIndexMap[node.Name] = i;

                // Inicializar la lista de adyacencia para el nodo actual
                adjacencyList.Add(new List<string>());
            }

            // Llenar las listas de adyacencia
            foreach (var node in Nodes)
            {
                int nodeIndex = nodeIndexMap[node.Name];
                var adjacentNodes = node.Edges.Select(e => e.To.Name).ToList();

                foreach (var adjacentNodeName in adjacentNodes)
                {
                    int adjacentNodeIndex = nodeIndexMap[adjacentNodeName];
                    // Agregar el nombre del nodo adyacente a la lista correspondiente
                    adjacencyList[nodeIndex].Add(adjacentNodeName);
                }
            }

            return adjacencyList;
        }

        public List<List<(string To, int Weight)>> GetAdjacencyListWithWeights()
        {
            List<List<(string To, int Weight)>> adjacencyList = new List<List<(string To, int Weight)>>();
            Dictionary<string, int> nodeIndexMap = new Dictionary<string, int>();

            // Llenar el mapa y la lista de adyacencia
            for (int i = 0; i < Nodes.Count; i++)
            {
                var node = Nodes[i];
                // Agregar el índice del nodo al mapa
                nodeIndexMap[node.Name] = i;

                // Inicializar la lista de adyacencia para el nodo actual
                adjacencyList.Add(new List<(string To, int Weight)>());
            }

            // Llenar las listas de adyacencia con pesos
            foreach (var node in Nodes)
            {
                int nodeIndex = nodeIndexMap[node.Name];

                foreach (var edge in node.Edges)
                {
                    int adjacentNodeIndex = nodeIndexMap[edge.To.Name];
                    // Agregar el nodo adyacente y el peso de la arista a la lista correspondiente
                    adjacencyList[nodeIndex].Add((edge.To.Name, edge.Weight));
                }
            }

            return adjacencyList;
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
