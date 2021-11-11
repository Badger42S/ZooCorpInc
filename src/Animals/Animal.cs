using FeedTimeNotes;
using Foods;
using Medicines;
using System;
using System.Collections.Generic;

namespace Animals
{
    public abstract class Animal
    {
        public bool IsSick { get; private set; } = true;
        public List<int> FeedSchedule { get; private set; } = new() { 12 };
        public List<FeedTime> FeedTimes { get; set; } = new();
        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }

        public void Feed(Food food)
        {
            
        }
    }
}
