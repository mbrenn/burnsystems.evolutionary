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
        Graph graph;

        ZeroForces zeroForces;

        ConnectionForceSimulation forceSimulation;

        KeepWithinBorderSimulation keepWithinSimulation;

        MinimumDistanceForceSimulation minimumDistanceSimulation;

        MoveSimulation moveSimulation;

        Vector2d area;

        public TimeSpan LoopTime
        {
            get;
            set;
        }

        public FullSimulation(Graph graph, Vector2d area)
        {
            this.area = area;
            LoopTime = TimeSpan.FromSeconds(0.1);

            this.graph = graph;

            zeroForces = new ZeroForces(graph);

            forceSimulation = new ConnectionForceSimulation(
                graph,
                new ConnectionForceSimulationSettings()
                {

                });
            forceSimulation.Settings.SetDistanceFunctionOptimalDistance(100.0);

            keepWithinSimulation = new KeepWithinBorderSimulation(
                graph,
                new KeepWithinBorderSimulationSettings()
                {
                    Min = Vector2d.Zero(),
                    Max = this.area
                });

            moveSimulation = new MoveSimulation(
                graph,
                new MoveSimulationSettings()
                {
                });

            minimumDistanceSimulation = new MinimumDistanceForceSimulation(
                graph,
                new MinimumDistanceForceSimulationSettings()
                {
                });
        }

        public void ResetNodes()
        {
            var random = new Random();
            foreach (var node in graph.Nodes)
            {
                node.Position = new Vector2d(random.NextDouble() * area.X, random.NextDouble() * area.Y);

            }
        }

        public void Loop()
        {
            zeroForces.Loop(LoopTime);
            forceSimulation.Loop(LoopTime);
            keepWithinSimulation.Loop(LoopTime);
            minimumDistanceSimulation.Loop(LoopTime);

            moveSimulation.Loop(LoopTime);
        }
    }
}
