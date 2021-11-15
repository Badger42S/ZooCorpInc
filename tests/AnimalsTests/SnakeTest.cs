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
   public class SnakeTest
    {
       [Fact]
       public void ShouldBeHealed()
       {
           var snake = new Snake();
           var antibiotics = new Antibiotics();
           snake.Heal(antibiotics);
           Assert.False(snake.IsSick);
           snake = new Snake();
           var antiDepression = new AntiDepression();
           snake.Heal(antiDepression);
           Assert.False(snake.IsSick);
           snake = new Snake();
           var antiInflammatory = new AntiInflammatory();
           snake.Heal(antiInflammatory);
           Assert.False(snake.IsSick);
       }
       [Theory]
       [InlineData(0, 23)]
       [InlineData(5, 20)]
       public void ShouldAddSchedule(int value1, int value2)
       {
            var snake = new Snake();
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
           var snake = new Snake();
           snake.ID = value;
           Assert.Equal(value, snake.ID);
       }
       [Fact]
       public void ShouldBeFriendly()
       {
            var snake = new Snake();
            var snake2 = new Snake();
            Assert.True(snake.IsFriendlyWithAnimal(snake2));
       }
       [Fact]
       public void ShouldNotBeFriendly()
       {
            var snake = new Snake();
            var lion = new Lion();
            var parrot = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            var turtle = new Turtle();
            var penguin = new Penguin();
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
           var snake = new Snake();
           string favoriteFoodString = string.Join(",", snake.FavoriteFood);
           Assert.Contains(food, favoriteFoodString);
       }
       [Theory]
       [InlineData("grass")]
       [InlineData("egg")]
       public void ShouldNotGetBadFood(string badFood)
       {
            var snake = new Snake();
            string favoriteFoodString = string.Join(",", snake.FavoriteFood);
           Assert.DoesNotContain(badFood, favoriteFoodString);
       }
        [Theory]
        [InlineData(2)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var snake = new Snake();
            Assert.Equal(requiresFt, snake.RequiredSpaceSqFt);
        }
    }
}
