using Animals;
using Enclousers;
using Exceptions;
using System;
using Xunit;
using Zoos;

namespace EnclouserTests
{
    public class EnclouserTest
    {
        [Fact]
        public void ShouldBeCreateEnclouser()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo, 1000);
            Assert.Equal("savannah", enclouser.Name);
            Assert.Equal(zoo, enclouser.ParentZoo);
            Assert.Equal(1000, enclouser.SqureFeet);
        }
        [Fact]
        public void ShouldAddAnimalsOnFreeSpace()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo, 2000);
            var lion = new Lion(7);
            var lion2 = new Lion(6);
            enclouser.AddAnimals(lion);
            enclouser.AddAnimals(lion2);
            Assert.Equal(lion, enclouser.Animals[0]);
            Assert.Equal(lion2, enclouser.Animals[1]);
        }
        [Fact]
        public void ShouldNotAddAnimalToCloseSpace()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo, 1000);
            var lion = new Lion(7);
            var lion2 = new Lion(6);
            enclouser.AddAnimals(lion);
            Assert.Throws<NoAvalibaleSpaceException>(()=>enclouser.AddAnimals(lion2));
        }
        [Fact]
        public void ShouldNotAddNotFriendlyAnimal()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo, 5000);
            var lion = new Lion(7);
            var parrot = new Parrot(6);
            enclouser.AddAnimals(lion);
            Assert.Throws<NotFriendlyAnimalException>(() => enclouser.AddAnimals(parrot));
        }
        [Fact]
        public void ShouldAddFrindlyAnimals()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo, 50000);
            var turtle = new Turtle(1);
            var turtle2 = new Turtle(2);
            var parrot = new Parrot(3);
            var bison = new Bison(4);
            var elephant = new Elephant(5);
            enclouser.AddAnimals(turtle);
            enclouser.AddAnimals(turtle2);
            enclouser.AddAnimals(parrot);
            enclouser.AddAnimals(bison);
            enclouser.AddAnimals(elephant);
            Assert.Equal(5, enclouser.Animals.Count);
        }
    }
}
