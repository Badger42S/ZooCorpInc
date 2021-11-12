using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Bison:Mammal
    {
        public override string[] FavoriteFood { get; } = new string[] { "grass", "vegetable" };
        public override int RequiredSpaceSqFt { get; } = 1000;
        public Bison(int id) : base(id) { }
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Elephant, Bison";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }
    }
}
