using System;
using System.Collections.Generic;
using WildLifeSimulation.World;
using WildLifeSimulation.Animals;

namespace WildLifeSimulation.SimulationPhases
{
    class MovingPhase : SimulationPhase
    {
        public MovingPhase(Map map) : base(map) { }
        public override bool Main()
        {
            Console.WriteLine();

            List<Animal> animals = map.GetAllAnimals();
            if(animals.Count == 0)
            {
                return false;
            }

            foreach (Animal animal in animals)
            {
                animal.Move();
            }
            return true;
        }
    }
}
