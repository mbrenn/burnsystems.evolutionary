using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Examples.SquareRoot
{
    public class SquareRootLogic : IIndividualLogic<DoubleIndividual>
    {
        public SquareRootLogic(double sqrtOf)
        {
            this.SquareRootOf = sqrtOf;
        }

        public double SquareRootOf
        {
            get;
            set;
        }

        public double GetFitness(DoubleIndividual individual)
        {
            var value = individual.Value;
            if (value * value == this.SquareRootOf)
            {
                return Double.MaxValue;
            }

            else
            {
                return 1.0 / Math.Abs((value * value) - this.SquareRootOf);
            }
        }

        public DoubleIndividual Generate(Random random)
        {
            return new DoubleIndividual()
            {
                Value = random.NextDouble() * this.SquareRootOf
            };
        }
    }
}
