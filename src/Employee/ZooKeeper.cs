using Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foods;
using FeedTimeNotes;

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
        }

        public bool HasAnimalExperience(string name)
        {
            return AnimalExperience.Contains(name);
        }

        public bool FeedAnimal(Animal animal)
        {
            var type = animal.GetType();
            var typeName = type.Name;
            bool hasAnimalExperience = HasAnimalExperience(typeName);
            if (hasAnimalExperience)
            {
                var timeNow = new DateTime(2021, 7, 20, 18, 30, 25);
                int fedTodayCount = 0;
                if(animal.FeedTimes.Count > 2)
                {
                    for (int ind = animal.FeedTimes.Count - 1; ind >= 0; ind--)
                    {
                        if (animal.FeedTimes[ind].FeedTimeNote.Date == timeNow.Date)
                        {
                            fedTodayCount += 1;
                        }
                        if (fedTodayCount > 2 || animal.FeedTimes[ind].FeedTimeNote.Date != timeNow.Date)
                        {
                            break;
                        }
                    }
                }
                bool shouldBeFeed = fedTodayCount < 2 ? true : false;

                bool timeToEat = false;
                foreach (var scheduleNote in animal.FeedSchedule)
                {
                    timeToEat = timeNow.Hour > scheduleNote;
                }

                bool wasFed = false;
                if(shouldBeFeed && timeToEat)
                {
                    Meet meet = new Meet();
                    animal.FeedTimes.Add(new FeedTime(timeNow, LastName, FirstName));
                    wasFed = true;
                }
                
                return wasFed;
            }
            else
            {
                return false;
            }          
        }
    }
}
