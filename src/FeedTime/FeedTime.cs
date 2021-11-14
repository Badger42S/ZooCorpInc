using System;

namespace FeedTimeNotes
{
    public class FeedTime
    {
        public DateTime FeedTimeNote;
        public string ZooKeeperFirstName;
        public string ZooKeeperLastName;

        public FeedTime(DateTime fedTime, string lastName, string firstName)
        {
            FeedTimeNote = fedTime;
            ZooKeeperLastName = lastName;
            ZooKeeperFirstName = firstName;
        }
    }
}
