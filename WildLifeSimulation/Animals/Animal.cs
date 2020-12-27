using System;
using System.Collections.Generic;
using WildLifeSimulation.World;
using System.Linq;

namespace WildLifeSimulation.Animals
{
    public enum Gender
    {
        Male,
        Female
    }
    class Animal
    {
        private static readonly List<Type> availableSpecies = new List<Type> {
            typeof(Lion),
            typeof(Zebra),
            typeof(Antelope)
        };

        protected Map map;
        protected Reporter reporter;

        protected Gender gender;
        protected bool isAbleToBreed;
        protected Position position;

        protected Random randomGenerator;

        public Gender Gender
        {
            get { return gender; }
        }
        public bool IsAbleToBreed
        {
            get { return isAbleToBreed; }
        }
        public Position Position 
        {
            get { return position; }
        }
        public static List<Type> GetAvailableSpecies(bool predators)
        {
            return availableSpecies.Where(species => species.IsSubclassOf(typeof(Predator)) == predators).ToList();
        }


        public Animal(Map map, Gender gender, Position position, Reporter reporter)
        {
            isAbleToBreed = false;
            this.gender = gender;
            this.position = position;
            this.map = map;
            this.reporter = reporter;
            randomGenerator = new Random();
        }

        public void Move() 
        {
            Position oldPosition = new Position(this.Position);
            Tile tile = map.GetTileAt(position);
            if(tile == null)
            {
                Console.WriteLine("That's strange, animal lives at not existing tile");
                return;
            }
            tile.RemoveAnimal(this, false);

            position.ChangePosition(MotionVector.RandomWithLimitations(position, map));
            tile = map.GetTileAt(position);
            if (tile == null)
            {
                Console.WriteLine("Animal cannot move to not existing location");
                return;
            }
            tile.AddAnimal(this, false);

            reporter.ReportMove(this, oldPosition);

            isAbleToBreed = true;
        }
        public void FindPartner() 
        {
            Gender partnerGender = (this.Gender == Gender.Male) ? (Gender.Female) : (Gender.Male);
            Tile tile = map.GetTileAt(position);
            if (tile == null)
            {
                Console.WriteLine("That's strange, animal lives at not existing tile");
                return;
            }

            Animal partner = tile.FindPartner(this.GetType(), partnerGender);
            if(partner == null)
            {
                return;
            }

            partner.Breed();
            this.Breed();
        }
        public void Breed() 
        {
            isAbleToBreed = false;
            if(Gender == Gender.Male)
            {
                return;
            }

            int randomForGender = randomGenerator.Next(2);
            Gender babyGender = (randomForGender == 0) ? (Gender.Male) : (Gender.Female);

            giveBirth(babyGender);
        }

        protected virtual void giveBirth(Gender babyGender)
        {
            Animal baby = (Animal)Activator.CreateInstance(this.GetType(), this.map, babyGender, new Position(this.position), reporter);
            Tile tile = map.GetTileAt(position);
            if (tile == null)
            {
                Console.WriteLine("Baby cannot be born at not existing tile");
                return;
            }
            if (baby == null)
            {
                Console.WriteLine("something went wrong in childbirth");
                return;
            }
            tile.AddAnimal(baby, true);
            reporter.ReportBirth(baby);
        }
        public virtual void Die()
        {
            Tile tile = map.GetTileAt(position);
            if (tile == null)
            {
                Console.WriteLine("That's strange, animal tries to die at not existing tile");
                return;
            }
            tile.RemoveAnimal(this, true);
        }

        public override string ToString() => this.Gender + " " + this.GetType().Name;
    }
}
