using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Mammal
{
    public class Elephant:Mammal
    {
        public override string[] FavoriteFood { get; } = new string[] { "grass", "vegetable", "fruit" };
        public override int RequiredSpaceSqFt { get; } = 1000;
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Bison, Parrot, Turtle";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }
    }
}
