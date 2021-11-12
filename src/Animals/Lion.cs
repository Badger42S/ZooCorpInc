using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Lion : Mammal
    {
        public override string[] FavoriteFood { get; } = new string[] { "meet" };
        public override int RequiredSpaceSqFt { get; } = 1000;
        public Lion(int id) : base(id) { }
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Lion";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }
    }
}
