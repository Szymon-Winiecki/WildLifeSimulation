using System;
using System.Collections.Generic;
using System.Linq;
using WildLifeSimulation.Animals;


namespace WildLifeSimulation.World
{
    class Map
    {
        public static readonly int defaultSize = 10;

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

        public Map() : this(Map.defaultSize, Map.defaultSize) { }

        public Tile GetTileAt(Position position)
        {
            return tiles[position.X, position.Y];
        }

        public List<Animal> GetAllAnimals()
        {
            List<Animal> allAnimals = new List<Animal>();
            foreach(Tile tile in tiles)
            {
                allAnimals.AddRange(tile.Animals);
            }
            return allAnimals;
        }

        public List<Animal> GetAllPredators()
        {
            return (List<Animal>)GetAllAnimals().Where(animal => animal.GetType().IsSubclassOf(typeof(Predator))).ToList();
        }

    }
}
