using Animals;
using System;
using System.Collections.Generic;
using Zoos;

namespace Enclousers
{
    public class Enclouser
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; } = new() { };
        public Zoo ParentZoo { get; private set; }
        public int SqureFeet { get; private set; }
        public Enclouser(string name, Zoo zoo, int squreFeet) 
        {
            Name = name;
            ParentZoo = zoo;
            SqureFeet = squreFeet;
        }
        public void AddAnimals(Animal animal) 
        {
            Animals.Add(animal);
        }
    }
}
