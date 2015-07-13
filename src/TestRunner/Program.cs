using BurnSystems.Evolutionary;
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
            var logic = new SquareRootLogic(requested);

            double notAsParallel = 0.0;
            double asParallel = 0.0;
            for (var n = 0; n < 10000; n++)
            {
                notAsParallel+= logic.GetFitness(Execute(logic, asParallel: false));

                asParallel += logic.GetFitness(Execute(logic, asParallel: true));

                Console.WriteLine(n.ToString());
            }                

            Console.WriteLine(); 
            Console.WriteLine(" - NotAsParallel: " + notAsParallel.ToString());
            Console.WriteLine(" - AsParallel: " + asParallel.ToString());

            Console.WriteLine(" - Quotient: " + (asParallel / notAsParallel).ToString());
            Console.WriteLine();
            Console.ReadKey();
            
            var vectorLogic = new SquareRootVectorLogic(10);
            Execute(vectorLogic, false);
            Execute(vectorLogic, true);
            Console.ReadKey();
        }

        public static T Execute<T>(IIndividualLogic<T> logic, bool asParallel) where T : IIndividual
        {
            var watch = new Stopwatch();
            watch.Start();

            var individuals = 10000;
            var algo = new RandomAlgorithm<T>(logic)
            {
                Individuals = individuals
            };

            algo.AsParallel = false;
            var result = algo.Run();
            watch.Stop();

            /*Console.WriteLine("Classic");
            Console.WriteLine("Found: " + result.ToString() + " = > " + (logic.ToString()));
            Console.WriteLine("Fitness: " + logic.GetFitness(result).ToString());
            Console.WriteLine("Time: " + watch.Elapsed.ToString());*/

            watch = new Stopwatch();
            watch.Start();
            algo = new RandomAlgorithm<T>(logic)
            {
                Individuals = individuals
            };
            algo.AsParallel = true;

            result = algo.Run();

            watch.Stop();

            /*Console.WriteLine();
            Console.WriteLine("As Parallel");
            Console.WriteLine("Found: " + result.ToString() + " = > " + (logic.ToString()));
            Console.WriteLine("Fitness: " + logic.GetFitness(result).ToString());
            Console.WriteLine("Time: " + watch.Elapsed.ToString());
            Console.WriteLine("Tasks: " + RandomAlgorithm<DoubleIndividual>.Local.Count);*/

            return result;
        }
    }
}
