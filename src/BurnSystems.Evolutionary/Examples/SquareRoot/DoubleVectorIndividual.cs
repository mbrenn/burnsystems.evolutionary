using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Examples.SquareRoot
{
    public class DoubleVectorIndividual : IIndividual
    {
        public double[] Values
        {
            get;
            set;
        }

        public DoubleVectorIndividual(int size)
        {
            Values = new double[size];
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var komma = "{";

            for (var n = 0; n < Values.Length;n++ )
            {
                builder.Append(komma);
                komma = "; ";
                builder.Append(
                    Math.Round(Values[n] * Values[n], 3).ToString());
            }

            builder.Append("}");

            return builder.ToString();
        }
    }
}
