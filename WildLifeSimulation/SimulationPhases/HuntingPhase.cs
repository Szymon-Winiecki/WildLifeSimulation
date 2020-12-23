using System;
using System.Collections.Generic;
using WildLifeSimulation.Animals;
using WildLifeSimulation.World;

namespace WildLifeSimulation.SimulationPhases
{
    class HuntingPhase : SimulationPhase
    {
        public HuntingPhase(Map map) : base(map) { }
        public override bool Main()
        {
            Console.WriteLine();

            List<Animal> predators = map.GetAllPredators();
            if(predators.Count == 0)
            {
                return false;
            }

            foreach(Animal animal in predators)
            {
                Predator predator = animal as Predator;
                predator.Hunt();
            }
            return true;
        }
    }
}
