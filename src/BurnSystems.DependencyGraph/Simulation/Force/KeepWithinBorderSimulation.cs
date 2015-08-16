using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class KeepWithinBorderSimulation
    {
        Graph graph;

        public KeepWithinBorderSimulationSettings Settings
        {
            get;
            set;
        }

        public KeepWithinBorderSimulation(
            Graph graph,
            KeepWithinBorderSimulationSettings settings)
        {
            this.graph = graph;
            Settings = settings;
        }

        public void Loop(TimeSpan loopTime)
        {
            var c = new Vector2d(
                (Settings.Max.X + Settings.Min.X) / 2,
                (Settings.Max.Y + Settings.Min.Y) / 2);

            foreach (var node in graph.Nodes)
            {
                if (node.Position.X < Settings.Min.X)
                {
                    node.ForceN.X += Settings.Force;
                }

                if (node.Position.Y < Settings.Min.Y)
                {
                    node.ForceN.Y += Settings.Force;
                }

                if (node.Position.X > Settings.Max.X)
                {
                    node.ForceN.X -= Settings.Force;
                }

                if (node.Position.Y > Settings.Max.Y)
                {
                    node.ForceN.Y -= Settings.Force;
                }

                node.ForceN.X -= (node.Position.X - c.X) / 100;
                node.ForceN.Y -= (node.Position.Y - c.Y) / 100;
            }
        }
    }
}
