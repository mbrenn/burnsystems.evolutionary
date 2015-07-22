using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Examples.SquareRoot
{
    public class SquareRootVectorLogic : IIndividualLogic<DoubleVectorIndividual>
    {
        int size;

        public SquareRootVectorLogic(int size)
        {
            this.size = size;
        }

        public double GetFitness(DoubleVectorIndividual individual)
        {
            var result = 1.0;
            for (var n = 0; n < size; n++)
            {
                var v = individual.Values[n];
                var diff = Math.Abs((v * v) - (n + 1));
                result += Math.Log10(1.0 / diff);
            }

            return result;
        }

        /// <summary>
        /// Mutates the given individual by the given variance
        /// </summary>
        /// <param name="individual">Individual to be modified</param>
        /// <param name="variance">Variance for random</param>
        public DoubleVectorIndividual Mutate(Random random, DoubleVectorIndividual individual, double variance)
        {
            var result = new DoubleVectorIndividual(size);
            result.Values = individual.Values.ToArray();

            for (var n = 0; n < result.Values.Length; n++)
            {
                result.Values[n] += (random.NextDouble() * variance) - (0.5 * variance);
            }

            return result;
        }

        public DoubleVectorIndividual Generate(Random random)
        {
            var result = new DoubleVectorIndividual(size);
            for (var n = 0; n < size; n++)
            {
                result.Values[n] = random.NextDouble() * (n + 1);
            }

            return result;
        }

        public override string ToString()
        {
            return "Looking for square from 0 to " + size.ToString();
        }
    }
}
