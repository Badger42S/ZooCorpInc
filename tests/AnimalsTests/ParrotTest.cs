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
            Parrot parrot = new Parrot(7);
            Snake snake = new(6);
            Parrot parrot2 = new Parrot(8);
            Assert.False(parrot.IsFriendlyWithAnimal(snake));
            Assert.True(parrot.IsFriendlyWithAnimal(parrot2));
            Turtle turtle = new Turtle(52);
            Assert.True(parrot.IsFriendlyWithAnimal(turtle));
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
        [InlineData("meat")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            Parrot parrot = new Parrot(7);
            string favoriteFoodString = string.Join(",", parrot.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
    }
}
