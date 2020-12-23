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
        public static List<Type> GetAvailableSpecies()
        {
            return availableSpecies;
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
            map.GetTileAt(position).RemoveAnimal(this);

            position.ChangePosition(MotionVector.RandomWithLimitations(position, map));
            map.GetTileAt(position).AddAnimal(this);

            reporter.ReportMove(this, oldPosition);

            isAbleToBreed = true;
        }
        public void FindPartner() 
        {
            Gender partnerGender = (this.Gender == Gender.Male) ? (Gender.Female) : (Gender.Male);
            Animal partner = map.GetTileAt(position).FindPartner(this.GetType(), partnerGender);
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
            map.GetTileAt(position).AddAnimal(baby);
            reporter.ReportBirth(baby);
        }
        public virtual void Die()
        {
            map.GetTileAt(position).RemoveAnimal(this);
        }

        public override string ToString() => this.Gender + " " + this.GetType().Name;
    }
}
