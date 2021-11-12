using Animals;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
    public class BisonTest
    {
        [Fact]
        public void ShouldBeHealed()
        {
            var bison = new Bison(7);
            Antibiotics antibiotics = new();
            bison.Heal(antibiotics);
            Assert.False(bison.IsSick);
            bison = new Bison(7);
            AntiDepression antiDepression = new();
            bison.Heal(antiDepression);
            Assert.False(bison.IsSick);
            bison = new Bison(7);
            AntiInflammatory antiInflammatory = new();
            bison.Heal(antiInflammatory);
            Assert.False(bison.IsSick);
        }
        [Theory]
        [InlineData(0, 23)]
        [InlineData(5, 20)]
        public void ShouldAddSchedule(int value1, int value2)
        {
            var bison = new Bison(77);
            List<int> moreFeedTimes = new() { value1, value2 };
            bison.AddSchedule(moreFeedTimes);
            Assert.Equal(value1, bison.FeedSchedule[0]);
            Assert.Equal(value2, bison.FeedSchedule[bison.FeedSchedule.Count - 1]);
        }
        [Theory]
        [InlineData(547)]
        [InlineData(6698705)]
        public void ShouldBeCorrectID(int value)
        {
            var bison = new Bison(value);
            Assert.Equal(value, bison.ID);
        }
        [Fact]
        public void ShouldBeFriendly()
        {
            var bison = new Bison(7);
            var bison2 = new Bison(7);
            var elephant = new Elephant(5);
            Assert.True(bison.IsFriendlyWithAnimal(elephant));
            Assert.True(bison.IsFriendlyWithAnimal(bison2));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var bison = new Bison(8);
            var lion = new Lion(1);
            var snake = new Snake(2);
            var parrot = new Parrot(3);
            var turtle = new Turtle(6);
            var penguin = new Penguin(7);
            Assert.False(bison.IsFriendlyWithAnimal(lion));
            Assert.False(bison.IsFriendlyWithAnimal(snake));
            Assert.False(bison.IsFriendlyWithAnimal(parrot));
            Assert.False(bison.IsFriendlyWithAnimal(turtle));
            Assert.False(bison.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("grass")]
        [InlineData("vegetable")]
        public void ShouldGetFavoriteFood(string food)
        {
            var bison = new Bison(7);
            string favoriteFoodString = string.Join(",", bison.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meat")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var bison = new Bison(7);
            string favoriteFoodString = string.Join(",", bison.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
    }
}
