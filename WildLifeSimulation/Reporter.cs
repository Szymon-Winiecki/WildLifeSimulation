using System;
using WildLifeSimulation.Animals;
using WildLifeSimulation.World;

namespace WildLifeSimulation
{
    class Reporter
    {
        public void ReportDeath(Animal animal)
        {
            Console.WriteLine(animal.GetType().Name + " died at " + animal.Position + ".");
        }

        public void ReportBirth(Animal animal)
        {
            Console.WriteLine("new " + animal + " was born at " + animal.Position + ".");
        }

        public void ReportHuntedPrey(Animal hunter, Animal prey)
        {
            Console.WriteLine(prey + " hunted by " + hunter + " at " + hunter.Position + ".");
        }

        public void ReportMove(Animal animal, Position previousPosition)
        {
            Console.WriteLine(animal + " moved from " + animal.Position + " to " + previousPosition);
        }
    }
}
