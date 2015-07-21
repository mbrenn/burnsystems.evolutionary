using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.Evolutionary.Algorithms.Genetic
{
    public class GeneticAlgorithmSettings
    {
        public int Rounds
        {
            get;
            set;
        }

        public int BirthsPerIndividual
        {
            get;
            set;
        }

        public int Individuals
        {
            get;
            set;
        }

        public GeneticAlgorithmSettings()
        {
            this.Rounds = 100;
            this.Individuals = 100;
            this.BirthsPerIndividual = 5;
        }
    
    }
}
