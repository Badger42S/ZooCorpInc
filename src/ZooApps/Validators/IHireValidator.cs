using ZooApps.Employee;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooApps.Validators
{
    public interface IHireValidator
    {
        List<string> ValidateEmployee(IEmployee employee);
    }
}
