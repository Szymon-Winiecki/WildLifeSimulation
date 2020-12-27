using System;
using System.Collections.Generic;
using WildLifeSimulation.Animals;


namespace WildLifeSimulation.World
{
    class Map
    {
        public List<Predator> allPredators;
        public List<Animal> allNonPredators;

        private Tile[,] tiles;
        public int Width
        { get; set; }
        public int Height
        { get; set; }

        public Map(int width, int height)
        {
            if(width < 0)
            {
                Console.WriteLine("Map width has to be a positive integer. Width is set up to default value of 4.");
                width = 4;
            }
            if(height < 0)
            {
                Console.WriteLine("Map height has to be a positive integer. Height is set up to default value of 4.");
                height = 4;
            }
            this.Width = width;
            this.Height = height;

            this.tiles = new Tile[Width, Height];

            for(int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    tiles[i, j] = new Tile(this);
                }
            }

            allNonPredators = new List<Animal>();
            allPredators = new List<Predator>();
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

    }
}
