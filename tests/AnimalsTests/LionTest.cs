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
       [InlineData("meet")]
       public void ShouldGetFavoriteFood(string food)
       {
           var lion = new Lion();
           string favoriteFoodString = string.Join(",", lion.FavoriteFood);
           Assert.Contains(food, favoriteFoodString);
       }
       [Theory]
       [InlineData("grass")]
       [InlineData("egg")]
       public void ShouldNotGetBadFood(string badFood)
       {
           var lion = new Lion();
           string favoriteFoodString = string.Join(",", lion.FavoriteFood);
           Assert.DoesNotContain(badFood, favoriteFoodString);
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
