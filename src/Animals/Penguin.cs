using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Penguin : Bird
    {
        public override string[] FavoriteFood { get; } = new string[] {"salmon", "herring" };
        public override int RequiredSpaceSqFt { get; } = 10;
        public Penguin(int id) : base(id) { }

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimalList = "Penguin";
            string animalType = animal.GetType().Name;
            return FriendlyAnimalList.Contains(animalType);
        }

    }
}
