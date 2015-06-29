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

            this.InitializeGraph();
        }

        public void InitializeGraph()
        {
            var graph = new Graph();
            var node1 = new Node("Vater");
            node1.Position= new Vector2d(50.0, 0.0);
            var node2 = new Node("Mutter");     
            node2.Position = new Vector2d(200.0, 50.0);
            var node3 = new Node("Sohn");

            graph.Nodes.Add(node1);
            graph.Nodes.Add(node2);
            graph.Nodes.Add(node3);

            graph.Connectivities.Add(new Connection(node1, node3, 1.0));            
            graph.Connectivities.Add(new Connection(node2, node3, 1.0));

            this.GraphView.Graph = graph;
                
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(0.01);
            this.timer.Tick += (x, y) =>
                {
                    this.OnAnimation();
                };

            this.timer.Start();

            this.fullSimulation = new FullSimulation(graph);
        }

        public void OnAnimation()
        {
            this.fullSimulation.Loop();

            this.GraphView.InvalidateGraph();
        }
    }
}
