using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Parrot:Bird
    {
        public override string[] FavoriteFood { get; } = new string[] { "fruit", "vegetables" };
        public override int RequiredSpaceSqFt { get; } = 5;
       // public Parrot(int id) : base(id) { }
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Parrot, Bison, Elephant, Turtle";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }

    }
}
