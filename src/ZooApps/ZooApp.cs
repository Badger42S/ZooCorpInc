using System;
using System.Collections.Generic;
using ZooApps.Zoos;

namespace ZooApps
{
    public class ZooApp
    {
        public List<Zoo> ZooList { get; private set; } = new();
        public void AddZoo(Zoo zoo)
        {
            ZooList.Add(zoo);
            Console.WriteLine($"{zoo.Location} zoo was added to application");
        }
    }
}
