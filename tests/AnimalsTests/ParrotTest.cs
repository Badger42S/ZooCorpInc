using Animals;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
    public class ParrotTest
    {
        [Fact]
        public void ShouldBeHealed()
        {
            Parrot parrot = new Parrot(7);
            Antibiotics antibiotics = new();
            parrot.Heal(antibiotics);
            Assert.False(parrot.IsSick);
            parrot = new Parrot(7);
            AntiDepression antiDepression = new();
            parrot.Heal(antiDepression);
            Assert.False(parrot.IsSick);
            parrot = new Parrot(7);
            AntiInflammatory antiInflammatory = new();
            parrot.Heal(antiInflammatory);
            Assert.False(parrot.IsSick);
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            Parrot parrot = new Parrot(77);
            List<int> moreFeedTimes = new() { value1, value2 };
            parrot.AddSchedule(moreFeedTimes);
            Assert.Equal(value1, parrot.FeedSchedule[0]);
            Assert.Equal(value2, parrot.FeedSchedule[parrot.FeedSchedule.Count - 1]);
        }
        [Theory]
        [InlineData(547)]
        [InlineData(6698705)]
        public void ShouldBeCorrectID(int value)
        {
            Parrot parrot = new Parrot(value);
            Assert.Equal(value, parrot.ID);
        }
        [Fact]
        public void ShouldBeFriendly()
        {
            var parrot = new Parrot(7);
            var parrot2 = new Parrot(9);
            var bison = new Bison(4);
            var elephant = new Elephant(5);
            var turtle = new Turtle(6);
            Assert.True(parrot.IsFriendlyWithAnimal(parrot2));
            Assert.True(parrot.IsFriendlyWithAnimal(bison));
            Assert.True(parrot.IsFriendlyWithAnimal(elephant));
            Assert.True(parrot.IsFriendlyWithAnimal(turtle));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var parrot = new Parrot(7);
            var lion = new Lion(1);
            var snake = new Snake(2);
            var penguin = new Penguin(7);
            Assert.False(parrot.IsFriendlyWithAnimal(snake));
            Assert.False(parrot.IsFriendlyWithAnimal(lion));
            Assert.False(parrot.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("fruit")]
        [InlineData("vegetables")]
        public void ShouldGetFavoriteFood(string food)
        {
            Parrot parrot = new Parrot(7);
            string favoriteFoodString = string.Join(",", parrot.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("grass")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var parrot = new Parrot(7);
            string favoriteFoodString = string.Join(",", parrot.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Theory]
        [InlineData(5)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var parrot = new Parrot(7);
            Assert.Equal(requiresFt, parrot.RequiredSpaceSqFt);
        }
    }
}
