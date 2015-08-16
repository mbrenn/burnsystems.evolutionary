using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary
{
    public interface IIndividualLogic<T> where T : IIndividual
    {
        /// <summary>
        /// Gets the fitness of the individual. Higher numbers reflect good fitness
        /// </summary>
        /// <param name="individual">The individual whose fitness is assessed. </param>
        /// <returns>The fitness of the individual</returns>
        double GetFitness(T individual);

        /// <summary>
        /// Generates a new individual by a random generator
        /// </summary>
        /// <returns>The generated indivudual</returns>
        T Generate(Random random);

        /// <summary>
        /// Mutates the given individual by the given variance
        /// </summary>
        /// <param name="individual">Individual to be modified</param>
        /// <param name="variance">Variance for random</param>
        T Mutate(Random random, T individual, double variance);

        /// <summary>
        /// Combines two individuals randomly
        /// </summary>
        /// <param name="random">Random generator to be used</param>
        /// <param name="individual1">First individual being combined</param>
        /// <param name="individual2">Second individual being combined</param>
        /// <returns>The new individual</returns>
        T Combine(Random random, T individual1, T individual2);
    }
}
