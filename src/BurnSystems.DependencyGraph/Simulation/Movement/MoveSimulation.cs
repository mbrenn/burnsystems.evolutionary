using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Movement
{
    public class MoveSimulation
    {
        Graph graph;

        MoveSimulationSettings settings;

        public MoveSimulation(Graph graph, MoveSimulationSettings settings)
        {
            this.graph = graph;
            this.settings = settings;
        }

        public void Loop(TimeSpan loopTime)
        {
            foreach (var node in graph.Nodes)
            {
                node.Position.X += node.ForceN.X;
                node.Position.Y += node.ForceN.Y;
            }
        }
    }
}
