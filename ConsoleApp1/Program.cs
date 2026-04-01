using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* string s;
             string s1 = "hello";
             string s2 = "world";
             s = s1 + " " + s2;
             Console.WriteLine(s);
             s = $"{s1} {s2}";
             Console.WriteLine(s);
             Console.WriteLine($"int: [{int.MinValue} → {int.MaxValue}]");
             Console.WriteLine("the s1 contain {0}",s1);*/


            var z = quiz()||test();
            //bool x = true | test();
            //bool m = quiz() | true;
            //bool y = quiz() | test();
           // bool n = quiz() || test();
            //bool s = quiz()|| true;
           // bool s = true&&quiz() ;
            Console.WriteLine(z+"\n");
            //Console.WriteLine(x + "\n");
            // Console.WriteLine(m + "\n");
            //Console.WriteLine(y + "\n");
            //Console.WriteLine(n + "\n");
            //Console.WriteLine(s + "\n");


            Console.ReadKey();
          

        }
        public static bool test()
        {
            Console.WriteLine("hello world\n");
            return true;
        }
        public static bool quiz()
        {
            Console.WriteLine("welcome 2023\n");
            return true;
        }

    }
}
