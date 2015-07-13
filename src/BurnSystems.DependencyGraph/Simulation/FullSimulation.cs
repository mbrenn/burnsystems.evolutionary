using BurnSystems.DependencyGraph.Simulation.Force;
using BurnSystems.DependencyGraph.Simulation.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation
{
    public class FullSimulation
    {
        /// <summary>
        /// Stores the graph
        /// </summary>
        private Graph graph;

        private ZeroForces zeroForces;

        private ConnectionForceSimulation forceSimulation;

        private KeepWithinBorderSimulation keepWithinSimulation;

        private MinimumDistanceForceSimulation minimumDistanceSimulation;

        private MoveSimulation moveSimulation;

        private Vector2d area;

        public TimeSpan LoopTime
        {
            get;
            set;
        }

        public FullSimulation(Graph graph, Vector2d area)
        {
            this.area = area;
            this.LoopTime = TimeSpan.FromSeconds(0.1);

            this.graph = graph;

            this.zeroForces = new ZeroForces(graph);

            this.forceSimulation = new ConnectionForceSimulation(
                graph,
                new ConnectionForceSimulationSettings()
                {

                });
            this.forceSimulation.Settings.SetDistanceFunctionOptimalDistance(100.0);

            this.keepWithinSimulation = new KeepWithinBorderSimulation(
                graph,
                new KeepWithinBorderSimulationSettings()
                {
                    Min = Vector2d.Zero(),
                    Max = this.area
                });

            this.moveSimulation = new MoveSimulation(
                graph,
                new MoveSimulationSettings()
                {
                });

            this.minimumDistanceSimulation = new MinimumDistanceForceSimulation(
                graph,
                new MinimumDistanceForceSimulationSettings()
                {
                });
        }

        public void ResetNodes()
        {
            var random = new Random();
            foreach (var node in this.graph.Nodes)
            {
                node.Position = new Vector2d(random.NextDouble() * area.X, random.NextDouble() * area.Y);

            }
        }

        public void Loop()
        {
            this.zeroForces.Loop(this.LoopTime);
            this.forceSimulation.Loop(this.LoopTime);
            this.keepWithinSimulation.Loop(this.LoopTime);
            this.minimumDistanceSimulation.Loop(this.LoopTime);

            this.moveSimulation.Loop(this.LoopTime);
        }
    }
}
