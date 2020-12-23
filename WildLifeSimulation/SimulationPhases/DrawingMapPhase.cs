using System;
using System.Collections.Generic;
using System.Text;
using WildLifeSimulation.World;

namespace WildLifeSimulation.SimulationPhases
{
    class DrawingMapPhase : SimulationPhase
    {
        public DrawingMapPhase(Map map) : base(map) { }

        public static string GetLegend()
        {
            return  "┼──────┼ every tile is represented like that\n" +
                    "│P:5   │ P: number of predators in this tile\n" +
                    "│O:10  | O: number of other animals in this tile\n" +
                    "┼──────┼";
        }
        public override bool Main()
        {
            Console.WriteLine();

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
                    StringBuilder predatorsCount = new StringBuilder("│P:" + map.GetTileAt(new Position(j, i)).GetNumberOfPredators());
                    while (predatorsCount.Length < 7)
                    {
                        predatorsCount.Append(" ");
                    }
                    output.Append(predatorsCount);
                }
                output.Append("│\n");
                for (int j = 0; j < map.Width; j++)
                {
                    StringBuilder nonPredatorsCount = new StringBuilder("│O:" + map.GetTileAt(new Position(j, i)).GetNumberOfNonPredators());
                    while (nonPredatorsCount.Length < 7)
                    {
                        nonPredatorsCount.Append(" ");
                    }
                    output.Append(nonPredatorsCount);
                }
                output.Append("│\n");
                if(i == map.Height - 1)
                {
                    for (int j = 0; j < map.Width; j++)
                    {
                        output.Append("┼──────");
                    }
                    output.Append("┼\n");
                }
            }
            Console.WriteLine(output);
            return true;
        }
    }
}
