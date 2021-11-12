using Animals;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
        public class LionTest
        {
            [Fact]
            public void ShouldBeHealed()
            {
                var lion = new Lion(7);
                Antibiotics antibiotics = new();
                lion.Heal(antibiotics);
                Assert.False(lion.IsSick);
                lion = new Lion(7);
                AntiDepression antiDepression = new();
                lion.Heal(antiDepression);
                Assert.False(lion.IsSick);
                lion = new Lion(7);
                AntiInflammatory antiInflammatory = new();
                lion.Heal(antiInflammatory);
                Assert.False(lion.IsSick);
            }
            [Theory]
            [InlineData(0, 23)]
            [InlineData(5, 20)]
            public void ShouldAddSchedule(int value1, int value2)
            {
                var lion = new Lion(77);
                List<int> moreFeedTimes = new() { value1, value2 };
                lion.AddSchedule(moreFeedTimes);
                Assert.Equal(value1, lion.FeedSchedule[0]);
                Assert.Equal(value2, lion.FeedSchedule[lion.FeedSchedule.Count - 1]);
            }
            [Theory]
            [InlineData(547)]
            [InlineData(6698705)]
            public void ShouldBeCorrectID(int value)
            {
                var lion = new Lion(value);
                Assert.Equal(value, lion.ID);
            }
            [Fact]
            public void ShouldBeFriendly()
            {
                var lion = new Lion(7);
                Snake snake = new(6);
                Parrot parrot = new Parrot(8);
                Assert.False(lion.IsFriendlyWithAnimal(snake));
                Assert.True(lion.IsFriendlyWithAnimal(parrot));
                Turtle turtle = new Turtle(52);
                Assert.True(parrot.IsFriendlyWithAnimal(turtle));
            }
            [Theory]
            [InlineData("meet")]
            public void ShouldGetFavoriteFood(string food)
            {
                var lion = new Lion(7);
                string favoriteFoodString = string.Join(",", lion.FavoriteFood);
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
