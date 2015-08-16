using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Algorithms
{
    public interface IAlgorithm<T> where T : IIndividual
    {
        /// <summary>
        /// Gets the logic of the individual which is used to manipulate the individuals 
        /// and used to estimate the fitness
        /// </summary>
        IIndividualLogic<T> Logic
        {
            get;
        }

        /// <summary>
        /// Executes the algorithm and returns the best instance
        /// </summary>
        /// <returns>The best instance</returns>
        T Run();
    }
}
