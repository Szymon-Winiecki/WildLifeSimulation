using System;

namespace WildLifeSimulation
{
    class SimulationSettings
    {
        private int mapWidth, mapHeight, predatorsHp, maxTurnsCount, initialAnimalNumber;
        private float initialPredatorsRatio;
        private bool report;
        public int MapWidth
        {
            get { return mapWidth; }
            set
            {
                if (value > 0)
                    mapWidth = value;
                else
                    throw new ArgumentException("Map width has to be a positive integer.");
            }
        }
        public int MapHeight
        {
            get { return mapHeight; }
            set
            {
                if (value > 0)
                    mapHeight = value;
                else
                    throw new ArgumentException("Map height has to be a positive integer.");
            }
        }
        public int PredatorsHp
        {
            get { return predatorsHp; }
            set
            {
                if (value > 0)
                    predatorsHp = value;
                else
                    throw new ArgumentException("Predators hp has to be a positive integer.");
            }
        }
        public int MaxTurnsCount
        {
            get { return maxTurnsCount; }
            set
            {
                if (value > 0)
                    maxTurnsCount = value;
                else
                    throw new ArgumentException("Maximum turns number has to be a positive integer.");
            }
        }
        public int InitialAnimalNumber
        {
            get { return initialAnimalNumber; }
            set
            {
                if (value > 0)
                    initialAnimalNumber = value;
                else
                    throw new ArgumentException("Initial animal number has to be a positive integer.");
            }
        }
        public float InitialPredatorsRatio
        {
            get { return initialPredatorsRatio; }
            set
            {
                if (value > 0)
                    initialPredatorsRatio = value;
                else
                    throw new ArgumentException("Predators ratio has to be a positive integer.");
            }
        }

        public bool Report 
        {
            get { return report; }
            set
            {
                report = value;
            }
        }


        public SimulationSettings(int mapWidth, int mapHeight, int predatorsHp, int maxTurnsCount, int initialAnimalNumber, float initialPredatorsRatio, bool report)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            PredatorsHp = predatorsHp;
            MaxTurnsCount = maxTurnsCount;
            InitialAnimalNumber = initialAnimalNumber;
            InitialPredatorsRatio = initialPredatorsRatio;
            Report = report;
        }

        public SimulationSettings() : this(6, 6, 2, 20, 400, 0.2f, true) { }

        public override string ToString()
        {
            string output =
                "map width: " + MapWidth + "\n" +
                "map height: " + MapHeight + "\n" +
                "predators hp: " + PredatorsHp + "\n" +
                "maximum number of turns: " + MaxTurnsCount + "\n" +
                "initial number of animals: " + InitialAnimalNumber + "\n" +
                "predators to all animals ratio: " + InitialPredatorsRatio + "\n" +
                "should program report moves, births and deaths? " + Report + "\n";

            return output;
        }
    }
}
