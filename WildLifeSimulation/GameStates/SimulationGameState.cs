using System;
using System.Collections.Generic;
using WildLifeSimulation.SimulationPhases;
using WildLifeSimulation.World;
using WildLifeSimulation.Animals;

namespace WildLifeSimulation.GameStates
{
    class SimulationGameState : GameState
    {
        private bool isInitialised;
        private List<SimulationPhase> simulationPhases;
        private SimulationSettings settings;
        private int turnsCounter;

        private Map map;
        private Reporter reporter;

        public SimulationGameState(SimulationSettings simulationSettings)
        {
            isInitialised = false;
            simulationPhases = new List<SimulationPhase>();
            settings = simulationSettings;
        }

        public override GameState Main()
        {
            if(!isInitialised)
                InitSimulation();
            RunSimulation();
            return new EndGameState();
        }

        private void InitSimulation()
        {
            CreateWorld();
            SpawnAnimals();

            turnsCounter = 0;

            simulationPhases.Add(new MovingPhase(map));
            simulationPhases.Add(new HuntingPhase(map));
            simulationPhases.Add(new BreedingPhase(map));
            simulationPhases.Add(new DrawingMapPhase(map));
        }

        private void CreateWorld()
        {
            map = new Map(settings.MapWidth, settings.MapHeight);
            reporter = new Reporter(settings.Report);
        }

        private void SpawnAnimals()
        {
            int predatorsNumber = (int)(settings.InitialAnimalNumber * settings.InitialPredatorsRatio);
            int nonPredatorsNumber = settings.InitialAnimalNumber - predatorsNumber;

            List<Type> predatorSpecies = Animal.GetAvailableSpecies(true);
            List<Type> nonPredatorSpecies = Animal.GetAvailableSpecies(false);

            Random random = new Random();

            Console.WriteLine();

            Position newAnimalPosition;
            Type newAnimalSpecies;
            Gender newAnimalGender;
            for (int i = 0; i < predatorsNumber; i++)
            {
                newAnimalPosition = Position.RandomPosition(map);
                newAnimalSpecies = predatorSpecies[random.Next(predatorSpecies.Count)];
                newAnimalGender = (random.Next(2) == 0) ? (Gender.Male) : (Gender.Female);

                Animal newAnimal = (Animal)Activator.CreateInstance(newAnimalSpecies, this.map, newAnimalGender, newAnimalPosition, settings.PredatorsHp, reporter);
                reporter.ReportBirth(newAnimal);
                map.GetTileAt(newAnimalPosition).AddAnimal(newAnimal);
            }

            for (int i = 0; i < nonPredatorsNumber; i++)
            {
                newAnimalPosition = Position.RandomPosition(map);
                newAnimalSpecies = nonPredatorSpecies[random.Next(nonPredatorSpecies.Count)];
                newAnimalGender = (random.Next(2) == 0) ? (Gender.Male) : (Gender.Female);

                Animal newAnimal = (Animal)Activator.CreateInstance(newAnimalSpecies, this.map, newAnimalGender, newAnimalPosition, reporter);
                reporter.ReportBirth(newAnimal);
                map.GetTileAt(newAnimalPosition).AddAnimal(newAnimal);
            }

        }

        private void RunSimulation()
        {
            bool simulationRunning = true;
            while (simulationRunning && turnsCounter < settings.MaxTurnsCount)
            {
                turnsCounter++;
                Console.WriteLine("\nTurn " + turnsCounter + ":" );
                foreach(SimulationPhase phase in simulationPhases)
                {
                    if (!phase.Main())
                        simulationRunning = false;
                }
            }
        }
    }
}
