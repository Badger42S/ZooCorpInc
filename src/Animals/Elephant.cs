﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Elephant:Mammal
    {
        public override string[] FavoriteFood { get; } = new string[] { "grass", "vegetable" };
        public override int RequiredSpaceSqFt { get; } = 1000;
        public Elephant(int id) : base(id) { }
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Bison, Parrot, Turtle";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }
    }
}
