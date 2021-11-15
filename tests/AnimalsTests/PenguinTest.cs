
using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;

using Xunit;

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
        [InlineData("salmon")]
        [InlineData("herring")]
        public void ShouldGetFavoriteFood(string food)
        {
            var penguin = new Penguin();
            string favoriteFoodString = string.Join(",", penguin.FavoriteFood);
            Assert.Contains(food, favoriteFoodString);
        }
        [Theory]
        [InlineData("meat")]
        [InlineData("egg")]
        public void ShouldNotGetBadFood(string badFood)
        {
            var penguin = new Penguin();
            string favoriteFoodString = string.Join(",", penguin.FavoriteFood);
            Assert.DoesNotContain(badFood, favoriteFoodString);
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
