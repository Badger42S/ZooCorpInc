using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using System;
using Xunit;
using ZooApps.Employee;
using ZooApps.Foods;

namespace AnimalsTests
{
    public class BisonTest
    {
        [Fact]
        public void ShouldBeFriendly()
        {
            var bison = new Bison();
            var bison2 = new Bison();
            var elephant = new Elephant();
            Assert.True(bison.IsFriendlyWithAnimal(elephant));
            Assert.True(bison.IsFriendlyWithAnimal(bison2));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var bison = new Bison();
            var lion = new Lion();
            var snake = new Snake();
            var parrot = new Parrot();
            var turtle = new Turtle();
            var penguin = new Penguin();
            Assert.False(bison.IsFriendlyWithAnimal(lion));
            Assert.False(bison.IsFriendlyWithAnimal(snake));
            Assert.False(bison.IsFriendlyWithAnimal(parrot));
            Assert.False(bison.IsFriendlyWithAnimal(turtle));
            Assert.False(bison.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("Grass")]
        [InlineData("Vegetable")]
        public void ShouldGetFavoriteFood(string food)
        {
            var bison = new Bison();
            string favoriteFoodString = string.Join(",", bison.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("Meat")]
        [InlineData("Egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var bison = new Bison();
            string favoriteFoodString = string.Join(",", bison.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Fact]
        public void ShouldNotBeSick()
        {
            var bison = new Bison();
            var grass = new Grass();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            bison.Feed(grass, dateTime, zooKeeper);
            Assert.False(bison.IsSick);
        }
        [Fact]
        public void ShouldBeSick()
        {
            var bison = new Bison();
            var meet = new Meet();
            var zooKeeper = new ZooKeeper("d", "d");
            var dateTime = DateTime.Now;
            bison.Feed(meet, dateTime, zooKeeper);
            Assert.True(bison.IsSick);
        }
        [Theory]
        [InlineData(1000)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var bison = new Bison();
            Assert.Equal(requiresFt, bison.RequiredSpaceSqFt);
        }
    }
}
