using Animals;
using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
    public class TurtleTest
    {
        [Fact]
        public void ShouldBeHealed()
        {
            var turtle = new Turtle();
            Antibiotics antibiotics = new();
            turtle.Heal(antibiotics);
            Assert.False(turtle.IsSick);
            turtle = new Turtle();
            AntiDepression antiDepression = new();
            turtle.Heal(antiDepression);
            Assert.False(turtle.IsSick);
            turtle = new Turtle();
            AntiInflammatory antiInflammatory = new();
            turtle.Heal(antiInflammatory);
            Assert.False(turtle.IsSick);
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            Turtle turtle = new Turtle();
            List<int> moreFeedTimes = new() { value1, value2 };
            turtle.AddSchedule(moreFeedTimes);
            Assert.Equal(value1, turtle.FeedSchedule[0]);
            Assert.Equal(value2, turtle.FeedSchedule[turtle.FeedSchedule.Count - 1]);
        }
        [Theory]
        [InlineData(547)]
        [InlineData(6698705)]
        public void ShouldBeCorrectID(int value)
        {
            Turtle turtle = new Turtle();
            turtle.ID = value;
            Assert.Equal(value, turtle.ID);
        }
        [Fact]
        public void ShouldBeFriendly()
        {
            var turtle = new Turtle();
            var parrot = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            var turtle2 = new Turtle();
            Assert.True(turtle.IsFriendlyWithAnimal(parrot));
            Assert.True(turtle.IsFriendlyWithAnimal(bison));
            Assert.True(turtle.IsFriendlyWithAnimal(elephant));
            Assert.True(turtle.IsFriendlyWithAnimal(turtle2));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var turtle = new Turtle();
            var lion = new Lion();
            var snake = new Snake();
            var penguin = new Penguin();
            Assert.False(turtle.IsFriendlyWithAnimal(snake));
            Assert.False(turtle.IsFriendlyWithAnimal(lion));
            Assert.False(turtle.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("grass")]
        [InlineData("vegetable")]
        public void ShouldGetFavoriteFood(string food)
        {
            var turtle = new Turtle();
            string favoriteFoodString = string.Join(",", turtle.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meet")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var turtle = new Turtle();
            string favoriteFoodString = string.Join(",", turtle.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Theory]
        [InlineData(5)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var turtle = new Turtle();
            Assert.Equal(requiresFt, turtle.RequiredSpaceSqFt);
        }
    }
}
