using System;

namespace WildLifeSimulation.GameStates
{
    class MenuGameState : GameState
    {
        SimulationSettings settings;

        public MenuGameState()
        {
            settings = new SimulationSettings();
        }

        public override GameState Main()
        { 
            return HandleMenu();
        }

        private GameState HandleMenu()
        {
            DisplayMenu();

            bool correctInput = false;
            while (!correctInput)
            {
                char choosenOption = Console.ReadKey().KeyChar;
                switch (choosenOption)
                {
                    case '1':
                        return new SimulationGameState(settings);
                    case '2':
                        DisplayInfo();
                        return HandleMenu();
                    case '3':
                        DisplaySettings();
                        return HandleMenu();
                    case '4':
                        return new EndGameState();
                    default:
                        Console.WriteLine("Please, select any existing option.");
                        break;
                }
            }
            return new EndGameState();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nWild Life Simulation");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Info");
            Console.WriteLine("3. Settings");
            Console.WriteLine("4. Exit");
        }

        private void DisplaySettings()
        {
            Console.WriteLine("\nSettings:");
            Console.WriteLine(settings);
            Console.WriteLine("\n1. change settings");
            Console.WriteLine("2. return to main menu");

            bool correctInput = false;
            while (!correctInput)
            {
                char choosenOption = Console.ReadKey().KeyChar;
                switch (choosenOption)
                {
                    case '1':
                        ChangeSettings();
                        correctInput = true;
                        break;
                    case '2':
                        return;
                    default:
                        Console.WriteLine("Please, select any existing option");
                        break;
                }
            }

        }

        private void ChangeSettings()
        {
            int setting = 0;
            Console.WriteLine("\nChange settings: ");

            Console.Write("map width [int]: ");
            try
            {
                setting = Convert.ToInt32(Console.ReadLine());
                settings.MapWidth = setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("map height [int]: ");
            try
            {
                setting = Convert.ToInt32(Console.ReadLine());
                settings.MapHeight = setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("predators hp [int]: ");
            try
            {
                setting = Convert.ToInt32(Console.ReadLine());
                settings.PredatorsHp = setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("maximum number of turns [int]: ");
            try
            {
                setting = Convert.ToInt32(Console.ReadLine());
                settings.MaxTurnsCount = setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("initial number of animals: [int]: ");
            try
            {
                setting = Convert.ToInt32(Console.ReadLine());
                settings.InitialAnimalNumber = setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("predators to all animals ratio [float]: ");
            try
            {
                float predatorsRatio = (float)Convert.ToDouble(Console.ReadLine());
                settings.InitialPredatorsRatio = predatorsRatio;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("should program report moves, births and deaths? [true/false]: ");
            try
            {
                bool report = Convert.ToBoolean(Console.ReadLine());
                settings.Report = report;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void DisplayInfo()
        {
            Console.WriteLine(  "\nWild Life Simulation - program that simulates the ruthless " +
                                "\nstruggle to survive in the heart of the African wilderness." +
                                "\nThe rules are simply:" +
                                "\n - every animal on the map moves to the adjacent tile every turn," +
                                "\n - two animals at the same tile that are the same species and diffrent gender can reproduce," +
                                "\n - every animal can reproduce only once a turn," +
                                "\n - predators hunt helpless herbivores," +
                                "\n - predators hp specify how many turns predator can live without eating" +
                                "\n - simulation ends once all predators extinct or specified number of turns will take place");
            Console.WriteLine("\nHow to read map: ");
            Console.WriteLine(SimulationPhases.DrawingMapPhase.GetLegend());
        }
    }
}
