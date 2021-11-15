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
    public class ParrotTest
    {
        [Fact]
        public void ShouldBeFriendly()
        {
            var parrot = new Parrot();
            var parrot2 = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            var turtle = new Turtle();
            Assert.True(parrot.IsFriendlyWithAnimal(parrot2));
            Assert.True(parrot.IsFriendlyWithAnimal(bison));
            Assert.True(parrot.IsFriendlyWithAnimal(elephant));
            Assert.True(parrot.IsFriendlyWithAnimal(turtle));
        }
        [Fact]
        public void ShouldNotBeFriendly()
        {
            var parrot = new Parrot();
            var lion = new Lion();
            var snake = new Snake();
            var penguin = new Penguin();
            Assert.False(parrot.IsFriendlyWithAnimal(snake));
            Assert.False(parrot.IsFriendlyWithAnimal(lion));
            Assert.False(parrot.IsFriendlyWithAnimal(penguin));
        }
        [Theory]
        [InlineData("fruit")]
        [InlineData("vegetables")]
        public void ShouldGetFavoriteFood(string food)
        {
            var parrot = new Parrot();
            string favoriteFoodString = string.Join(",", parrot.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("grass")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var parrot = new Parrot();
            string favoriteFoodString = string.Join(",", parrot.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
        }
        [Theory]
        [InlineData(5)]
        public void ShouldBeRequireSsquareFeet(int requiresFt)
        {
            var parrot = new Parrot();
            Assert.Equal(requiresFt, parrot.RequiredSpaceSqFt);
        }
    }
}
