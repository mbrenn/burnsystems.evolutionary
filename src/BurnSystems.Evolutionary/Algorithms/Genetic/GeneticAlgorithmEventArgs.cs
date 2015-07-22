using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Algorithms.Genetic
{
    public class GeneticAlgorithmEventArgs<T> : EventArgs where T : IIndividual
    {
        public GeneticAlgorithm<T> Algorithm
        {
            get;
            set;
        }

        public IEnumerable<GeneticIndividual<T>> Individuals
        {
            get;
            set;
        }

        public GeneticAlgorithmEventArgs(GeneticAlgorithm<T> algorithm, IEnumerable<GeneticIndividual<T>> individuals)
        {
            Algorithm = algorithm;
            Individuals = individuals;
        }
    }
}
