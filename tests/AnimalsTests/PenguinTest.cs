using Animals;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
    public class PenguinTest
    {
        [Fact]
        public void ShouldBeHealed()
        {
            Penguin penguin = new Penguin(7);
            Antibiotics antibiotics = new();
            penguin.Heal(antibiotics);
            Assert.False(penguin.IsSick);
            penguin = new Penguin(7);
            AntiDepression antiDepression = new();
            penguin.Heal(antiDepression);
            Assert.False(penguin.IsSick);
            penguin = new Penguin(7);
            AntiInflammatory antiInflammatory = new();
            penguin.Heal(antiInflammatory);
            Assert.False(penguin.IsSick);
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            Penguin penguin = new Penguin(77);
            List<int> moreFeedTimes = new() { value1, value2 };
            penguin.AddSchedule(moreFeedTimes);
            Assert.Equal(value1, penguin.FeedSchedule[0]);
            Assert.Equal(value2, penguin.FeedSchedule[penguin.FeedSchedule.Count - 1]);
        }
        [Theory]
        [InlineData(547)]
        [InlineData(6698705)]
        public void ShouldBeCorrectID(int value)
        {
            Penguin penguin = new Penguin(value);
            Assert.Equal(value, penguin.ID);
        }
        [Fact]
        public void ShouldBeFriendly()
        {
            Penguin penguin = new Penguin(7);
            Snake snake = new(6);
            Penguin penguin2 = new Penguin(8);
            Assert.False(penguin.IsFriendlyWithAnimal(snake));
            Assert.True(penguin.IsFriendlyWithAnimal(penguin2));
            Turtle turtle = new Turtle(52);
            Assert.True(penguin.IsFriendlyWithAnimal(turtle));
        }
        [Theory]
        [InlineData("salmon")]
        [InlineData("herring")]
        public void ShouldGetFavoriteFood(string food)
        {
            Penguin penguin = new Penguin(7);
            string favoriteFoodString = string.Join(",", penguin.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meat")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            Penguin penguin = new Penguin(7);
            string favoriteFoodString = string.Join(",", penguin.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
    }
}
