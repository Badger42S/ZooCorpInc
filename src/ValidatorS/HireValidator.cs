using Employee;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Validators
{
    public abstract class HireValidator
    {
        public abstract List<string> ValidateEmployee(IEmployee employee);
    }
}
