using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary
{
    /// <summary>
    /// Defines an algorithm, which creates a number of instances at the 
    /// start of the optimisation and then randomizes the values of each individual. 
    /// After that, the values with the highest fitness will survive
    /// </summary>
    public class GeneticAlgorithm<T> where T : IIndividual
    {
        private GeneticAlgorithmSettings settings;

        private IIndividualLogic<T> logic;

        public GeneticAlgorithm(IIndividualLogic<T> logic, GeneticAlgorithmSettings settings)
        {
            this.logic = logic;
            this.settings = settings;
        }

        public T Run()
        {
            var random = new Random();
            var currentItems = new GeneticIndividual<T>[this.settings.Individuals];
            for (var n = 0; n < this.settings.Individuals; n++)
            {
                currentItems[n] = new GeneticIndividual<T>(this.logic.Generate(random));
            }

            for (var nRound = 0; nRound < this.settings.Rounds; nRound++)
            {
                var c = 0;
                var intermediate = new GeneticIndividual<T>[this.settings.Individuals * this.settings.BirthsPerIndividual];

                for (var nIndividual = 0; nIndividual < this.settings.Individuals; nIndividual++)
                {
                    var individual = currentItems[nIndividual];
                    for (var nBirth = 0; nBirth < this.settings.BirthsPerIndividual; nBirth++)
                    {
                        var currentVariance = individual.CurrentVariance + random.NextDouble() - 0.5;
                        var newIndividual = this.logic.Mutate(
                            random,
                            individual.Individual, 
                            currentVariance);

                        intermediate[c] = new GeneticIndividual<T>(newIndividual);
                        intermediate[c].CurrentVariance = currentVariance;

                        c++;
                    }
                }

                // Store the first 100 into the currentItems
                currentItems = intermediate
                    .OrderByDescending(x => this.logic.GetFitness(x.Individual))
                    .Take(this.settings.Individuals)
                    .ToArray();
            }

            return currentItems.OrderByDescending(
                x => this.logic.GetFitness(x.Individual)).First().Individual;
        }
    }
}
