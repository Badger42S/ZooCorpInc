using System;

namespace Employee
{
    public class Veterinarian : IEmployee
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string AnimalExperiences { get; set; }
        public void AddAnimalExperience (Animal animal) { }
        public bool HasAnimalExperience(Animal animal) { }
        public bool HealAnimal(Animal animal) { }
    }
}
