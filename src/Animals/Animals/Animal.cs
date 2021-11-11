using Medicines;
using System;

namespace Animals
{
    public abstract class Animal
    {
        public bool IsSick { get; private set; } = true;

        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }
    }
}
