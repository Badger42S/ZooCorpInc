using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class ZooKeeper: IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ZooKeeper(string firstName, string lastName)
        {

        }

        public void AddAnimalExperience(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
