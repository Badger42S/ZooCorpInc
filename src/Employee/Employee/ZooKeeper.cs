using Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
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
            Console.WriteLine($"{FirstName} {LastName} knows how to handle {type.Name}s now");
        }

        public bool HasAnimalExperience(string name)
        {
            return AnimalExperience.Contains(name);
        }

        public bool FeedAnimal(Animal animal)
        {
            var type = animal.GetType();
            var typeName = type.Name;
            bool feedAnimalResult = HasAnimalExperience(typeName);
            if (feedAnimalResult)
            {
                Console.WriteLine($"{FirstName} {LastName} fed {typeName}");
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName} can't feed {typeName}");
            }
            return feedAnimalResult;
        }
    }
}
