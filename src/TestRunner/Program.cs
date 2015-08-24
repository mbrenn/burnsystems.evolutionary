using BurnSystems.Evolutionary;
using BurnSystems.Evolutionary.Algorithms.Genetic;
using BurnSystems.Evolutionary.Algorithms.Random;
using BurnSystems.Evolutionary.Examples.SquareRoot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunner
{
    class Program
    {
        public static void Main(string[] args)
        {
            var requested = 5.0;
            var loops = 1;
            
            var logic = new SquareRootLogic(requested);
            ExecuteLoops(loops, logic);

            var vectorLogic = new SquareRootVectorLogic(10);
            ExecuteLoops(loops, vectorLogic);

            Console.WriteLine("Press key...");
            Console.ReadKey();
        }

        static void ExecuteLoops<T>(int loops, IIndividualLogic<T> logic) where T : IIndividual
        {
            var notAsParallel = 0.0;
            var asParallel = 0.0;
            var asGenetic = 0.0;
            for (var n = 0; n < loops; n++)
            {
                var best = ExecuteByRandom(logic, asParallel: false);
                notAsParallel += logic.GetFitness(best);
                Console.WriteLine(best.ToString());

                best = ExecuteByRandom(logic, asParallel: true);
                asParallel += logic.GetFitness(best);
                Console.WriteLine("Random: " + best.ToString());

                best = ExecuteByGenetic(logic);
                asGenetic += logic.GetFitness(best);
                Console.WriteLine("Genetic: " + best.ToString());

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(" - NotAsParallel: " + notAsParallel.ToString());
            Console.WriteLine(" - AsParallel: " + asParallel.ToString());
            Console.WriteLine(" - AsGenetic: " + asGenetic.ToString());

            Console.WriteLine(" - Quotient: " + (asParallel / notAsParallel).ToString());
            Console.WriteLine();
        }

        public static T ExecuteByRandom<T>(IIndividualLogic<T> logic, bool asParallel) where T : IIndividual
        {
            var watch = new Stopwatch();
            watch.Start();
            var individuals = 100000;

            if (!asParallel)
            {
                var algo = new RandomAlgorithm<T>(logic)
                {
                    Individuals = individuals
                };

                algo.AsParallel = false;
                var result = algo.Run();
                watch.Stop();
                return result;
            }
            else
            {
                watch = new Stopwatch();
                watch.Start();
                var algo = new RandomAlgorithm<T>(logic)
                {
                    Individuals = individuals
                };
                algo.AsParallel = true;

                var result = algo.Run();

                watch.Stop();

                return result;
            }
        }

        public static T ExecuteByGenetic<T>(IIndividualLogic<T> logic) where T : IIndividual
        {
            var watch = new Stopwatch();
            watch.Start();

            var algo = new GeneticAlgorithm<T>(logic,
                new GeneticAlgorithmSettings()
                {
                    Individuals = 100,
                    BirthsPerIndividual = 100,
                    Rounds = 100,
                    TraceIndividuals = true,
                    CombinedIndividuals = 50
                });

            algo.RoundDone += (x, y) =>
            {
                
            };
            var result = algo.Run();
            watch.Stop();

            Console.WriteLine("TIME: " + watch.Elapsed.ToString());
            return result;
        }
    }
}
