using Employee;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Validators
{
    public interface IHireValidator
    {
        List<string> ValidateEmployee(IEmployee employee);
    }
}
