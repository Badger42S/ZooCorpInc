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
   public class LionTest
   {
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
       [InlineData("Meet")]
       public void ShouldGetFavoriteFood(string food)
       {
           var lion = new Lion();
           string favoriteFoodString = string.Join(",", lion.FavoriteFood);
           Assert.Contains(food, favoriteFoodString);
       }
       [Theory]
       [InlineData("Grass")]
       [InlineData("Egg")]
       public void ShouldNotGetBadFood(string badFood)
       {
           var lion = new Lion();
           string favoriteFoodString = string.Join(",", lion.FavoriteFood);
           Assert.DoesNotContain(badFood, favoriteFoodString);
       }
        [Fact]
        public void ShouldNotBeSick()
        {
            var lion = new Lion();
            var meet = new Meet();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            lion.Feed(meet, dateTime, zooKeeper);
            Assert.False(lion.IsSick);
        }
        [Fact]
        public void ShouldBeSick()
        {
            var lion = new Lion();
            var grass = new Grass();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            lion.Feed(grass, dateTime, zooKeeper);
            Assert.True(lion.IsSick);
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
