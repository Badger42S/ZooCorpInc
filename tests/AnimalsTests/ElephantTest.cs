using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using Xunit;

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
        [InlineData("grass")]
        [InlineData("vegetable")]
        [InlineData("fruit")]
        public void ShouldGetFavoriteFood(string food)
        {
            var elephant = new Elephant();
            string favoriteFoodString = string.Join(",", elephant.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meat")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var elephant = new Elephant();
            string favoriteFoodString = string.Join(",", elephant.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
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
