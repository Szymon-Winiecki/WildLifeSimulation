using System;
using WildLifeSimulation.World;

namespace WildLifeSimulation.Animals
{
    class Predator : Animal
    {
        protected int maxHealthPoints;
        protected int actualHealthPoints;

        public Predator(Map map, Gender gender, Position position, int maxHp, Reporter reporter) : base(map, gender, position, reporter)
        {
            this.maxHealthPoints = maxHp;
            this.actualHealthPoints = maxHp;
        }
        public bool Hunt() 
        {
            Animal prey = map.GetTileAt(position).GetAnyNonPredator();
            if (prey == null)
            {
                actualHealthPoints--;
                if(actualHealthPoints == 0)
                {
                    Die();
                    return false;
                }
            }
            else
            {
                Eat(prey);
            }
            return true;
        }
        protected void Eat(Animal prey) 
        {
            prey.Die();
            actualHealthPoints = maxHealthPoints;
            reporter.ReportHuntedPrey(this, prey);
        }

        public override void Die()
        {
            base.Die();
            reporter.ReportDeath(this);
        }

        protected override void giveBirth(Gender babyGender)
        {
            Animal baby = (Animal)Activator.CreateInstance(this.GetType(), this.map, babyGender, new Position(this.position), this.maxHealthPoints, reporter);
            Tile tile = map.GetTileAt(position);
            if (tile == null)
            {
                Console.WriteLine("Baby cannot be born at not existing tile");
                return;
            }
            if(baby == null)
            {
                Console.WriteLine("something went wrong in childbirth");
                return;
            }
            tile.AddAnimal(baby, true);
            reporter.ReportBirth(baby);
        }
    }
}
