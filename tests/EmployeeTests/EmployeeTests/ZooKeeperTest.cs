using System;
using Xunit;
using Employee;
using Animals;

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
            Penguin penguin = new Penguin();
            zooKeeper.AddAnimalExperience(penguin);
            Assert.True(zooKeeper.HasAnimalExperience(typeof(Penguin).Name));
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
    }
}
