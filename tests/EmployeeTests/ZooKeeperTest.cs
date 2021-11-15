using System;
using Xunit;
using Employee;
using Animals;
using Animals.Bird;

namespace EmployeeTests
{
    public class ZooKeeperTest
    {
        [Fact]
        public void ShouldAddExperience()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            ZooKeeper zooKeeper = new ZooKeeper(firstName, lastName);
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
            ZooKeeper zooKeeper = new ZooKeeper(firstName, lastName, animalExperience);
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
            Assert.True(zooKeeper.FeedAnimal(penguin));
        }
        [Fact]
        public void ShouldNotFeedAnimal()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            ZooKeeper zooKeeper = new ZooKeeper(firstName, lastName);
            Penguin penguin = new Penguin();
            Assert.False(zooKeeper.FeedAnimal(penguin));
        }
    }
}
