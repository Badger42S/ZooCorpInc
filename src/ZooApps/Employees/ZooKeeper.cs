using Animals;
using System;
using ZooApps.Foods;

namespace ZooApps.Employee
{
    public class ZooKeeper: IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AnimalExperience { get; private set; }
        public ZooKeeper(string firstName, string lastName, string animalExperience ="")
        {
            FirstName = firstName;
            LastName = lastName;
            AnimalExperience = animalExperience;
        }

        public void AddAnimalExperience(Animal animal)
        {
            var type = animal.GetType();
            AnimalExperience = type.Name + ",";
        }

        public bool HasAnimalExperience(string name)
        {
            return AnimalExperience.Contains(name);
        }

        public bool FeedAnimal(Animal animal, DateTime dateTime)
        {
            //randome food
            var random = new Random().Next(0, 2);
            var foodArray = new Food[] { new Meet(), new Grass(), new Vegetable() };
            var food = foodArray[random];
            var animalType = animal.GetType();
            var animalTypeName = animalType.Name;
            bool hasAnimalExperience = HasAnimalExperience(animalTypeName);
            if (hasAnimalExperience)
            {
                animal.Feed(food, dateTime, this);
                return true;
            }
            else
            {
                return false;
            }          
        }
    }
}
