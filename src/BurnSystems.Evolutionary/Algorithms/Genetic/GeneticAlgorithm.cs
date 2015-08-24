using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Algorithms.Genetic
{
    /// <summary>
    /// Defines an algorithm, which creates a number of instances at the 
    /// start of the optimisation and then randomizes the values of each individual. 
    /// After that, the values with the highest fitness will survive
    /// </summary>
    public class GeneticAlgorithm<T> : IAlgorithm<T> where T : IIndividual
    {
        GeneticAlgorithmSettings settings;

        IIndividualLogic<T> logic;

        public IIndividualLogic<T> Logic
        {
            get { return this.logic; }
        }

        /// <summary>
        /// This event is called, when the calculation of a specific round is done
        /// </summary>
        /// 
        public event EventHandler<GeneticAlgorithmEventArgs<T>> RoundDone;
        public GeneticAlgorithm(IIndividualLogic<T> logic, GeneticAlgorithmSettings settings)
        {
            this.logic = logic;
            this.settings = settings;
        }

        public T Run()
        {
            var randomLocal = new ThreadLocal<System.Random>(
                () => new System.Random(Environment.TickCount ^ new Guid().GetHashCode()), 
                false);

            var currentItems = new GeneticIndividual<T>[settings.Individuals];
            for (var n = 0; n < settings.Individuals; n++)
            {
                currentItems[n] = new GeneticIndividual<T>(logic.Generate(randomLocal.Value));
            }

            for (var nRound = 0; nRound < settings.Rounds; nRound++)
            {
                var individualsInRound =
                    (settings.Individuals * settings.BirthsPerIndividual) + settings.CombinedIndividuals;
                var intermediate = new GeneticIndividual<T>[individualsInRound];

                var totalCreated = 0;
                Parallel.For(
                    0,
                    settings.Individuals,
                    new Action<int>((nIndividual) =>
                    {
                        var random = randomLocal.Value;
                        var c = nIndividual * settings.BirthsPerIndividual;
                        var parentIndividual = currentItems[nIndividual];
                        for (var nBirth = 0; nBirth < settings.BirthsPerIndividual; nBirth++)
                        {
                            var currentVariance =
                                parentIndividual.CurrentVariance + random.NextDouble() - 0.5;
                            var newIndividual = logic.Mutate(
                                random,
                                parentIndividual.Individual,
                                currentVariance);

                            intermediate[c] = new GeneticIndividual<T>(newIndividual);
                            intermediate[c].CurrentVariance = currentVariance;

                            // Add parents, if requested
                            if (settings.TraceIndividuals)
                            {
                                intermediate[c].Parent = parentIndividual;
                            }

                            c++;
                        }
                }));

                totalCreated += settings.Individuals * settings.BirthsPerIndividual;

                // Now do the combination
                for (var n = 0; n < settings.CombinedIndividuals; n++)
                {
                    var random = randomLocal.Value;
                    var first = random.Next(0, totalCreated);
                    var second = random.Next(0, totalCreated);
                    var firstItem = intermediate[first];
                    var secondItem = intermediate[second];
                    var newIndividual = logic.Combine(random, intermediate[first].Individual, intermediate[second].Individual);
                    intermediate[totalCreated] = new GeneticIndividual<T>(
                        newIndividual)
                    {
                        CurrentVariance = (firstItem.CurrentVariance + secondItem.CurrentVariance) * 0.5
                    };

                    totalCreated++;
                }

                // Store the first 100 into the currentItems
                currentItems = intermediate
                    .OrderByDescending(x => logic.GetFitness(x.Individual))
                    .Take(settings.Individuals)
                    .ToArray();

                // Everything is done... Call the RoundDone event
                OnRoundDone(currentItems);
            }

            return currentItems.OrderByDescending(
                x => logic.GetFitness(x.Individual)).First().Individual;
        }

        /// <summary>
        /// Calls the RoundDone event
        /// </summary>
        void OnRoundDone(IEnumerable<GeneticIndividual<T>> individuals)
        {
            var ev = this.RoundDone;
            if (ev != null)
            {
                ev(this, new GeneticAlgorithmEventArgs<T>(this, individuals));
            }
        }
    }
}
