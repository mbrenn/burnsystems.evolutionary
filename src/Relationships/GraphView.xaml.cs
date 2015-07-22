using BurnSystems.DependencyGraph;
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

namespace Relationships
{
    /// <summary>
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        /// <summary>
        /// Stores the graph instance
        /// </summary>
        Graph graph;

        /// <summary>
        /// Gets or sets the graph to be shown
        /// </summary>
        public Graph Graph
        {
            get { return graph; }
            set
            {
                graph = value;
                InvalidateGraph();
            }
        }

        public GraphView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invalidates the complete graph and 
        /// </summary>
        public void InvalidateGraph()
        {
            // Most simple implementation
            rootCanvas.Children.Clear();

            if (graph != null)
            {
                foreach (var node in graph.Nodes)
                {
                    var textBlock = new TextBlock();
                    textBlock.Text = node.Title;

                    Canvas.SetLeft(textBlock, node.Position.X);
                    Canvas.SetTop(textBlock, node.Position.Y);

                    rootCanvas.Children.Add(textBlock);
                }

                foreach (var connectivity in graph.Connectivities)
                {
                    var line = new Line();
                    line.X1 = connectivity.Node1.Position.X;
                    line.Y1 = connectivity.Node1.Position.Y;
                    line.X2 = connectivity.Node2.Position.X;
                    line.Y2 = connectivity.Node2.Position.Y;
                    line.StrokeThickness = Math.Max(1.0, connectivity.Connectivity);
                    line.Stroke = Brushes.Black;
                    rootCanvas.Children.Add(line);
                }
            }
        }
    }
}
