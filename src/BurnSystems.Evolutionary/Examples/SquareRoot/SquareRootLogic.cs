using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                var diff = Math.Abs((value * value) - this.SquareRootOf);
                if (diff == 0)
                {
                    return 100;
                }

                return Math.Log10(1.0 / diff);
            }
        }

        public DoubleIndividual Generate(Random random)
        {
            Interlocked.Increment(ref calculationCount);
            
            return new DoubleIndividual()
            {
                Value = random.NextDouble() * this.SquareRootOf
            };
        }

        /// <summary>
        /// Mutates the given individual by the given variance
        /// </summary>
        /// <param name="individual">Individual to be modified</param>
        /// <param name="variance">Variance for random</param>
        public DoubleIndividual Mutate(Random random, DoubleIndividual individual, double variance)
        {
            return new DoubleIndividual()
            {
                Value = individual.Value + (random.NextDouble() * variance) - (0.5 * variance)
            };
        }

        public override string ToString()
        {
            return string.Format(
                "Looking for: Sqrt({0}) = '{1}'",
                this.SquareRootOf.ToString(),
                Math.Sqrt(this.SquareRootOf).ToString());
        }

        private static int calculationCount = 0;

        public static void ResetCalculationCount()
        {
            calculationCount = 0;
        }

        public static int GetCalculationCount()
        {
            return calculationCount;
        }
    }
}
