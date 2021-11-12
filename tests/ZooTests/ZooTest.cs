using Animals;
using Employee;
using Enclousers;
using Exceptions;
using System;
using Xunit;
using Zoos;

namespace ZooTests
{
    public class ZooTest
    {
        [Fact]
        public void ShouldBeCreatedZoo()
        {
            var zoo = new Zoo("Berlin");
            Assert.NotNull(zoo);
        }
        [Fact]
        public void ShouldBeAddEnclouser()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("desert", 1000);
            zoo.AddEnclouser("forest", 5000);
            Assert.Equal(2, zoo.Enclouseres.Count);
            Assert.Equal("desert", zoo.Enclouseres[0].Name);
            Assert.Equal(1000, zoo.Enclouseres[0].SqureFeet);
            Assert.Equal("forest", zoo.Enclouseres[1].Name);
            Assert.Equal(5000, zoo.Enclouseres[1].SqureFeet);
        }
        [Fact]
        public void ShouldBeFindAvailableEnclouser()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("desert", 500);
            zoo.AddEnclouser("forest", 5000);
            var bison = new Bison();
            var enclouser = zoo.FindAvailableEnclouser(bison);
            Assert.IsType<Enclouser>(enclouser);
            Assert.Equal(zoo.Enclouseres[1], enclouser);
        }
        [Fact]
        public void ShouldBeThrowSpaceException()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("forest", 500);
            var bison = new Bison();
            Assert.Throws<NoAvailableEnclouserException>(() => zoo.FindAvailableEnclouser(bison));
        }
        [Fact]
        public void ShouldBeThrowFriendlyAnimalsException()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 50000);
            var bison = new Bison();
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            Assert.Throws<NoAvailableEnclouserException>(() => zoo.FindAvailableEnclouser(bison));
        }
        [Fact]
        public void ShouldBeHireZooKeeper()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            zoo.AddEnclouser("forest", 5000);
            var bison = new Bison();
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            zoo.FindAvailableEnclouser(bison);
            var zooKeeper = new ZooKeeper("Karl", "Gustaf", "Penguin");
            zoo.HireEmployee(zooKeeper);
            var hiredKeeper = zoo.Employees.Find(emp =>
            {
                return (emp.FirstName == zooKeeper.FirstName) && (emp.LastName == zooKeeper.LastName);
            });
            Assert.Equal(zooKeeper, hiredKeeper);
        }
        [Fact]
        public void ShouldBeHireVeterinarian()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            zoo.AddEnclouser("forest", 5000);
            var bison = new Bison();
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            zoo.FindAvailableEnclouser(bison);
            var veterinarian = new Veterinarian("Karl", "Gustaf", "Bison");
            zoo.HireEmployee(veterinarian);
            var hiredKeeper = zoo.Employees.Find(emp =>
            {
                return (emp.FirstName == veterinarian.FirstName) && (emp.LastName == veterinarian.LastName);
            });
            Assert.Equal(veterinarian, hiredKeeper);
        }
        [Fact]
        public void ShouldNotBeHireVeterinarian()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            zoo.AddEnclouser("forest", 5000);
            var bison = new Bison();
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            zoo.FindAvailableEnclouser(bison);
            var veterinarian = new Veterinarian("Karl", "Gustaf", "Bison");
            zoo.HireEmployee(veterinarian);
            Assert.Empty(zoo.Employees);
        }
    }
}
