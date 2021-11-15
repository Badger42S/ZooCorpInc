﻿using Animals;
using ZooApps.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooApps.Enclousers
{
    public class Enclouser
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; } = new() { };
        public string ParentZoo { get; private set; }
        public int SqureFeet { get; private set; }
        public Enclouser(string name, string parentZoo, int squreFeet) 
        {
            Name = name;
            ParentZoo = parentZoo;
            SqureFeet = squreFeet;
        }
        public void AddAnimals(Animal animal) 
        {
            if(SqureFeet - animal.RequiredSpaceSqFt < 0)
            {
                throw new NoAvalibaleSpaceException();
            }
            foreach(var heldAnimal in Animals)
            {
                if (!heldAnimal.IsFriendlyWithAnimal(animal))
                {
                    throw new NotFriendlyAnimalException();
                }
            }
            
            Animals.Add(animal);
            SqureFeet -= animal.RequiredSpaceSqFt;
        }
    }
}
