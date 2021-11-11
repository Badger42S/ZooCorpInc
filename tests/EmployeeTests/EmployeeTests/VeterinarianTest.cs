using Employee;
using System;
using Xunit;

namespace EmployeeTests
{
    public class VeterinarianTest
    {
        [Fact]
        public void ShouldAddExperience()
        {
            string firstName = "Ivan";
            string lastName = "Korolev";
            Veterinarian veterinarian = new Veterinarian(firstName, lastName);
            //veterinarian.AddAnimalExperience(animal);
        }
    }
}
