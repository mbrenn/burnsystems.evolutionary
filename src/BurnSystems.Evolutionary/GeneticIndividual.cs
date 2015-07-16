using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary
{
    public class GeneticIndividual<T> where T : IIndividual
    {
        /// <summary>
        /// Gets or sets the current variance
        /// </summary>
        public double CurrentVariance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the individual
        /// </summary>
        public T Individual
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the GeneticIndividual
        /// </summary>
        /// <param name="individual">Individual being added</param>
        public GeneticIndividual(T individual)
        {
            this.CurrentVariance = 1.0;
            this.Individual = individual;
        }
    }
}
