using System;
using System.Collections.Generic;
using System.Text;

namespace WildLifeSimulation.Animals
{
    enum Gender
    {
        Male,
        Female
    }
    class Animal
    {
        protected Gender Gender
        { get; set; }

        protected void Move() { }
        protected void Breed() { }
        protected void Die() { }
    }
}
