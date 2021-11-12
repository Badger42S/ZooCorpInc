using Animals;
using Medicines;
using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalsTests
{
   public class SnakeTest
    {
       [Fact]
       public void ShouldBeHealed()
       {
           var snake = new Snake(7);
           var antibiotics = new Antibiotics();
           snake.Heal(antibiotics);
           Assert.False(snake.IsSick);
           snake = new Snake(7);
           var antiDepression = new AntiDepression();
           snake.Heal(antiDepression);
           Assert.False(snake.IsSick);
           snake = new Snake(7);
           var antiInflammatory = new AntiInflammatory();
           snake.Heal(antiInflammatory);
           Assert.False(snake.IsSick);
       }
       [Theory]
       [InlineData(0, 23)]
       [InlineData(5, 20)]
       public void ShouldAddSchedule(int value1, int value2)
       {
            var snake = new Snake(7);
            List<int> moreFeedTimes = new() { value1, value2 };
            snake.AddSchedule(moreFeedTimes);
           Assert.Equal(value1, snake.FeedSchedule[0]);
           Assert.Equal(value2, snake.FeedSchedule[snake.FeedSchedule.Count - 1]);
       }
       [Theory]
       [InlineData(547)]
       [InlineData(6698705)]
       public void ShouldBeCorrectID(int value)
       {
           var snake = new Snake(value);
           Assert.Equal(value, snake.ID);
       }
       [Fact]
       public void ShouldBeFriendly()
       {
            var snake = new Snake(7);
            var snake2 = new Snake(9);
            Assert.True(snake.IsFriendlyWithAnimal(snake2));
       }
       [Fact]
       public void ShouldNotBeFriendly()
       {
            var snake = new Snake(1);
            var lion = new Lion(2);
            var parrot = new Parrot(3);
            var bison = new Bison(4);
            var elephant = new Elephant(5);
            var turtle = new Turtle(6);
            var penguin = new Penguin(7);
            Assert.False(snake.IsFriendlyWithAnimal(lion));
            Assert.False(snake.IsFriendlyWithAnimal(parrot));
            Assert.False(snake.IsFriendlyWithAnimal(bison));
            Assert.False(snake.IsFriendlyWithAnimal(elephant));
            Assert.False(snake.IsFriendlyWithAnimal(turtle));
            Assert.False(snake.IsFriendlyWithAnimal(penguin));
       }
       [Theory]
       [InlineData("mouse")]
       [InlineData("bird")]
        public void ShouldGetFavoriteFood(string food)
       {
           var snake = new Snake(7);
           string favoriteFoodString = string.Join(",", snake.FavoriteFood);
           Assert.Contains(food, favoriteFoodString);
       }
       [Theory]
       [InlineData("grass")]
       [InlineData("egg")]
       public void ShouldNotGetBadFood(string badFood)
       {
            var snake = new Snake(7);
            string favoriteFoodString = string.Join(",", snake.FavoriteFood);
           Assert.DoesNotContain(badFood, favoriteFoodString);
       }
   }
}
