using FeedTimeNotes;
using Foods;
using Medicines;
using System;
using System.Collections.Generic;

namespace Animals
{
    public abstract class Animal
    {
        public abstract string[] FavoriteFood { get; }
        public abstract int RequiredSpaceSqFt { get; }
        public bool IsSick { get; private set; } = true;
        public List<int> FeedSchedule { get; private set; } = new() { 12 };
        public List<FeedTime> FeedTimes { get; private set; } = new();
        public int ID { get; set; }
        

        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }
        public Animal()
        {
           
        }
        public abstract bool IsFriendlyWithAnimal(Animal animal);

        public void AddSchedule(List<int> moreFeedTimes)
        {
            FeedSchedule = moreFeedTimes;
            FeedSchedule.Sort();
        }

        public void Feed(Food food, string lastName, string firstName)
        {
            var todayDate = DateTime.Now;
            var fedTime = new FeedTime(todayDate, lastName, firstName);
            FeedTimes.Add(fedTime);
        }
    }
}
