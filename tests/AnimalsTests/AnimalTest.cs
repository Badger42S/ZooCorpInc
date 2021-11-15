using Animals.Bird;
using Animals.Mammal;
using ZooApps.Medicines;
using System.Collections.Generic;
using Xunit;
using System.IO;
using System;
using System.Text.RegularExpressions;
using ZooApps.Employee;

namespace AnimalsTests
{
    public class AnimalTest
    {
        [Fact]
        public void ShouldBeHasID()
        {
            var lion = new Lion();
            Assert.InRange(lion.ID, 0, int.MaxValue);
        }
        [Fact]
        public void ShouldBeHealed()
        {
            var bison = new Bison();
            var antibiotics = new Antibiotics();
            bison.Heal(antibiotics);
            Assert.False(bison.IsSick);
            bison = new Bison();
            var antiDepression = new AntiDepression() ;
            bison.Heal(antiDepression);
            Assert.False(bison.IsSick);
            bison = new Bison();
            var antiInflammatory = new AntiInflammatory();
            bison.Heal(antiInflammatory);
            Assert.False(bison.IsSick);
        }
        [Fact]
        public void ShouldBePrintHealingMessage()
        {
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            var bison = new Bison();
            var antibiotics = new Antibiotics();
            string outputMessage = $"{bison.GetType().Name} {bison.ID} was healed by {antibiotics.GetType().Name}";
            bison.Heal(antibiotics);
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));
        }
        [Fact]
        public void ShouldBePrintFeedMessage()
        {
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            var bison = new Bison();
            string firstName = "Ivan";
            string lastName = "Korolev";
            string animalExperience = typeof(Bison).Name;
            var zooKeeper = new ZooKeeper(firstName, lastName, animalExperience);
            var dateTime = DateTime.Now;
            zooKeeper.FeedAnimal(bison, dateTime);
            string outputMessage = $"{bison.GetType().Name} {bison.ID} was fed by {zooKeeper.LastName} {zooKeeper.FirstName}";
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            Penguin penguin = new Penguin();
            List<int> moreFeedTimes = new() { value1, value2 };
            penguin.AddSchedule(moreFeedTimes);
            Assert.Equal(value1, penguin.FeedSchedule[0]);
            Assert.Equal(value2, penguin.FeedSchedule[penguin.FeedSchedule.Count - 1]);
        }
        [Fact]
        public void ShouldBePrintNewScheduleMessage()
        {
            Penguin penguin = new Penguin();
            List<int> moreFeedTimes = new() { 8, 10 };
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            string outputMessage = $"New schedule was added to {penguin.GetType().Name} {penguin.ID}";
            penguin.AddSchedule(moreFeedTimes);
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));

        }
    }
}
