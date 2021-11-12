using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Lion : Mammal
    {
        public Lion(int id) : base(id) { }
        public override string[] FavoriteFood { get; } = new string[] { "meet" };
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string notCompatibility = "bison, penguin, elephant, snake";
            string animalType = animal.GetType().Name.ToLower();
            return !notCompatibility.Contains(animalType);
        }
    }
}
