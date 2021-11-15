﻿using FeedTimeNotes;
using ZooApps.Foods;
using ZooApps.Medicines;
using System;
using System.Collections.Generic;
using ZooApps.Employee;

namespace Animals
{
    public abstract class Animal
    {
        public abstract string[] FavoriteFood { get; }
        public abstract int RequiredSpaceSqFt { get; }
        public bool IsSick { get; private set; } = true;
        public List<int> FeedSchedule { get; private set; } = new() { 12 };
        public List<FeedTime> FeedTimes { get; private set; } = new();
        public int ID { get; private set; }
        

        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }
        public Animal()
        {
            var random = new Random();
            int randomId = random.Next(0, int.MaxValue);
            ID = randomId;
        }
        public abstract bool IsFriendlyWithAnimal(Animal animal);

        public void AddSchedule(List<int> moreFeedTimes)
        {
            FeedSchedule = moreFeedTimes;
            FeedSchedule.Sort();
        }

        public void Feed(Food food, DateTime dateTime, ZooKeeper zooKeeper)
        {
            var foodName = food.GetType().Name;
            bool isFedBadFood = true;
            foreach(var favoriteFood in FavoriteFood)
            {
                if(favoriteFood == foodName)
                {
                    isFedBadFood = false;
                    break;
                }
            };
            var fedTime = new FeedTime(dateTime, zooKeeper);
            IsSick = isFedBadFood;
            FeedTimes.Add(fedTime);
        }
    }
}