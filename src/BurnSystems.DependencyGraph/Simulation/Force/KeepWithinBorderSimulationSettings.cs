using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class KeepWithinBorderSimulationSettings
    {
        public Vector2d Min;

        public Vector2d Max;

        public double Force
        {
            get;
            set;
        }

        public KeepWithinBorderSimulationSettings()
        {
            Min = Vector2d.Zero();
            Max = new Vector2d(300.0, 300.0);
            Force = 10;
        }
    }
}
