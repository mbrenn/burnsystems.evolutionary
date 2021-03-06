﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Algorithms.Random
{
    public class RandomAlgorithm<Individual> : IAlgorithm<Individual>
        where Individual : IIndividual
    {
        public bool AsParallel = false;

        IIndividualLogic<Individual> logic;

        public IIndividualLogic<Individual> Logic
        {
            get { return logic; }
        }

        public int Individuals
        {
            get;
            set;
        }

        public RandomAlgorithm(IIndividualLogic<Individual> logic)
        {
            this.logic = logic;
        }

        ThreadLocal<System.Random> randomLocal = new ThreadLocal<System.Random>(
            () => new System.Random(Environment.TickCount ^ new Guid().GetHashCode()), false);

        /// <summary>
        /// Runs the algorithm and returns the best individual
        /// </summary>
        /// <returns>Returns the best algorithm</returns>
        public Individual Run()
        {
            var max = Double.MinValue;
            Individual result = default(Individual);

            if (!AsParallel)
            {
                var rnd = new System.Random();
                for (var n = 0; n < Individuals; n++)
                {
                    var individual = logic.Generate(rnd);
                    var current = logic.GetFitness(individual);

                    if (current > max)
                    {
                        max = current;
                        result = individual;
                    }
                }
            }
            else
            {
                Parallel.For<Local>(
                    0,
                    Individuals,
                    () => new Local(),
                    (n, t, local) =>
                    {
                        var individual = logic.Generate(randomLocal.Value);
                        var current = logic.GetFitness(individual);

                        if (current > local.MaxValue)
                        {
                            local.MaxValue = current;
                            local.Individual = individual;
                        }

                        return local;
                    },
                (local) =>
                {
                    if (local.MaxValue > max)
                    {
                        max = local.MaxValue;
                        result = local.Individual;
                    }
                });
            }

            return result;
        }

        public class Local
        {
            public double MaxValue;
            public Individual Individual;

            public static int Count;

            public Local()
            {
                Interlocked.Increment(ref Count);
                MaxValue = Double.MinValue;
            }
        }
    }
}
