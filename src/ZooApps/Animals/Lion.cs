using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Mammal
{
    public class Lion : Mammal
    {
        public override string[] FavoriteFood { get; } = new string[] { "Meet" };
        public override int RequiredSpaceSqFt { get; } = 1000;
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Lion";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }
    }
}
