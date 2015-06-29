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
            var individuals = 10000000;
            var watch = new Stopwatch();
            watch.Start();
            var requested = 5.0;
            var algo = new RandomAlgorithm<DoubleIndividual>(
                new SquareRootLogic(requested))
                {
                    Individuals = individuals
                };

            algo.AsParallel = false;
            var result = algo.Run();
            watch.Stop();

            Console.WriteLine("Classic");
            Console.WriteLine("Found: " + result.Value + " = > " + (result.Value * result.Value));
            Console.WriteLine("Time: " + watch.Elapsed.ToString());

            watch = new Stopwatch();
            watch.Start();
            algo = new RandomAlgorithm<DoubleIndividual>(
                        new SquareRootLogic(requested))
                {
                    Individuals = individuals
                };
            algo.AsParallel = true;

            result = algo.Run();

            watch.Stop();

            Console.WriteLine("As Parallel");
            Console.WriteLine("Found: " + result.Value + " = > " + (result.Value * result.Value));
            Console.WriteLine("Time: " + watch.Elapsed.ToString());
            Console.WriteLine("Tasks: " + RandomAlgorithm<DoubleIndividual>.Local.Count);

            result = algo.Run();
            Console.ReadKey();

        }
    }
}
