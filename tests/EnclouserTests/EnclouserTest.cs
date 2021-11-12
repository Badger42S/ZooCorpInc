using Animals;
using Enclousers;
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
        public void ShouldHaveAddedAnimals()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo, 1000);
            var parrot = new Parrot(7);
            var lion = new Lion(6);
            enclouser.AddAnimals(parrot);
            enclouser.AddAnimals(lion);
            Assert.Equal(parrot, enclouser.Animals[0]);
            Assert.Equal(lion, enclouser.Animals[1]);
        }
    }
}
