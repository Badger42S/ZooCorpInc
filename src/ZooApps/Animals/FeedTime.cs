using System;
using ZooApps.Employee;

namespace FeedTimeNotes
{
    public class FeedTime
    {
        public DateTime FeedTimeNote;
        public ZooKeeper FeedByZooKeeper;

        public FeedTime(DateTime fedTime, ZooKeeper zooKeeper)
        {
            FeedTimeNote = fedTime;
            FeedByZooKeeper = zooKeeper;
        }
    }
}
