using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class KeepWithinBorderSimulation
    {
        private Graph graph;

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
            this.Settings = settings;
        }

        public void Loop(TimeSpan loopTime)
        {
            var c = new Vector2d(
                (this.Settings.Max.X + this.Settings.Min.X) / 2,
                (this.Settings.Max.Y + this.Settings.Min.Y) / 2);

            foreach (var node in this.graph.Nodes)
            {
                if (node.Position.X < this.Settings.Min.X)
                {
                    node.ForceN.X += this.Settings.Force;
                }

                if (node.Position.Y < this.Settings.Min.Y)
                {
                    node.ForceN.Y += this.Settings.Force;
                }

                if (node.Position.X > this.Settings.Max.X)
                {
                    node.ForceN.X += this.Settings.Force;
                }

                if (node.Position.Y > this.Settings.Max.Y)
                {
                    node.ForceN.Y -= this.Settings.Force;
                }

                node.ForceN.X -= (node.Position.X - c.X) / 100;
                node.ForceN.Y -= (node.Position.Y - c.Y) / 100;
            }
        }
    }
}
