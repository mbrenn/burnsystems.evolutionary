using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Examples.SquareRoot
{
    public class DoubleIndividual : IIndividual
    {
        public double Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
