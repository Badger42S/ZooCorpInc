using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Reptile
{
    public class Snake:Reptile
    {
        public override string[] FavoriteFood { get; } = new string[] { "Meet" };
        public override int RequiredSpaceSqFt { get; } = 2;
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Snake";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }
    }
}
