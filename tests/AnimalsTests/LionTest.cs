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
           var lion2 = new Lion(9);
           Assert.True(lion.IsFriendlyWithAnimal(lion2));
       }
       [Fact]
       public void ShouldNotBeFriendly()
       {
            var lion = new Lion(1);
            var snake = new Snake(2);
            var parrot = new Parrot(3);
            var bison = new Bison(4);
            var elephant = new Elephant(5);
            var turtle = new Turtle(6);
            var penguin = new Penguin(7);
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
           var lion = new Lion(7);
           string favoriteFoodString = string.Join(",", lion.FavoriteFood);
           Assert.Contains(food, favoriteFoodString);
       }
       [Theory]
       [InlineData("grass")]
       [InlineData("egg")]
       public void ShouldNotGetBadFood(string badFood)
       {
           Parrot parrot = new Parrot(7);
           string favoriteFoodString = string.Join(",", parrot.FavoriteFood);
           Assert.DoesNotContain(badFood, favoriteFoodString);
       }
   }
}
