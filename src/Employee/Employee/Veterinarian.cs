using System;

namespace Employee
{
    public class Veterinarian : IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Veterinarian(string firstName, string lastName)
        {

        }

        public void AddAnimalExperience(object animal1, object animal2)
        {
            throw new NotImplementedException();
        }
    }
}
