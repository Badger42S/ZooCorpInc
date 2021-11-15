using Animals;
using Animals.Bird;
using Animals.Mammal;
using ZooApps.Employee;
using ZooApps.Enclousers;
using ZooApps.Exceptions;
using System;
using Xunit;
using ZooApps.Zoos;
using System.Text.RegularExpressions;
using System.IO;

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
        public void ShouldBePrintAddEnclouserMessage()
        {
            var zoo = new Zoo("Berlin");
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            string outputMessage = $"Enclose desert was added to zoo in {zoo.Location}";
            zoo.AddEnclouser("desert", 1000);
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));
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
        public void ShouldBePrintHireZooKeeperMessage()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("desert", 1000);
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            var zooKeeper = new ZooKeeper("Karl", "Gustaf", "Penguin");
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            string outputMessage = $"{zooKeeper.LastName} {zooKeeper.FirstName} was hired as a {zooKeeper.GetType().Name}";
            zoo.HireEmployee(zooKeeper);
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));
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
        public void ShouldBePrintHireVeterinarian()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("desert", 1000);
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            var veterinarian = new Veterinarian("Karl", "Gustaf", "Penguin");
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            string outputMessage = $"{veterinarian.LastName} {veterinarian.FirstName} was hired as a {veterinarian.GetType().Name}";
            zoo.HireEmployee(veterinarian);
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));
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
            var veterinarian = new Veterinarian("Karl", "Gustaf", "Lion");
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(veterinarian));
        }
        [Fact]
        public void ShouldNotBeHireZooKeeper()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            zoo.AddEnclouser("forest", 5000);
            var bison = new Bison();
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            zoo.FindAvailableEnclouser(bison);
            var zooKeeper = new ZooKeeper("Karl", "Gustaf", "Lion");
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(zooKeeper));
        }
        [Fact]
        public void ShouldBeFeedAnimals()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            var zooKeeper = new ZooKeeper("Karl", "Gustaf", "Penguin");
            zoo.HireEmployee(zooKeeper);
            var todayDate = DateTime.Now;
            penguin.AddSchedule(new() { todayDate.AddHours(-1).Hour, todayDate.AddHours(1).Hour });
            zoo.FeedAnimals(todayDate);
            Assert.Equal(penguin.FeedTimes[0].FeedTimeNote.Hour, todayDate.Hour);
        }
        [Fact]
        public void ShouldNotBeFeedAnimals()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            var zooKeeper = new ZooKeeper("Karl", "Gustaf", "Penguin");
            zoo.HireEmployee(zooKeeper);
            var todayDate = new DateTime(2021, 7, 9, 12, 0, 0);
            penguin.AddSchedule(new() { todayDate.AddHours(1).Hour, todayDate.AddHours(2).Hour });
            zoo.FeedAnimals(todayDate);
            Assert.Empty(penguin.FeedTimes);
        }
        [Fact]
        public void ShouldBeFeedOnlyTwice()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            var zooKeeper = new ZooKeeper("Karl", "Gustaf", "Penguin");
            zoo.HireEmployee(zooKeeper);
            var todayDate = DateTime.Now;
            penguin.AddSchedule(new() { todayDate.AddHours(-2).Hour, todayDate.AddHours(2).Hour });
            zoo.FeedAnimals(todayDate);
            zoo.FeedAnimals(todayDate);
            zoo.FeedAnimals(todayDate);
            Assert.Equal(2, penguin.FeedTimes.Count);
        }
        [Fact]
        public void ShouldBeFeedAnimalsByDifferentZooKeepers()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            zoo.AddEnclouser("desert", 5000);
            var penguin = new Penguin();
            var penguin2 = new Penguin();
            var penguin3 = new Penguin();
            var penguin4 = new Penguin();
            var bison = new Bison();
            var bison2 = new Bison();
            zoo.FindAvailableEnclouser(penguin);
            zoo.FindAvailableEnclouser(penguin2);
            zoo.FindAvailableEnclouser(penguin3);
            zoo.FindAvailableEnclouser(penguin4);
            zoo.FindAvailableEnclouser(bison);
            zoo.FindAvailableEnclouser(bison2);
            var zooKeeper = new ZooKeeper("Karl", "Gustaf", "Penguin, Bison");
            var zooKeeper2 = new ZooKeeper("Janek", "Tobrov", "Penguin");
            var zooKeeper3 = new ZooKeeper("Cindy", "Crawford", "Bison");
            zoo.HireEmployee(zooKeeper);
            zoo.HireEmployee(zooKeeper2);
            zoo.HireEmployee(zooKeeper3);
            var todayDate = DateTime.Now;
            penguin.AddSchedule(new() { todayDate.AddHours(-1).Hour, todayDate.AddHours(2).Hour });
            penguin2.AddSchedule(new() { todayDate.AddHours(-1).Hour, todayDate.AddHours(2).Hour });
            penguin3.AddSchedule(new() { todayDate.AddHours(-1).Hour, todayDate.AddHours(2).Hour });
            penguin4.AddSchedule(new() { todayDate.AddHours(-1).Hour, todayDate.AddHours(2).Hour });
            bison.AddSchedule(new() { todayDate.AddHours(-1).Hour, todayDate.AddHours(2).Hour });
            bison2.AddSchedule(new() { todayDate.AddHours(-1).Hour, todayDate.AddHours(2).Hour });
            zoo.FeedAnimals(todayDate);
            Assert.Equal(zooKeeper, penguin.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper2, penguin2.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper, penguin3.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper2, penguin4.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper, bison.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper3, bison2.FeedTimes[0].FeedByZooKeeper);
        }
        [Fact]
        public void ShouldBeHealAnimals()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            zoo.AddEnclouser("desert", 5000);
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            var veterinarian = new Veterinarian("Karl", "Gustaf", "Penguin, Bison");
            zoo.HireEmployee(veterinarian);
            zoo.HealAnimals();
            Assert.False(penguin.IsSick);
        }
        [Fact]
        public void ShouldNotBeHealAnimals()
        {
            var zoo = new Zoo("Berlin");
            zoo.AddEnclouser("ice desert", 5000);
            zoo.AddEnclouser("desert", 5000);
            var penguin = new Penguin();
            zoo.FindAvailableEnclouser(penguin);
            var bison = new Bison();
            zoo.FindAvailableEnclouser(bison);
            var veterinarian = new Veterinarian("Karl", "Gustaf", "Bison");
            zoo.HireEmployee(veterinarian);
            zoo.HealAnimals();
            Assert.True(penguin.IsSick);
        }
    }
}
