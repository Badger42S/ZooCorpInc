using System;
using Xunit;
using Employee;

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
            zooKeeper.AddAnimalExperience(Animal animal);
        }
    }
}
