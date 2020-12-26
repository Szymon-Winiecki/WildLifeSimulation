using System;
using System.Collections.Generic;
using WildLifeSimulation.Animals;


namespace WildLifeSimulation.World
{
    class Map
    {
        private Tile[,] tiles;
        public int Width
        { get; set; }
        public int Height
        { get; set; }

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this.tiles = new Tile[Width, Height];

            for(int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    tiles[i, j] = new Tile();
                }
            }
        }

        public Tile GetTileAt(Position position)
        {
            if(position.X >= 0 && position.X <= this.Width && position.Y >= 0 && position.Y <= this.Height)
            {
                return tiles[position.X, position.Y];
            }
            else
            {
                Console.WriteLine("Position: " + position + "does not exist on the map");
                return null;
            }
        }

        public List<Animal> GetAllAnimals()
        {
            List<Animal> allAnimals = new List<Animal>();
            foreach(Tile tile in tiles)
            {
                allAnimals.AddRange(tile.Predators);
                allAnimals.AddRange(tile.NonPredators);
            }
            return allAnimals;
        }

        public List<Predator> GetAllPredators()
        {
            List<Predator> allPredators = new List<Predator>();
            foreach (Tile tile in tiles)
            {
                allPredators.AddRange(tile.Predators);
            }
            return allPredators;
        }

    }
}
