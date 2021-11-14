using Animals;
using Enclousers;
using Exceptions;
using System;
using System.Collections.Generic;
using Employee;
using Validators;
using System.Linq;

namespace Zoos
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
        }
        
        public void FeedAnimals(DateTime dateTime)
        {
            var zooKeepersList = Employees.Where(employee => employee.GetType().Name == "ZooKeeper");
            foreach (var animalType in AnimalsType)
            {
                var suitableZooKeepers = new Queue<ZooKeeper>();
                foreach (var keepers in zooKeepersList) 
                {
                    suitableZooKeepers.Enqueue((ZooKeeper)keepers);
                }
                foreach (var enclousere in Enclouseres)
                {
                    foreach (var animal in enclousere.Animals)
                    {
                        if(animal.GetType().Name == animalType)
                        {
                            foreach (var scheduleNote in animal.FeedSchedule)
                            {
                                if (dateTime.Hour > scheduleNote)
                                {
                                    var feedingZooKeeper = suitableZooKeepers.Dequeue();
                                    feedingZooKeeper.FeedAnimal(animal);
                                    suitableZooKeepers.Enqueue(feedingZooKeeper);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
