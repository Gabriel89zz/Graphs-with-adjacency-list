using System.Linq;

namespace Graphs_with_adjacency_list
{
    public partial class Form1 : Form
    {
        private Graph graph;

        public Form1()
        {
            InitializeComponent();
            graph = new Graph();
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            string nodeName = txtNode.Text;

            if (!string.IsNullOrWhiteSpace(nodeName) && !graph.Nodes.Any(n => n.Name == nodeName)) // Validar que no exista el nodo
            {
                Node newNode = new Node(nodeName); // Crear un nuevo nodo
                graph.AddNode(newNode); // Agregar el nodo directamente
                MessageBox.Show($"Nodo {nodeName} agregado.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre de nodo válido o el nodo ya existe.");
            }

            txtNode.Clear();
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            string from = txtFrom.Text;
            string to = txtTo.Text;
            bool isDirected = chkDirected.Checked;
            string weightText = txtWeight.Text;

            Node fromNode = graph.Nodes.FirstOrDefault(n => n.Name == from);
            Node toNode = graph.Nodes.FirstOrDefault(n => n.Name == to);

            if (fromNode != null && toNode != null) // Verificar que ambos nodos existan
            {
                if (string.IsNullOrWhiteSpace(weightText)) // Si no hay valor para el peso
                {
                    // Agregar la arista sin peso
                    graph.AddEdge(fromNode, toNode, isDirected: isDirected);
                    MessageBox.Show($"Arista {from} -> {to} agregada.");
                }
                else
                {
                    // Si se ha introducido un valor para el peso, intentar convertirlo
                    int weight;
                    if (!int.TryParse(weightText, out weight))
                    {
                        MessageBox.Show("Por favor, introduzca un valor numérico válido para el peso.");
                        return;
                    }

                    // Agregar la arista con el peso
                    graph.AddWeightedEdge(fromNode, toNode, weight, isDirected: isDirected);
                    MessageBox.Show($"Arista {from} -> {to} con peso {weight} agregada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, asegúrese de que ambos nodos existan.");
            }

            // Limpiar los campos de texto
            txtFrom.Clear();
            txtTo.Clear();
            txtWeight.Clear(); // Limpiar el campo de peso
        }

        private void btnRemoveEdge_Click(object sender, EventArgs e)
        {
            string from = txtFrom.Text;
            string to = txtTo.Text;
            bool isDirected = chkDirected.Checked;

            Node fromNode = graph.Nodes.FirstOrDefault(n => n.Name == from);
            Node toNode = graph.Nodes.FirstOrDefault(n => n.Name == to);

            if (fromNode != null && toNode != null) // Verificar que ambos nodos existan
            {
                graph.RemoveEdge(fromNode, toNode, isDirected); // Eliminar la arista con la opción de dirigido o no dirigido
                MessageBox.Show($"Arista {from} -> {to} eliminada.");
            }
            else
            {
                MessageBox.Show("Por favor, asegúrese de que ambos nodos existan.");
            }

            txtFrom.Clear();
            txtTo.Clear();
        }

        private void btnShowAdjacencyList_Click(object sender, EventArgs e)
        {
            txtGraphRepresentation.Clear();

            if (graph.IsWeighted) // Si el grafo contiene pesos
            {
                // Obtener la lista de adyacencia con pesos
                var adjacencyListWithWeights = graph.GetAdjacencyListWithWeights();

                if (adjacencyListWithWeights.Count > 0)
                {
                    for (int i = 0; i < adjacencyListWithWeights.Count; i++)
                    {
                        string nodeName = graph.Nodes[i].Name; // Suponiendo que tienes acceso a los nodos por índice
                        string edgesString = string.Join(", ", adjacencyListWithWeights[i].Select(edge => $"({edge.To}, {edge.Weight})"));
                        txtGraphRepresentation.AppendText($"{nodeName}: {edgesString}\r\n");
                    }
                }
                else
                {
                    txtGraphRepresentation.AppendText("No hay aristas en el grafo.");
                }
            }
            else // Si el grafo no tiene pesos
            {
                var adjacencyList = graph.GetAdjacencyList(); // Asumiendo que esta lista es de tipo List<List<string>>

                if (adjacencyList.Count > 0)
                {
                    for (int i = 0; i < adjacencyList.Count; i++)
                    {
                        string nodeName = graph.Nodes[i].Name; // Suponiendo que tienes acceso a los nodos por índice
                        string edgesString = string.Join(", ", adjacencyList[i]);
                        txtGraphRepresentation.AppendText($"{nodeName}: {edgesString}\r\n");
                    }
                }
                else
                {
                    txtGraphRepresentation.AppendText("No hay aristas en el grafo.");
                }
            }
        }

        private void btnShowDFS_Click(object sender, EventArgs e)
        {
            txtGraphRepresentation.Clear();
            // Obtener el nombre del nodo de inicio desde una TextBox (puede ser un número o una palabra)
            string startNodeName = txtStartNode.Text;

            // Buscar el nodo en el grafo cuyo nombre coincida con el ingresado
            Node startNode = graph.Nodes.FirstOrDefault(n => n.Name == startNodeName);

            if (startNode != null)
            {
                // Realizar DFS desde el nodo encontrado
                string result = graph.DFS(startNode);
                txtGraphRepresentation.Text = result;  // Mostrar el resultado en el TextBox
            }
            else
            {
                // Si el nodo no existe, mostrar un mensaje de error
                txtGraphRepresentation.Text = "Nodo no encontrado.";
            }
        }

        private void btnRemoveNode_Click(object sender, EventArgs e)
        {
            // Obtén el nombre del nodo desde el TextBox
            string nodeNameToRemove = txtNode.Text.Trim(); // Usa Trim() para eliminar espacios en blanco

            if (!string.IsNullOrEmpty(nodeNameToRemove))
            {
                // Encuentra el nodo correspondiente
                Node nodeToRemove = graph.Nodes.FirstOrDefault(n => n.Name == nodeNameToRemove);

                if (nodeToRemove != null)
                {
                    // Llama al método RemoveNode para eliminar el nodo del grafo
                    graph.RemoveNode(nodeToRemove);

                    txtNode.Clear(); // Limpia el TextBox después de eliminar el nodo
                    MessageBox.Show($"Nodo {nodeNameToRemove} eliminado.");
                }
                else
                {
                    MessageBox.Show("Nodo no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre del nodo para eliminar.");
            }
        }

        private void btnShowBFS_Click(object sender, EventArgs e)
        {

            txtGraphRepresentation.Clear();
            // Obtener el nombre del nodo de inicio desde una TextBox (puede ser un número o una palabra)
            string startNodeName = txtStartNode.Text;

            // Buscar el nodo en el grafo cuyo nombre coincida con el ingresado
            Node startNode = graph.Nodes.FirstOrDefault(n => n.Name == startNodeName);

            if (startNode != null)
            {
                // Realizar DFS desde el nodo encontrado
                string result = graph.BFS(startNode);
                txtGraphRepresentation.Text = result;  // Mostrar el resultado en el TextBox
            }
            else
            {
                // Si el nodo no existe, mostrar un mensaje de error
                txtGraphRepresentation.Text = "Nodo no encontrado.";
            }
        }
    }
}
