using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.FakeServices
{
    public class Printer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Console.WriteLine("----------------------------------" +
                "I'm a printer service" +
                "---------------------------------");
            Console.WriteLine("----------------------------------" +
                "You got it, this is your first fake service" +
                "---------------------------------");
        }
    }
}
