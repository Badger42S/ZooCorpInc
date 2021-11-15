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
   public class LionTest
   {
       [Fact]
       public void ShouldBeHealed()
       {
           var lion = new Lion();
           Antibiotics antibiotics = new();
           lion.Heal(antibiotics);
           Assert.False(lion.IsSick);
           lion = new Lion();
           AntiDepression antiDepression = new();
           lion.Heal(antiDepression);
           Assert.False(lion.IsSick);
           lion = new Lion();
           AntiInflammatory antiInflammatory = new();
           lion.Heal(antiInflammatory);
           Assert.False(lion.IsSick);
       }
       [Theory]
       [InlineData(0, 23)]
       [InlineData(5, 20)]
       public void ShouldAddSchedule(int value1, int value2)
       {
           var lion = new Lion();
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
           var lion = new Lion();
           lion.ID = value;
           Assert.Equal(value, lion.ID);
       }
       [Fact]
       public void ShouldBeFriendly()
       {
           var lion = new Lion();
           var lion2 = new Lion();
           Assert.True(lion.IsFriendlyWithAnimal(lion2));
       }
       [Fact]
       public void ShouldNotBeFriendly()
       {
            var lion = new Lion();
            var snake = new Snake();
            var parrot = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            var turtle = new Turtle();
            var penguin = new Penguin();
            Assert.False(lion.IsFriendlyWithAnimal(snake));
            Assert.False(lion.IsFriendlyWithAnimal(parrot));
            Assert.False(lion.IsFriendlyWithAnimal(bison));
            Assert.False(lion.IsFriendlyWithAnimal(elephant));
            Assert.False(lion.IsFriendlyWithAnimal(turtle));
            Assert.False(lion.IsFriendlyWithAnimal(penguin));
       }
       [Theory]
       [InlineData("meet")]
       public void ShouldGetFavoriteFood(string food)
       {
           var lion = new Lion();
           string favoriteFoodString = string.Join(",", lion.FavoriteFood);
           Assert.Contains(food, favoriteFoodString);
       }
       [Theory]
       [InlineData("grass")]
       [InlineData("egg")]
       public void ShouldNotGetBadFood(string badFood)
       {
           var lion = new Lion();
           string favoriteFoodString = string.Join(",", lion.FavoriteFood);
           Assert.DoesNotContain(badFood, favoriteFoodString);
       }
        [Theory]
        [InlineData(1000)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var lion = new Lion();
            Assert.Equal(requiresFt, lion.RequiredSpaceSqFt);
        }
    }
}
