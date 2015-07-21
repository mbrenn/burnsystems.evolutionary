using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class ZeroForces
    {
        private Graph graph;
        public ZeroForces(Graph graph)
        {
            this.graph = graph;
        }

        public void Loop(TimeSpan loopTime)
        {
            foreach (var node in graph.Nodes)
            {
                node.ForceN = Vector2d.Zero();
            }
        }
    }
}
