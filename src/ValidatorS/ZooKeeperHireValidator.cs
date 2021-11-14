using Employee;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    class ZooKeeperHireValidator : HireValidator, IHireValidator
    {
        public HashSet<string> AnimalsType { get; }
        public ZooKeeperHireValidator(HashSet<string> animalsType)
        {
            AnimalsType = animalsType;
        }
        public override List<string> ValidateEmployee(IEmployee employee)
        {
            var errorList = new List<string> { };
            var veterinarian = (ZooKeeper)employee;
            var veterinarianExperience = veterinarian.AnimalExperience.Split(",");
            var experienceIntersect = AnimalsType.Intersect(veterinarianExperience);
            if (experienceIntersect.Count() == 0)
            {
                errorList.Add("No needed experience");
            }
            return errorList;
        }
    }
}
