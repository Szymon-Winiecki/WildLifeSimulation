using System;
using System.Collections.Generic;

namespace WildLifeSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(6, 6, 30, 500, 0.2f);
            game.Start();
        }
    }
}
