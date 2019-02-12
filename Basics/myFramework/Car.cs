using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework
{
    public class Car

    {
        public String Type { get; set; }
        public String Name { get; set; }

        public Car(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
