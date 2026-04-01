using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8
{
    internal class Refree
    {
        public string Name { get; set; }

        ///CallBackMethod
        // V1
        //public void Look()
        //{
        //    Console.WriteLine($"Refree {Name} is looking At Ball");
        //}
        public void Look(Location l)
        {
            Console.WriteLine($"Refree {Name} is looking At Ball in {l}");
        }
        public override string ToString() => Name;
    }
}
