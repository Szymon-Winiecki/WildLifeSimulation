using System;
using System.Collections.Generic;
using WildLifeSimulation.Animals;

namespace WildLifeSimulation.World
{
    class Tile
    {
        private List<Animal> animals;
        public List<Animal> Animals
        { get { return animals; } }

        public Tile()
        {
            animals = new List<Animal>();
        }

        public int GetNumberOfAnimals()
        {
            return animals.Count;
        }
        public int GetNumberOfPredators()
        {
            int counter = 0;
            foreach (Animal animal in animals)
            {
                if (animal is Predator)
                    counter++;
            }
            return counter;
        }
        public int GetNumberOfNonPredators()
        {
            int counter = 0;
            foreach (Animal animal in animals)
            {
                if (animal is Animal && !(animal is Predator))
                    counter++;
            }
            return counter;
        }

        public Animal FindPartner(Type species, Gender partnerGender)
        {
            foreach (Animal animal in animals)
            {
                if (animal.GetType() == species && animal.Gender == partnerGender && animal.IsAbleToBreed)
                    return animal;
            }
            return null;
        }

        public Animal GetAnyNonPredator()
        {
            foreach (Animal animal in animals)
            {
                if (!(animal is Predator))
                    return animal;
            }
            return null;
        }


        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }
        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
        }

        public bool ContainsAnimal(Animal animal)
        {
            return animals.Contains(animal);
        }
    }
}
