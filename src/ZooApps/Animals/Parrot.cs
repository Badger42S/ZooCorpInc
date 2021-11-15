using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApps.Employee;
using ZooApps.Foods;

namespace Animals.Bird
{
    public class Parrot:Bird
    {
        public override string[] FavoriteFood { get; } = new string[] { "Vegetable" };
        public override int RequiredSpaceSqFt { get; } = 5;
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Parrot, Bison, Elephant, Turtle";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }
    }
}
