using ZooApps.Employee;
using System;
using System.Collections.Generic;

namespace ZooApps.Validators
{
    public abstract class HireValidator:IHireValidator
    {
        public abstract List<string> ValidateEmployee(IEmployee employee);
    }
}
