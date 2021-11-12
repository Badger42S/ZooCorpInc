using Animals;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
    public class ElephantTest
    {
        [Fact]
        public void ShouldBeHealed()
        {
            var elephant = new Elephant(7);
            Antibiotics antibiotics = new();
            elephant.Heal(antibiotics);
            Assert.False(elephant.IsSick);
            elephant = new Elephant(7);
            AntiDepression antiDepression = new();
            elephant.Heal(antiDepression);
            Assert.False(elephant.IsSick);
            elephant = new Elephant(7);
            AntiInflammatory antiInflammatory = new();
            elephant.Heal(antiInflammatory);
            Assert.False(elephant.IsSick);
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            var elephant = new Elephant(77);
            List<int> moreFeedTimes = new() { value1, value2 };
            elephant.AddSchedule(moreFeedTimes);
            Assert.Equal(value1, elephant.FeedSchedule[0]);
            Assert.Equal(value2, elephant.FeedSchedule[elephant.FeedSchedule.Count - 1]);
        }
        [Theory]
        [InlineData(547)]
        [InlineData(6698705)]
        public void ShouldBeCorrectID(int value)
        {
            var elephant = new Elephant(value);
            Assert.Equal(value, elephant.ID);
        }
        [Fact]
        public void ShouldBeFriendly()
        {
            var elephant = new Elephant(7);
            var bison = new Bison(6);
            var parrot = new Parrot(5);
            var turtle = new Turtle(6);
            Assert.True(elephant.IsFriendlyWithAnimal(parrot));
            Assert.True(elephant.IsFriendlyWithAnimal(bison));
            Assert.True(elephant.IsFriendlyWithAnimal(turtle));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var elephant = new Elephant(8);
            var elephant2 = new Elephant(8);
            var lion = new Lion(1);
            var snake = new Snake(2);
            var penguin = new Penguin(7);
            Assert.False(elephant.IsFriendlyWithAnimal(lion));
            Assert.False(elephant.IsFriendlyWithAnimal(snake));
            Assert.False(elephant.IsFriendlyWithAnimal(elephant2));
            Assert.False(elephant.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("grass")]
        [InlineData("vegetable")]
        [InlineData("fruit")]
        public void ShouldGetFavoriteFood(string food)
        {
            var elephant = new Elephant(7);
            string favoriteFoodString = string.Join(",", elephant.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meat")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var elephant = new Elephant(7);
            string favoriteFoodString = string.Join(",", elephant.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Theory]
        [InlineData(1000)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var elephant = new Elephant(7);
            Assert.Equal(requiresFt, elephant.RequiredSpaceSqFt);
        }
    }
}
