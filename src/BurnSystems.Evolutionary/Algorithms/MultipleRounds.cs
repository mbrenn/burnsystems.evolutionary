using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Algorithms
{
    public class MultipleRounds<T> : IAlgorithm<T> where T : IIndividual
    {
        /// <summary>
        /// Stores the number of rounds
        /// </summary>
        private int roundCount;
        /// <summary>
        /// Stores the algorithm
        /// </summary>
        private IAlgorithm<T> algorithm;

        /// <summary>
        /// Collects all individuals which were found during the enumerbation
        /// </summary>
        private IEnumerable<T> individuals;

        public IIndividualLogic<T> Logic
        {
            get
            {
                return algorithm.Logic;
            }
        }

        /// <summary>
        /// Initializes a new instance of the MultipleRounds instance
        /// </summary>
        /// <param name="algorithm">Algorithm to be used to find the best object</param>
        /// <param name="roundCount">Number of rounds</param>
        public MultipleRounds(IAlgorithm<T> algorithm, int roundCount)
        {
            this.algorithm = algorithm;
            this.roundCount = roundCount;
        }

        /// <summary>
        /// Executes the algorithm multiple times and returns the best instance of all
        /// </summary>
        /// <returns>The best instance</returns>
        public T Run()
        {
            T best = default(T);
            var bestFitness = Double.MinValue;

            var individualsArray = new T[roundCount];

            for (var n = 0; n < roundCount; n++)
            {
                var current = algorithm.Run();
                individualsArray[n] = current;
                var currentFitness = algorithm.Logic.GetFitness(current);
                if (currentFitness > bestFitness)
                {
                    best = current;
                    bestFitness = currentFitness;
                }
            }

            individuals = individualsArray;

            return best;
        }
    }
}
