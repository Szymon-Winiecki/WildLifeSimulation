using System;
using System.Collections.Generic;
using System.Text;
using WildLifeSimulation.Animals;
using WildLifeSimulation.World;

namespace WildLifeSimulation
{
    class Game
    {
        private int mapWidth;
        private int mapHeight;
        private int maxTurnsCount;
        private int initialAnimalsNumber;
        private float predatorsRatio;

        private Map map;
        private Reporter reporter;

        private bool anyPredatorAlive;

        public Game(int mapWidth, int mapHeight, int maxTurnsCount, int initialAnimalsNumber, float predatorsRatio)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.maxTurnsCount = maxTurnsCount;
            this.initialAnimalsNumber = initialAnimalsNumber;
            this.predatorsRatio = predatorsRatio;
        }

        public void Start()
        {
            map = new Map(mapWidth, mapHeight);
            reporter = new Reporter();

            SpawnAnimals();
            RunSimulation();
        }

        private void SpawnAnimals()
        {
            int predatorsNumber = (int)(initialAnimalsNumber * predatorsRatio);
            int nonPredatorsNumber = initialAnimalsNumber - predatorsNumber;

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

                Animal newAnimal = (Animal)Activator.CreateInstance(newAnimalSpecies, this.map, newAnimalGender, newAnimalPosition, 2, reporter);
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
            int turnsCounter = 0;
            anyPredatorAlive = true;

            while (turnsCounter < maxTurnsCount && anyPredatorAlive)
            {
                turnsCounter++;
                Console.WriteLine("\nTurn " + turnsCounter + ":\n");
                Move();
                Console.WriteLine();
                Hunt();
                Console.WriteLine();
                Breed();
                Console.WriteLine();
                DrawMap();
            }
        }

        public void Move()
        {
            List<Animal> animals = map.GetAllAnimals();
            if (animals.Count == 0)
            {
                anyPredatorAlive = false;
                return;
            }

            foreach (Animal animal in animals)
            {
                animal.Move();
            }
        }

        public void Hunt()
        {
            List<Predator> predators = map.GetAllPredators();
            if (predators.Count == 0)
            {
                anyPredatorAlive = false;
                return;
            }

            foreach (Predator predator in predators)
            {
                predator.Hunt();
            }
        }

        public void Breed()
        {
            List<Animal> animals = map.GetAllAnimals();
            if (animals.Count == 0)
            {
                anyPredatorAlive = false;
                return;
            }

            foreach (Animal animal in animals)
            {
                animal.FindPartner();
            }
        }

        public void DrawMap()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    output.Append("┼──────");
                }
                output.Append("┼\n");
                for (int j = 0; j < map.Width; j++)
                {
                    StringBuilder predatorsCount = new StringBuilder("│P:" + map.GetTileAt(new Position(j, i)).Predators.Count);
                    while (predatorsCount.Length < 7)
                    {
                        predatorsCount.Append(" ");
                    }
                    output.Append(predatorsCount);
                }
                output.Append("│\n");
                for (int j = 0; j < map.Width; j++)
                {
                    StringBuilder nonPredatorsCount = new StringBuilder("│O:" + map.GetTileAt(new Position(j, i)).NonPredators.Count);
                    while (nonPredatorsCount.Length < 7)
                    {
                        nonPredatorsCount.Append(" ");
                    }
                    output.Append(nonPredatorsCount);
                }
                output.Append("│\n");
                if (i == map.Height - 1)
                {
                    for (int j = 0; j < map.Width; j++)
                    {
                        output.Append("┼──────");
                    }
                    output.Append("┼\n");
                }
            }
            Console.WriteLine(output);
        }
    }
}
