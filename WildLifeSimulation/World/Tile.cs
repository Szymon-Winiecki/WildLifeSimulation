using System;
using System.Collections.Generic;
using WildLifeSimulation.Animals;

namespace WildLifeSimulation.World
{
    class Tile
    {
        private List<Animal> nonPredotors;
        private List<Predator> predators;

        private Map map;

        public List<Animal> NonPredators
        { get { return nonPredotors; } }
        public List<Predator> Predators
        { get { return predators; } }

        public Tile(Map map)
        {
            this.map = map;
            nonPredotors = new List<Animal>();
            predators = new List<Predator>();
        }

        public Animal FindPartner(Type species, Gender partnerGender)
        {
            if (species.IsSubclassOf(typeof(Predator)))
            {
                foreach (Predator predator in predators)
                {
                    if (predator.GetType() == species && predator.Gender == partnerGender && predator.IsAbleToBreed)
                        return predator;
                }
            }
            else
            {
                foreach (Animal animal in nonPredotors)
                {
                    if (animal.GetType() == species && animal.Gender == partnerGender && animal.IsAbleToBreed)
                        return animal;
                }
            }
            
            return null;
        }

        public Animal GetAnyNonPredator()
        {
            if(nonPredotors.Count > 0)
            {
                return nonPredotors[0];
            }
            return null;
        }

        public void AddAnimal(Animal animal, bool affectGlobalList)
        {
            if(animal == null)
            {
                Console.WriteLine("animal cannot be null");
                return;
            }
            
            if (animal.GetType().IsSubclassOf(typeof(Predator))){
                predators.Add(animal as Predator);
                if (affectGlobalList)
                {
                    map.allPredators.Add(animal as Predator);
                }
            }
            else
            {
                nonPredotors.Add(animal);
                if (affectGlobalList)
                {
                    map.allNonPredators.Add(animal);
                }
            }
        }

        public void RemoveAnimal(Animal animal, bool affectGlobalList)
        {
            if (animal == null)
            {
                Console.WriteLine("animal cannot be null");
                return;
            }
            
            if (animal.GetType().IsSubclassOf(typeof(Predator))){
                predators.Remove(animal as Predator);
                if (affectGlobalList)
                {
                    map.allPredators.Remove(animal as Predator);
                }
            }
            else
            {
                nonPredotors.Remove(animal);
                if (affectGlobalList)
                {
                    map.allNonPredators.Remove(animal);
                }
            }
        }
    }
}
