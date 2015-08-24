import math
import sys
sys.path.append('C:\\Users\\brenn\\Documents\\GitHubVisualStudio\\burnsystems.evolutionary\\src\\BurnSystems.Evolutionary\\bin\\Debug')

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

def GetGeneticAlgorithm():
    return algorithm

def GetMultipleRounds():
    return multipleRounds

def TestRounds(rounds):
    n = 1.0
    result = []
    while n < rounds:    
        n = n * 1.5
        settings.Rounds = n
        bestIndividual = multipleRounds.Run()
        fitness = logic.GetFitness(bestIndividual).ToString()

        result.append(fitness)

        print("# Rounds: " + settings.Rounds.ToString())
        print("Best Fitness: " + fitness)

    return result

def TestIndividuals(maxIndividuals):    
    n = 1.0    
    result = []
    while n < maxIndividuals:    
        n = n * 1.5
        settings.Rounds = 100
        settings.Individuals = n
        bestIndividual = multipleRounds.Run()
        fitness = logic.GetFitness(bestIndividual).ToString()

        result.append(fitness)

        print("# Individuals: " + settings.Individuals.ToString())
        print("Best Fitness: " + fitness)
        
    return result
