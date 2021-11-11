using System;

namespace FeedTimeNotes
{
    public class FeedTime
    {
        public DateTime FeedTimeNote;
        public string ZooKeeperFirstName;
        public string ZooKeeperLastName;

        public FeedTime(DateTime timeNow, string lastName, string firstName)
        {
            FeedTimeNote = timeNow;
            ZooKeeperLastName = lastName;
            ZooKeeperFirstName = firstName;
        }
    }
}
