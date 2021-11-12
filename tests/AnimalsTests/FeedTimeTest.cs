using Animals;
using Employee;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
    public class FeedTimeTest
    {
        [Fact]
        public void ShouldBeCreateFeedTimeNote()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            string animalExperience = typeof(Penguin).Name;
            var zooKeeper = new ZooKeeper(firstName, lastName, animalExperience);
            Penguin penguin = new Penguin();
            Assert.True(zooKeeper.FeedAnimal(penguin));
            Assert.Matches(firstName, penguin.FeedTimes[0].ZooKeeperFirstName);
            Assert.Matches(lastName, penguin.FeedTimes[0].ZooKeeperLastName);
        }
    }
}
