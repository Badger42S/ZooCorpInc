using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using System;
using Xunit;
using ZooApps.Employee;
using ZooApps.Foods;

namespace AnimalsTests
{
    public class ElephantTest
    {
        [Fact]
        public void ShouldBeFriendly()
        {
            var elephant = new Elephant();
            var bison = new Bison();
            var parrot = new Parrot();
            var turtle = new Turtle();
            Assert.True(elephant.IsFriendlyWithAnimal(parrot));
            Assert.True(elephant.IsFriendlyWithAnimal(bison));
            Assert.True(elephant.IsFriendlyWithAnimal(turtle));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var elephant = new Elephant();
            var elephant2 = new Elephant();
            var lion = new Lion();
            var snake = new Snake();
            var penguin = new Penguin();
            Assert.False(elephant.IsFriendlyWithAnimal(lion));
            Assert.False(elephant.IsFriendlyWithAnimal(snake));
            Assert.False(elephant.IsFriendlyWithAnimal(elephant2));
            Assert.False(elephant.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("Grass")]
        [InlineData("Vegetable")]
        public void ShouldGetFavoriteFood(string food)
        {
            var elephant = new Elephant();
            string favoriteFoodString = string.Join(",", elephant.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Fact]
        public void ShouldNotBeSick()
        {
            var elephant = new Elephant();
            var grass = new Grass();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            elephant.Feed(grass, dateTime, zooKeeper);
            Assert.False(elephant.IsSick);
        }
        [Fact]
        public void ShouldBeSick()
        {
            var elephant = new Elephant();
            var meet = new Meet();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            elephant.Feed(meet, dateTime, zooKeeper);
            Assert.True(elephant.IsSick);
        }
        [Theory]
        [InlineData(1000)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var elephant = new Elephant();
            Assert.Equal(requiresFt, elephant.RequiredSpaceSqFt);
        }
    }
}
