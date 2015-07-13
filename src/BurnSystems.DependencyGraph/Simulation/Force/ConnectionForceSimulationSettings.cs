using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph.Simulation.Force
{
    public class ConnectionForceSimulationSettings
    {
        public double ForceFactor
        {
            get;
            set;
        }

        public Func<double, double> DistanceToForceFct
        {
            get;
            set;
        }

        public double PositiveForceFactor
        {
            get;
            set;
        }

        public double NegativeForceFactor
        {
            get;
            set;
        }

        public ConnectionForceSimulationSettings()
        {
            this.ForceFactor = 1.0;
            this.DistanceToForceFct = x => 1.0 / (x * x);
            this.PositiveForceFactor = 0.1;
            this.NegativeForceFactor = 0.1;
        }

        public void SetDistanceFunctionOptimalDistance(double d)
        {
            this.DistanceToForceFct = x =>
                {
                    var dX = x - d;
                    if (dX < 1.0)
                    {
                        return (dX + 0.01) * this.NegativeForceFactor;
                    }
                    else
                    {
                        return dX * this.PositiveForceFactor;
                    }
                };
        }
    }
}
