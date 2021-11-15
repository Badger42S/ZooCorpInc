using Animals;
using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;

using System;
using System.Collections.Generic;
using Xunit;
using ZooApps.Employee;
using ZooApps.Foods;

namespace AnimalsTests
{
   public class SnakeTest
    {
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
       [InlineData("Meet")]
        public void ShouldGetFavoriteFood(string food)
       {
           var snake = new Snake();
           string favoriteFoodString = string.Join(",", snake.FavoriteFood);
           Assert.Contains(food, favoriteFoodString);
       }
       [Theory]
       [InlineData("Grass")]
       [InlineData("Egg")]
       public void ShouldNotGetBadFood(string badFood)
       {
            var snake = new Snake();
            string favoriteFoodString = string.Join(",", snake.FavoriteFood);
           Assert.DoesNotContain(badFood, favoriteFoodString);
       }
        [Fact]
        public void ShouldNotBeSick()
        {
            var snake = new Snake();
            var meet = new Meet();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            snake.Feed(meet, dateTime,zooKeeper);
            Assert.False(snake.IsSick);
        }
        [Fact]
        public void ShouldBeSick()
        {
            var snake = new Snake();
            var grass = new Grass();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            snake.Feed(grass, dateTime,zooKeeper);
            Assert.True(snake.IsSick);
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
