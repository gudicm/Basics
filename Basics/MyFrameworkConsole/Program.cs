using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;

namespace MyFrameworkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Car c = new Car("truck","Pegout");
            Console.WriteLine(String.Format("{0}:{1}",c.Type, c.Name));
            

        }

    }
}
