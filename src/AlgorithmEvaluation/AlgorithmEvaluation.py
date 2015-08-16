import math
import clr


clr.AddReference("BurnSystems.Evolutionary")

from BurnSystems.Evolutionary.Algorithms import *
from BurnSystems.Evolutionary.Algorithms.Genetic import *
from BurnSystems.Evolutionary.Examples.SquareRoot import *

settings = GeneticAlgorithmSettings()
logic = SquareRootVectorLogic(10)

## no Autocomplete for algorithm, but having autocomplete for settings and logic
algorithm = GeneticAlgorithm[DoubleVectorIndividual](logic, settings)
multipleRounds = MultipleRounds[DoubleVectorIndividual](algorithm, 10)



for  x in range(0,12):
    
    settings.Rounds = math.pow(2, x)
    bestIndividual = multipleRounds.Run()
    print(bestIndividual.ToString())

    print("Best Fitness: " + logic.GetFitness(bestIndividual).ToString())


