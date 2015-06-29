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

        private MoveSimulation moveSimulation;

        public TimeSpan LoopTime
        {
            get;
            set;
        }

        public FullSimulation(Graph graph)
        {
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
                new KeepWithinBorderSimulationSettings());

            this.moveSimulation = new MoveSimulation(
                graph,
                new MoveSimulationSettings()
                {
                });
        }

        public void Loop()
        {
            this.zeroForces.Loop(this.LoopTime);
            this.forceSimulation.Loop(this.LoopTime);
            this.keepWithinSimulation.Loop(this.LoopTime);

            this.moveSimulation.Loop(this.LoopTime);
        }
    }
}
