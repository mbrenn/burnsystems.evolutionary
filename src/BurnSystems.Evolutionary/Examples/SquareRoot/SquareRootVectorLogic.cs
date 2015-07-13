using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Examples.SquareRoot
{
    public class SquareRootVectorLogic : IIndividualLogic<DoubleVectorIndividual>
    {
        private int size;

        public SquareRootVectorLogic(int size)
        {
            this.size = size;
        }

        public double GetFitness(DoubleVectorIndividual individual)
        {
            var result = 1.0;
            for (var n = 0; n < this.size; n++)
            {
                var v = individual.Values[n];
                result *= 1.0 / ((v * v) - (n + 1));
            }

            return result;
        }

        public DoubleVectorIndividual Generate(Random random)
        {
            var result = new DoubleVectorIndividual(this.size);
            for (var n = 0; n < this.size; n++)
            {
                result.Values[n] = random.NextDouble() * (n + 1);
            }

            return result;
        }

        public override string ToString()
        {
            return "Looking for square from 0 to " + this.size.ToString();
        }
    }
}
