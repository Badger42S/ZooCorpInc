using Animals;
using Animals.Bird;
using System;
using System.Collections.Generic;
using Xunit;
using ZooApps.Employee;

namespace AnimalsTests
{
    public class FeedTimeTest
    {
        [Fact]
        public void ShouldBeContainZooKeeper()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            string animalExperience = typeof(Penguin).Name;
            var zooKeeper = new ZooKeeper(firstName, lastName, animalExperience);
            var penguin = new Penguin();
            var dateTime = new DateTime(2020, 9, 5, 12, 0, 0);
            Assert.True(zooKeeper.FeedAnimal(penguin, dateTime));
            Assert.Equal(zooKeeper, penguin.FeedTimes[0].FeedByZooKeeper);
        }
        [Fact]
        public void ShouldBeCorrectTime()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            string animalExperience = typeof(Penguin).Name;
            var zooKeeper = new ZooKeeper(firstName, lastName, animalExperience);
            var penguin = new Penguin();
            var dateTime = new DateTime(2020, 9, 5, 12, 0, 0);
            Assert.True(zooKeeper.FeedAnimal(penguin, dateTime));
            Assert.Equal(dateTime.Hour, penguin.FeedTimes[0].FeedTimeNote.Hour);
        }
    }
}
