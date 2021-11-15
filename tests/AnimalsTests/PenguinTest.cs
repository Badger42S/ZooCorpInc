
using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using System;
using Xunit;
using ZooApps.Employee;
using ZooApps.Foods;

namespace AnimalsTests
{
    public class PenguinTest
    {
        [Fact]
        public void ShouldBeFriendly()
        {
            var penguin = new Penguin();
            var penguin2 = new Penguin();
            Assert.True(penguin.IsFriendlyWithAnimal(penguin2));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var penguin = new Penguin();
            var snake = new Snake();
            var parrot = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            var turtle = new Turtle();
            var lion = new Lion();
            Assert.False(penguin.IsFriendlyWithAnimal(snake));
            Assert.False(penguin.IsFriendlyWithAnimal(parrot));
            Assert.False(penguin.IsFriendlyWithAnimal(bison));
            Assert.False(penguin.IsFriendlyWithAnimal(elephant));
            Assert.False(penguin.IsFriendlyWithAnimal(turtle));
            Assert.False(penguin.IsFriendlyWithAnimal(lion));
        }
        [Theory]
        [InlineData("Meet")]
        public void ShouldGetFavoriteFood(string food)
        {
            var penguin = new Penguin();
            string favoriteFoodString = string.Join(",", penguin.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("Grass")]
        [InlineData("Egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var penguin = new Penguin();
            string favoriteFoodString = string.Join(",", penguin.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Fact]
        public void ShouldNotBeSick()
        {
            var penguin = new Penguin();
            var meet = new Meet();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            penguin.Feed(meet, dateTime, zooKeeper);
            Assert.False(penguin.IsSick);
        }
        [Fact]
        public void ShouldBeSick()
        {
            var penguin = new Penguin();
            var grass = new Grass();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            penguin.Feed(grass, dateTime, zooKeeper);
            Assert.True(penguin.IsSick);
        }
        [Theory]
        [InlineData(10)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var penguin = new Penguin();
            Assert.Equal(requiresFt, penguin.RequiredSpaceSqFt);
        }
    }
}
