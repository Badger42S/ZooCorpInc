using Animals;
using Enclousers;
using Exceptions;
using System;
using System.Collections.Generic;
using Employee;

namespace Zoos
{
    public class Zoo
    {
        public string Location { get; private set; }
        public List<Enclouser> Enclouseres { get; private set; } = new() { };
        public List<IEmployee> Employees { get; private set; } = new() { };


        public Zoo(string location)
        {
            Location = location;
        }

        public void AddEnclouser(string name, int squareFeet)
        {
            var enclouser = new Enclouser(name, Location, squareFeet);
            Enclouseres.Add(enclouser);
        }

        public Enclouser FindAvailableEnclouser(Animal animal)
        {
            Enclouser availableEnclouser = null;

            foreach (var enclousere in Enclouseres)
            {
                try
                {
                    enclousere.AddAnimals(animal);
                    availableEnclouser = enclousere;
                    break;
                }
                catch { }
            }

            if(availableEnclouser is null)
            {
                throw new NoAvailableEnclouserException();
            }

            return availableEnclouser;                
        }

        public void HireEmployee(IEmployee employee)
        {
            Employees.Add(employee);
        }
    }
}
