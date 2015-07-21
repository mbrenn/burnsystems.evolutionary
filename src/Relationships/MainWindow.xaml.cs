using BurnSystems.DependencyGraph;
using BurnSystems.DependencyGraph.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Relationships
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Stores the dispatcher timer
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// Stores the full simulation
        /// </summary>
        private FullSimulation fullSimulation;

        public MainWindow()
        {
            InitializeComponent();

            InitializeGraph();
        }

        public void InitializeGraph()
        {
            var graph = new Graph();
            var node1 = new Node("Vater");
            var node2 = new Node("Mutter");     
            var node3 = new Node("Sohn");
            var node4 = new Node("Enkel 1");
            var node5 = new Node("Enkel 2");
            var node6 = new Node("Großenkel 1");
            var node7 = new Node("Großenkel 2");
            var node8 = new Node("Großenkel 3");
            var node9 = new Node("Großenkel 4");

            graph.Nodes.Add(node1);
            graph.Nodes.Add(node2);
            graph.Nodes.Add(node3);
            graph.Nodes.Add(node4);
            graph.Nodes.Add(node5);
            graph.Nodes.Add(node6);
            graph.Nodes.Add(node7);
            graph.Nodes.Add(node8);
            graph.Nodes.Add(node9);

            graph.Connectivities.Add(new Connection(node1, node3, 1.0));            
            graph.Connectivities.Add(new Connection(node2, node3, 1.0));
            graph.Connectivities.Add(new Connection(node3, node4, 1.0));
            graph.Connectivities.Add(new Connection(node3, node5, 1.0));
            graph.Connectivities.Add(new Connection(node4, node6, 1.0));
            graph.Connectivities.Add(new Connection(node4, node7, 1.0));
            graph.Connectivities.Add(new Connection(node5, node8, 1.0));
            graph.Connectivities.Add(new Connection(node5, node9, 1.0));

            GraphView.Graph = graph;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += (x, y) =>
                {
                    OnAnimation();
                };

            timer.Start();

            fullSimulation = new FullSimulation(graph, new Vector2d(300.0, 300.0));
            fullSimulation.ResetNodes();
        }

        public void OnAnimation()
        {
            fullSimulation.Loop();

            GraphView.InvalidateGraph();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer = null;

            InitializeGraph();

        }
    }
}
