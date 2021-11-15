using Animals;
using Animals.Bird;
using Animals.Reptile;
using System;
using Xunit;
using ZooApps.Employee;

namespace EmployeeTests
{
    public class VeterinarianTest
    {
        [Fact]
        public void ShouldAddExperience()
        {
            string firstName = "Lev";
            string lastName = "Starov";
            var veterinarian = new Veterinarian(firstName, lastName);
            var penguin = new Penguin();
            veterinarian.AddAnimalExperience(penguin);
            Assert.Contains(typeof(Penguin).Name, veterinarian.AnimalExperience);
        }
        [Fact]
        public void ShouldHasExperience()
        {
            string firstName = "Lev";
            string lastName = "Starov";
            string animalExperience = typeof(Penguin).Name;
            Veterinarian veterinarian = new Veterinarian(firstName, lastName, animalExperience);
            Assert.True(veterinarian.HasAnimalExperience(animalExperience));
        }
        [Fact]
        public void ShouldCreateVeterinarian()
        {
            string firstName = "Lev";
            string lastName = "Starov";
            Veterinarian veterinarian = new Veterinarian(firstName, lastName);
            Assert.Equal(firstName, veterinarian.FirstName);
            Assert.Equal(lastName, veterinarian.LastName);
            Assert.Equal(0, veterinarian.AnimalExperience.Length);
        }
        [Fact]
        public void ShouldHealAnimal()
        {
            string firstName = "Lev";
            string lastName = "Starov"; 
            string animalExperience = typeof(Penguin).Name;
            Veterinarian veterinarian = new Veterinarian(firstName, lastName, animalExperience);
            var penguin = new Penguin();
            Assert.False(veterinarian.HealAnimal(penguin));
            var snake = new Snake();
            Assert.True(veterinarian.HealAnimal(snake));
        }

    }
}
