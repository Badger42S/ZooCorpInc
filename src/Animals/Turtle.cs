using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Turtle:Reptile
    {
        public Turtle(int id) : base(id) { }
        public override string[] FavoriteFood { get; } = new string[] { "grass", "vegetable" };
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string notCompatibility = "lion, bison, snake";
            string animalType = animal.GetType().Name.ToLower();
            return !notCompatibility.Contains(animalType);
        }
    }
}
