using System;
using System.Collections.Generic;
using WildLifeSimulation.Animals;
using WildLifeSimulation.World;

namespace WildLifeSimulation.SimulationPhases
{
    class BreedingPhase : SimulationPhase
    {
        public BreedingPhase(Map map) : base(map){}
        public override bool Main()
        {
            Console.WriteLine();

            List<Animal> animals = map.GetAllAnimals();

            foreach(Animal animal in animals)
            {
                animal.FindPartner();
            }

            return true;
        }
    }
}
