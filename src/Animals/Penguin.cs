using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Penguin : Bird
    {
        public Penguin(int id) : base(id) { }
        public override string[] FavoriteFood { get; } = new string[] {"salmon", "herring" };
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string notCompatibility = "snake, lion";
            string animalType = animal.GetType().Name.ToLower();
            return !notCompatibility.Contains(animalType);
        }

    }
}
