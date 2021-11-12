using Animals;
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
            var turtle = new Turtle(7);
            Antibiotics antibiotics = new();
            turtle.Heal(antibiotics);
            Assert.False(turtle.IsSick);
            turtle = new Turtle(7);
            AntiDepression antiDepression = new();
            turtle.Heal(antiDepression);
            Assert.False(turtle.IsSick);
            turtle = new Turtle(7);
            AntiInflammatory antiInflammatory = new();
            turtle.Heal(antiInflammatory);
            Assert.False(turtle.IsSick);
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            Turtle turtle = new Turtle(77);
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
            Turtle turtle = new Turtle(value);
            Assert.Equal(value, turtle.ID);
        }
        [Fact]
        public void ShouldBeFriendly()
        {
            var turtle = new Turtle(7);
            var parrot = new Parrot(9);
            var bison = new Bison(4);
            var elephant = new Elephant(5);
            var turtle2 = new Turtle(6);
            Assert.True(turtle.IsFriendlyWithAnimal(parrot));
            Assert.True(turtle.IsFriendlyWithAnimal(bison));
            Assert.True(turtle.IsFriendlyWithAnimal(elephant));
            Assert.True(turtle.IsFriendlyWithAnimal(turtle2));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var turtle = new Turtle(7);
            var lion = new Lion(1);
            var snake = new Snake(2);
            var penguin = new Penguin(7);
            Assert.False(turtle.IsFriendlyWithAnimal(snake));
            Assert.False(turtle.IsFriendlyWithAnimal(lion));
            Assert.False(turtle.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("grass")]
        [InlineData("vegetable")]
        public void ShouldGetFavoriteFood(string food)
        {
            var turtle = new Turtle(7);
            string favoriteFoodString = string.Join(",", turtle.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meet")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var turtle = new Turtle(7);
            string favoriteFoodString = string.Join(",", turtle.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
    }
}
