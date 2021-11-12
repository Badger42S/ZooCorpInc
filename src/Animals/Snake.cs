﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Snake:Reptile
    {
        public override string[] FavoriteFood { get; } = new string[] { "mouse", "bird" };
        public override int RequiredSpaceSqFt { get; } = 2;
        public Snake(int id) : base(id) { }

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string notCompatibility = "lion, bison, parrot, penguin";
            string animalType = animal.GetType().Name.ToLower();
            return !notCompatibility.Contains(animalType);
        }
    }
}
