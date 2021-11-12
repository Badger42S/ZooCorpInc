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
        public Parrot(int id) : base(id) { }
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string notCompatibility = "snake";
            string animalType = animal.GetType().Name.ToLower();
            return !notCompatibility.Contains(animalType);
        }

    }
}
