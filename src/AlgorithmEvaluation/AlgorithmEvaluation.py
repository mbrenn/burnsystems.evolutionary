import math
import clr
import csv

clr.AddReference("BurnSystems.Evolutionary")

from BurnSystems.Evolutionary.Algorithms import *
from BurnSystems.Evolutionary.Algorithms.Genetic import *
from BurnSystems.Evolutionary.Examples.SquareRoot import *

settings = GeneticAlgorithmSettings()
logic = SquareRootVectorLogic(10)

## no Autocomplete for algorithm, but having autocomplete for settings and logic
algorithm = GeneticAlgorithm[DoubleVectorIndividual](logic, settings)
multipleRounds = MultipleRounds[DoubleVectorIndividual](algorithm, 10)

with open("rounds.csv", "wb") as csvfile:

    csvwriter = csv.writer(csvfile, delimiter=",")

    for x in range(0,20):
    
        settings.Rounds = math.pow(1.5, x)
        bestIndividual = multipleRounds.Run()
        fitness = logic.GetFitness(bestIndividual).ToString()

        print("# Rounds: " + settings.Rounds.ToString())
        print("Best Fitness: " + fitness)

        csvwriter.writerow([settings.Rounds, fitness])
        
with open("individuals.csv", "wb") as csvfile:

    csvwriter = csv.writer(csvfile, delimiter=",")

    for x in range(0,20):
    
        settings.Rounds = 100
        settings.Individuals = math.pow(1.5, x)
        bestIndividual = multipleRounds.Run()
        fitness = logic.GetFitness(bestIndividual).ToString()

        print("# Individuals: " + settings.Individuals.ToString())
        print("Best Fitness: " + fitness)

        csvwriter.writerow([settings.Individuals, fitness])


