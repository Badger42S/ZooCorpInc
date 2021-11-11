using Animals;
using System;
using Medicines;

namespace Employee
{
    public class Veterinarian : IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AnimalExperience { get; private set; }
        public Veterinarian(string firstName, string lastName, string animalExperience ="")
        {
            AnimalExperience = animalExperience;
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddAnimalExperience(Animal animal)
        {
            var type = animal.GetType();
            AnimalExperience = type.Name + ",";
            Console.WriteLine($"{FirstName} {LastName} knows how to handle {type.Name}s now");
        }

        public bool HasAnimalExperience(string name)
        {
            return AnimalExperience.Contains(name);
        }

        public bool HealAnimal(Animal animal)
        {
            var type = animal.GetType();
            var animalName = type.Name;
            if (animal.IsSick && HasAnimalExperience(animalName)) 
            {
                Antibiotics antibiotics = new Antibiotics();
                animal.Heal(antibiotics);
            }
            return animal.IsSick;
        }
    }
}
