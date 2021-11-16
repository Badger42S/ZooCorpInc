using Animals;
using ZooApps.Enclousers;
using ZooApps.Exceptions;
using System;
using System.Collections.Generic;
using ZooApps.Employee;
using ZooApps.Validators;
using System.Linq;

namespace ZooApps.Zoos
{
    public class Zoo
    {
        public string Location { get; private set; }
        public List<Enclouser> Enclouseres { get; private set; } = new() { };
        public List<IEmployee> Employees { get; private set; } = new() { };
        public HashSet<string> AnimalsType { get; private set; } = new () { };
        private HireValidatorProvider ValidatorProvider { get; set; }

        public Zoo(string location)
        {
            Location = location;
            ValidatorProvider = new HireValidatorProvider();
        }

        public void AddEnclouser(string name, int squareFeet)
        {
            var enclouser = new Enclouser(name, Location, squareFeet);
            Enclouseres.Add(enclouser);
            Console.WriteLine($"Enclose {name} was added to zoo in {this.Location}");
        }

        public Enclouser FindAvailableEnclouser(Animal animal)
        {
            Enclouser availableEnclouser = null;

            foreach (var enclousere in Enclouseres)
            {
                try
                {
                    enclousere.AddAnimals(animal);
                    AnimalsType.Add(animal.GetType().Name);
                    availableEnclouser = enclousere;
                    break;
                }
                catch { }
            }

            if(availableEnclouser is null)
            {
                throw new NoAvailableEnclouserException();
            }

            return availableEnclouser;                
        }

        public void HireEmployee(IEmployee employee)
        {
            var validator = ValidatorProvider.GetHireValidator(employee, AnimalsType);
            var errorsList = validator.ValidateEmployee(employee);
            if (errorsList.Count != 0)
            {
                throw new NoNeededExperienceException();
            }
            Employees.Add(employee);
            Console.WriteLine($"{employee.LastName} {employee.FirstName} was hired as a {employee.GetType().Name}");
        }
        
        public void FeedAnimals(DateTime dateTime)
        {
            var animalDictionary = new Dictionary<string, List<Animal>>();
            foreach (var enclousere in Enclouseres)
            {
                foreach (var animal in enclousere.Animals)
                {
                    var animalType = animal.GetType().Name;
                    if (!animalDictionary.ContainsKey(animalType))
                    {
                        animalDictionary.Add(animalType, new List<Animal>() { });
                    }
                    animalDictionary[animalType].Add(animal);

                }
            }

            var zooKeepersList = Employees.Where(employee => employee.GetType().Name == "ZooKeeper").Cast<ZooKeeper>().ToList();
            foreach (var animalType in AnimalsType)
            {
                var suitableZooKeepers = new Queue<ZooKeeper>(
                    zooKeepersList.Where(employee => employee.HasAnimalExperience(animalType)));
                foreach(var animal in animalDictionary[animalType])
                {
                    foreach (var scheduleNote in animal.FeedSchedule)
                    {
                        int fedCount = 0;
                        for(int i= animal.FeedTimes.Count - 1; i >= 0; i--)
                        {
                            if(animal.FeedTimes[i].FeedTimeNote.Day != dateTime.Day)
                            {
                                break;
                            }
                            fedCount += 1;
                        }
                        bool isWasFedTwice = fedCount > 1;
                        bool isTimeToEat = dateTime.Hour > scheduleNote;
                        if (isTimeToEat && !isWasFedTwice)
                        {
                            var feedingZooKeeper = suitableZooKeepers.Dequeue();
                            feedingZooKeeper.FeedAnimal(animal, dateTime);
                            suitableZooKeepers.Enqueue(feedingZooKeeper);
                            break;
                        }
                    }
                }
            }
        }

        public void HealAnimals()
        {
            var veterinarian = (Veterinarian)Employees.First(employee => employee.GetType().Name == "Veterinarian");
            foreach (var enclousere in Enclouseres)
            {
                foreach (var animal in enclousere.Animals)
                {
                    if (veterinarian.HasAnimalExperience(animal.GetType().Name))
                    {
                        veterinarian.HealAnimal(animal);
                    }
                }
            }
        }
    }
}
