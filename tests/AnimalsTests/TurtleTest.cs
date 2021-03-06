using Animals;
using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using System;
using Xunit;
using ZooApps.Employee;
using ZooApps.Foods;

namespace AnimalsTests
{
    public class TurtleTest
    {
        [Fact]
        public void ShouldBeFriendly()
        {
            var turtle = new Turtle();
            var parrot = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            var turtle2 = new Turtle();
            Assert.True(turtle.IsFriendlyWithAnimal(parrot));
            Assert.True(turtle.IsFriendlyWithAnimal(bison));
            Assert.True(turtle.IsFriendlyWithAnimal(elephant));
            Assert.True(turtle.IsFriendlyWithAnimal(turtle2));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var turtle = new Turtle();
            var lion = new Lion();
            var snake = new Snake();
            var penguin = new Penguin();
            Assert.False(turtle.IsFriendlyWithAnimal(snake));
            Assert.False(turtle.IsFriendlyWithAnimal(lion));
            Assert.False(turtle.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("Vegetable")]
        public void ShouldGetFavoriteFood(string food)
        {
            var turtle = new Turtle();
            string favoriteFoodString = string.Join(",", turtle.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("Meet")]
        [InlineData("Egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var turtle = new Turtle();
            string favoriteFoodString = string.Join(",", turtle.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Fact]
        public void ShouldNotBeSick()
        {
            var turtle = new Turtle();
            var grass = new Grass();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            turtle.Feed(grass, dateTime, zooKeeper);
            Assert.False(turtle.IsSick);
        }
        [Fact]
        public void ShouldBeSick()
        {
            var turtle = new Turtle();
            var meet = new Meet();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            turtle.Feed(meet, dateTime, zooKeeper);
            Assert.True(turtle.IsSick);
        }
        [Theory]
        [InlineData(5)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var turtle = new Turtle();
            Assert.Equal(requiresFt, turtle.RequiredSpaceSqFt);
        }
    }
}
