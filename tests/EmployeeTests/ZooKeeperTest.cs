using Xunit;
using Animals.Bird;
using ZooApps.Employee;
using System;

namespace EmployeeTests
{
    public class ZooKeeperTest
    {
        [Fact]
        public void ShouldAddExperience()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            var zooKeeper = new ZooKeeper(firstName, lastName);
            var penguin = new Penguin();
            zooKeeper.AddAnimalExperience(penguin);
            Assert.Contains(typeof(Penguin).Name, zooKeeper.AnimalExperience);
        }
        [Fact]
        public void ShouldHasExperience()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            string animalExperience = typeof(Penguin).Name;
            var zooKeeper = new ZooKeeper(firstName, lastName, animalExperience);
            Assert.True(zooKeeper.HasAnimalExperience(animalExperience));
        }
        [Fact]
        public void ShouldCreateZooKeeper()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            ZooKeeper zooKeeper = new ZooKeeper(firstName, lastName);
            Assert.Equal(firstName, zooKeeper.FirstName);
            Assert.Equal(lastName, zooKeeper.LastName);
            Assert.Equal(0,zooKeeper.AnimalExperience.Length);
        }
        [Fact]
        public void ShouldFeedAnimal()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            string animalExperience = typeof(Penguin).Name;
            ZooKeeper zooKeeper = new ZooKeeper(firstName, lastName, animalExperience);
            Penguin penguin = new Penguin();
            var dateTime = DateTime.Now;
            Assert.True(zooKeeper.FeedAnimal(penguin, dateTime));
        }
        [Fact]
        public void ShouldNotFeedAnimal()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            ZooKeeper zooKeeper = new ZooKeeper(firstName, lastName);
            Penguin penguin = new Penguin();
            var dateTime = DateTime.Now;
            Assert.False(zooKeeper.FeedAnimal(penguin, dateTime));
        }
    }
}
