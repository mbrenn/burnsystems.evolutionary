using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class MinimumDistanceForceSimulationSettings
    {
        public double MinimumDistance
        {
            get;
            set;
        }

        public MinimumDistanceForceSimulationSettings()
        {
            this.MinimumDistance = 50.0;
        }
    }
}
