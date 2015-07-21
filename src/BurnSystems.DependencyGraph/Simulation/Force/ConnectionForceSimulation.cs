using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class ConnectionForceSimulation
    {
        public Graph Graph
        {
            get;
            private set;
        }

        public ConnectionForceSimulationSettings Settings
        {
            get;
            private set;
        }

        public ConnectionForceSimulation(Graph graph, ConnectionForceSimulationSettings settings)
        {
            Graph = graph;
            Settings = settings;
        }

        public void Loop(TimeSpan loopTime)
        {
            foreach (var connection in Graph.Connectivities)
            {
                var node1 = connection.Node1;
                var node2 = connection.Node2;

                var distance = Vector2d.GetDistance(node1.Position, node2.Position);
                if (distance < 0.1)
                {
                    // Jitter
                    distance = 0.1;
                }

                var forceS = Settings.DistanceToForceFct(distance);
                forceS *= Settings.ForceFactor;
                forceS *= connection.Connectivity;

                var dX = Math.Max(0.1, node1.Position.X - node2.Position.X);
                var dY = Math.Max(0.1, node1.Position.Y - node2.Position.Y);

                Vector2d force = new Vector2d(forceS * dX / distance, forceS * dY / distance);
                node1.ForceN.AddTo(force.Negate());
                node2.ForceN.AddTo(force);
            }
        }
    }
}
