using System;
using WildLifeSimulation.Animals;
using WildLifeSimulation.World;

namespace WildLifeSimulation
{
    class Reporter
    {
        private bool report;

        public Reporter(bool report)
        {
            this.report = report;
        }
        public Reporter() : this(true) { }

        public void ReportDeath(Animal animal)
        {
            if (report)
            {
                Console.WriteLine(animal.GetType().Name + " died at " + animal.Position + ".");
            }
        }

        public  void ReportBirth(Animal animal)
        {
            if (report)
            {
                Console.WriteLine("new " + animal + " was born at " + animal.Position + ".");
            }
        }

        public void ReportHuntedPrey(Animal hunter, Animal prey)
        {
            if (report)
            {
                Console.WriteLine(prey + " hunted by " + hunter + " at " + hunter.Position + ".");
            }
        }

        public void ReportMove(Animal animal, Position previousPosition)
        {
            if (report)
            {
                Console.WriteLine(animal + " moved from " + animal.Position + " to " + previousPosition);
            }
        }
    }
}
