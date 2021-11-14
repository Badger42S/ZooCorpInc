using Animals;
using Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class HireValidatorProvider
    {
        public IHireValidator GetHireValidator(IEmployee employee, HashSet<string> animalsType)
        {
            IHireValidator employeeValidator = null;
            if (employee.GetType().Name == "Veterinarian")
            {
                employeeValidator = new VeterinarianHireValidator(animalsType);
            }
            else if (employee.GetType().Name == "ZooKeeper")
            {
                employeeValidator = new ZooKeeperHireValidator(animalsType);
            }
            return employeeValidator;
        }
    }
}
