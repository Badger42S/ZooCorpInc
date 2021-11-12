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
            var penguin = new Penguin(7);
            var penguin2 = new Penguin(9);
            Assert.True(penguin.IsFriendlyWithAnimal(penguin2));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var penguin = new Penguin(1);
            var snake = new Snake(2);
            var parrot = new Parrot(3);
            var bison = new Bison(4);
            var elephant = new Elephant(5);
            var turtle = new Turtle(6);
            var lion = new Lion(7);
            Assert.False(penguin.IsFriendlyWithAnimal(snake));
            Assert.False(penguin.IsFriendlyWithAnimal(parrot));
            Assert.False(penguin.IsFriendlyWithAnimal(bison));
            Assert.False(penguin.IsFriendlyWithAnimal(elephant));
            Assert.False(penguin.IsFriendlyWithAnimal(turtle));
            Assert.False(penguin.IsFriendlyWithAnimal(lion));
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
            var penguin = new Penguin(7);
            string favoriteFoodString = string.Join(",", penguin.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Theory]
        [InlineData(10)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var penguin = new Penguin(7);
            Assert.Equal(requiresFt, penguin.RequiredSpaceSqFt);
        }
    }
}
