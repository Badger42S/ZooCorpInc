﻿using FeedTimeNotes;
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
        public List<FeedTime> FeedTimes { get; set; } = new();
        public int ID { get; }
        

        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }
        public Animal(int id)
        {
            ID = id;
        }
        public abstract bool IsFriendlyWithAnimal(Animal animal);

        public void AddSchedule(List<int> moreFeedTimes)
        {
            FeedSchedule = moreFeedTimes;
            FeedSchedule.Sort();
        }

        public void Feed(Food food)
        {
            
        }
    }
}
