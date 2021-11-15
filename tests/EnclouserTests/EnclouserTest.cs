using Animals.Bird;
using Animals.Mammal;
using Animals.Reptile;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;
using ZooApps.Enclousers;
using ZooApps.Exceptions;
using ZooApps.Zoos;

namespace EnclouserTests
{
    public class EnclouserTest
    {
        [Fact]
        public void ShouldBeCreateEnclouser()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo.Location, 1000);
            Assert.Equal("savannah", enclouser.Name);
            Assert.Equal("Toronto", enclouser.ParentZoo);
            Assert.Equal(1000, enclouser.SqureFeet);
        }
        [Fact]
        public void ShouldAddAnimalsInFreeSpace()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo.Location, 2000);
            var lion = new Lion();
            var lion2 = new Lion();
            enclouser.AddAnimals(lion);
            enclouser.AddAnimals(lion2);
            Assert.Equal(lion, enclouser.Animals[0]);
            Assert.Equal(lion2, enclouser.Animals[1]);
        }
        [Fact]
        public void ShouldAddAnimalsWithUniqueID()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo.Location, 50000);
            var turtle = new Turtle();
            var parrot = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            enclouser.AddAnimals(turtle);
            enclouser.AddAnimals(parrot); 
            enclouser.AddAnimals(bison);
            enclouser.AddAnimals(elephant);
            Assert.NotEqual(turtle.ID, parrot.ID);
            Assert.NotEqual(elephant.ID, bison.ID);
            Assert.NotEqual(turtle.ID, bison.ID);
        }
        [Fact]
        public void ShouldNotAddAnimalToCloseSpace()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo.Location, 1000);
            var lion = new Lion();
            var lion2 = new Lion();
            enclouser.AddAnimals(lion);
            Assert.Throws<NoAvalibaleSpaceException>(()=>enclouser.AddAnimals(lion2));
        }
        [Fact]
        public void ShouldNotAddNotFriendlyAnimal()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo.Location, 5000);
            var lion = new Lion();
            var parrot = new Parrot();
            enclouser.AddAnimals(lion);
            Assert.Throws<NotFriendlyAnimalException>(() => enclouser.AddAnimals(parrot));
        }
        [Fact]
        public void ShouldAddFriendlyAnimals()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo.Location, 50000);
            var turtle = new Turtle();
            var turtle2 = new Turtle();
            var parrot = new Parrot();
            var bison = new Bison();
            var elephant = new Elephant();
            enclouser.AddAnimals(turtle);
            enclouser.AddAnimals(turtle2);
            enclouser.AddAnimals(parrot);
            enclouser.AddAnimals(bison);
            enclouser.AddAnimals(elephant);
            Assert.Equal(5, enclouser.Animals.Count);
        }
        [Fact]
        public void ShouldBePrintAddMessage()
        {
            var zoo = new Zoo("Toronto");
            var enclouser = new Enclouser("savannah", zoo.Location, 2000);
            var lion = new Lion();
            var outputPoint = new StringWriter();
            Console.SetOut(outputPoint);
            string outputMessage = $"{lion.GetType().Name} {lion.ID} was added  to Enclose {enclouser.Name}";
            enclouser.AddAnimals(lion);
            Assert.Equal(outputMessage, Regex.Replace(outputPoint.ToString(), @"[\r\t\n]+", string.Empty));
        }
       
    }
}
