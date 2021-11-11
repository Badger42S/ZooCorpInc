using Foods;
using Medicines;
using System;
using System.Collections.Generic;

namespace Animals
{
    public abstract class Animal
    {
        public bool IsSick { get; private set; } = true;
        public List<int> FeedSchedule { get; private set; }
        public List<FeedTime> FeedTimes { get; private set; }
        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }

        public void Feed(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
