using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class MinimumDistanceForceSimulation
    {
        Graph graph;

        public MinimumDistanceForceSimulationSettings Settings
        {
            get;
            set;
        }

        public MinimumDistanceForceSimulation(Graph graph, MinimumDistanceForceSimulationSettings settings)
        {
            this.graph = graph;
            Settings = settings;
        }

        public void Loop(TimeSpan loopTime)
        {
            var random = new Random();
            var nodeCount = graph.Nodes.Count;

            for (var n = 0; n < (nodeCount - 1); n++)
            {
                for (var m = n + 1; m < nodeCount; m++)
                {
                    var node1 = graph.Nodes[n];
                    var node2 = graph.Nodes[m];

                    var distance = Vector2d.GetDistance(node1.Position, node2.Position);

                    if (distance < Settings.MinimumDistance)
                    {
                        var forceS = (distance - Settings.MinimumDistance) / Settings.MinimumDistance;

                        var dX = node1.Position.X - node2.Position.X;
                        var dY = node1.Position.Y - node2.Position.Y;

                        if ( distance < 0.01)
                        {
                            dX = (random.NextDouble() - 0.5) * 2;
                            dY = Math.Sqrt(1 - dX * dX);
                        }
                        else
                        {
                            dX /= distance;
                            dY /= distance;
                        }

                        Vector2d force = new Vector2d(forceS * dX, forceS * dY);
                        node1.ForceN.AddTo(force.Negate());
                        node2.ForceN.AddTo(force);
                    }
                }
            }
        }
    }
}
