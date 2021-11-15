using ZooApps.Employee;
using System;
using System.Collections.Generic;

namespace ZooApps.Validators
{
    public abstract class HireValidator
    {
        public abstract List<string> ValidateEmployee(IEmployee employee);
    }
}
