using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using Xunit;

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
        [InlineData("grass")]
        [InlineData("vegetable")]
        public void ShouldGetFavoriteFood(string food)
        {
            var bison = new Bison();
            string favoriteFoodString = string.Join(",", bison.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meat")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var bison = new Bison();
            string favoriteFoodString = string.Join(",", bison.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
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
