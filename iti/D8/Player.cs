using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8
{
    internal class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }

        ///CallBackMethod
        ///Match event Delegate Signature
        ///V1
        //public void Run()
        //{
        //    Console.WriteLine($"Player {Name} is Running .....");
        //}
        // v2
        public void Run(Location location)
        {
            Console.WriteLine($"Player {Name} is Running To {location}..");
        }
        public override string ToString()
            => $"Player : {Name} , Team : {Team}";
    }
}
