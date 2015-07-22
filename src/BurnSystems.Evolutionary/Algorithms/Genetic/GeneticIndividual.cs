using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Algorithms.Genetic
{
    public class GeneticIndividual<T> where T : IIndividual
    {
        /// <summary>
        /// Gets or sets the parent of the individual
        /// </summary>
        public GeneticIndividual<T> Parent
        {
            get;
            set;
        }

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
        public GeneticIndividual(T individual, GeneticIndividual<T> parent = null)
        {
            CurrentVariance = 1.0;
            Individual = individual;
            Parent = parent;
        }
    }
}
