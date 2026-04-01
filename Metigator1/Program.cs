using Metigator1;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
namespace Metigator1
{

    internal class Program
    {
        public static T Firs<T>(IEnumerable<T> seq)
        {
            foreach (var item in seq)
            {
                return item;
            }
            throw new InvalidOperationException("No elements!");

        }
        static void Main(string[] args)
        {
            Console.WriteLine(5.IsDouble());
        }

    }
    public static class StringHelper
    {
        public static int IsDouble(this int i)
        {
            //if (string.IsNullOrEmpty(s)) return false;
            return i*i;
        }
        public static T Fir<T>(this IEnumerable<T> seq)
        {
            foreach (var item in seq)
            {
                return item;
            }
            throw new InvalidOperationException("No elements!");

        }
    }
    
}


    /***** IComparable****
     * class Tempreture : IComparable
    {
        private int Value;
        public Tempreture(int value)
        {
            Value = value;
        }
        public int Valu => Value;

        public int CompareTo(object obj)
        {
            if (obj is null)
                return 1;
            var temp = (Tempreture)obj;
            if (temp is null)
                throw new ArgumentException("object is not a tempreture object");
            return this.Value.CompareTo(temp.Value);
        }
    }
    class student:IComparable
    {
        int grades;
        public student(int v)
        {
            grades = v;

        }
        public int grade { get { return this.grades; } }

        public int CompareTo(object obj)
        {
            var temp = obj as student;
            return this.grade.CompareTo(temp.grade);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var temps = new List<Tempreture>();
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                temps.Add(new Tempreture(r.Next(0, 60)));
            }
            temps.Sort();
            foreach (var item in temps)
            {
                Console.WriteLine(item.Valu);
            }
            Console.WriteLine("////////////////////////////////////////////////////");
            student s = new student(50);
            student s2 = new student(60);
            Console.WriteLine(s.CompareTo(s2));

        }

    }*/




        /*
         * 
         * //////////Generic Delegates///////////////////
         * -----------------------------------------
         *  //public delegate bool filter< in T>(T n);
       // public delegate T transform<T>(T x);//delegate defination before the Main*
         * static void PrintNumber<T>(IEnumerable<T> numbers,Predicate<T> f)
        {
            foreach (var n in numbers)
            {
                if (f(n)) { Console.WriteLine(n); }

            }
            Console.WriteLine("--------------------------");
        }
        static void doble<T>( int x,transform<T> t)
        {
            Console.WriteLine(t);
        }

        static bool square(int n) => n < 6;
        static int cube(int n) => n * n * n;
    }
    public class Person
    {
        public string  fname { get; set; }
        public string lname { get; set; }
        public void dis(string s)
        {
            Console.WriteLine(s);
        }
        public override string ToString()
        {
            return $"{fname} {lname}";
        }
    }
    class Any <T> where T:class
    {
        private T[] items;
        public void Add(T item )
        {
            if (items is null)
            {
                items = new T[] { item };
            }
            else
            {
                var length = items.Length;
                var dest = new T[length + 1];
                for (int i=0;i<length;i++)
                {
                    dest[i] = items[i];
                }
                dest[dest.Length - 1] = item;
                items = dest;
            }
        }
        public void RemoveAt(int pos)
        {
            if (pos < 0 || pos > items.Length)
                return;
            var index = 0;
            var dest = new T[items.Length - 1];
            for (int i = 0; i < items.Length; i++)
            {
                if (pos == i)
                    continue;
                dest[index++] = items[i];
            }
            items=dest;

        }
        public bool isEmpty => items is null || items.Length == 0;
        public int count => items is null ? 0 : items.Length;
        public void Display()
        {
            Console.Write("[");
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items[i]);
                if(i<items.Length-1)
                {
                    Console.Write(" ,");
                }
            }
            Console.Write(" ]");
        }*/





    /* class Eagle:Animal
     {

         public void CanFly() => Console.WriteLine("the Eagle can fly");
         public override void Walk()
         {
             base.Walk();

         }
     }*/





    /**** THE EVENT EXAMPLE***
     * using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Metigator1
{internal class Program
    { 
        static void Main(string[] args)
        {
            Stock stock1 = new Stock("Amazon");
            stock1.Price = 100;
            // 4- add to the event 
            stock1.OnPriceChanged += (Stock stock, decimal oldPrice) =>
            {
                if (stock.Price > oldPrice)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (stock.Price < oldPrice)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{stock.Name}->{stock.Price}");
            };
            stock1.ChangeStockPriceBy(0.1m);
            stock1.ChangeStockPriceBy(-0.2m);

            stock1.ChangeStockPriceBy(0.2m);
            stock1.ChangeStockPriceBy(0.0m);
            //Console.WriteLine( stock1.Name + stock1.Price);


        }

        
     
    }

    public delegate void StockPriceChangeHandler(Stock stock, decimal oldPrice);// 1- def the delegate

    public class Stock
    {
        private string name;
        private decimal price;
        public event StockPriceChangeHandler OnPriceChanged; //2- declare the event
        public Stock(string stockname )
        {
            this.name = stockname;
        }
        public string Name => this.name;
        public decimal Price { get => this.price; set=>this.price=value; }
        public void ChangeStockPriceBy(decimal percent )
        {
            decimal oldPrice = this.price;
            this.price += Math.Round(this.price * percent, 2);
            if(OnPriceChanged !=null)// Make sure there is a subscriber
            {
                OnPriceChanged(this, oldPrice); ///3- FIRING THE EVENT
            }
        }

    }

    *///
    /*
    //public delegate void dell();
    //public class Dell
    //{
    //   public dell del;
    //    public Dell()
    //    {
    //        del = DellFun;
    //    }
    //    private void DellFun() => Console.WriteLine("i am in the delegate class");
        
        
    // }
    //internal class Program
    //{
    //   // public delegate void delPrintHello();
    //    //ublic delegate void delMulti(int x, int y);
    //    public delegate int delFuncs(int x, int y);
    //    static void Main(string[] args)
    //    {

    //        /* delFuncs d1 = Sum;
    //         d1 += Sup;
    //         int result = funcs(5, 5, Sum);
    //         Console.WriteLine(result) ;*/

    //        //FunsDelegate fd ;
    //        //fd += Hi;

    //        // Funs(()=>Console.WriteLine("Hi world")) ;


    //    }

    //    public delegate void FunsDelegate();
    //    static void Hello() => Console.WriteLine("Hello world");
    //    static void Hi() => Console.WriteLine("Hi world");
    //    public static void Funs(FunsDelegate fd)
    //    {
    //       fd();
    //    }


    //    public static int funcs(int x,int y, delFuncs df)
    //        => df(x ,y);

    //    public static int Sup(int x, int y) => (x - y);


    //    public static int Multi(int x,int y) => (x * y);

    //    public static int Sum(int x,int y) => (x + y);


    //}
    public class Employeeee
    {
        private int id;
        private string name;
        private decimal totalsales;
        private string gender;

       /* public Employee(int id, string name, decimal totalsales, string gender)
        {
            this.id = id;
            this.name = name;
            this.totalsales = totalsales;
            this.gender = gender;

        }*/
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalSales { get; set; }
        public string Gender { get; set; }

    }


    // Indexer 
/*
 *   static void Main(string[] args)
    {
        IP i = new IP(192, 168, 1, 1);
        var firsts = i[0];
        i[0] = 2000;
        Console.WriteLine(i.Address);


    }

public class IP
{
    private int[] segments = new int[4];
    public int this[int index]
    {
        get
        {
            return segments[index];
        }

        set
        {
            segments[index] = value;
        }
    }
    public IP(int s1, int s2, int s3, int s4)
    {
        segments[0] = s1;
        segments[1] = s2;
        segments[2] = s3;
        segments[3] = s4;
        segments[0] = s1; 
    }
    public string Address => string.Join(".", segments);
}*/
public class Dollar
{
    private decimal amount;
    public Dollar(decimal amount)
    {
        this.amount = ProcessAmount(amount);
    }

    public decimal Amount
    {
        get { return this.amount; }


        set { this.amount = ProcessAmount(value); }

    }
    private decimal ProcessAmount(decimal v) => v <= 0 ? 0 : Math.Round(v, 2);

}


public class Person
{
    private int Id;
    private string Name;
    private Person()
    {

    }
    private Person(int id,string name )
    {
        this.Id = id;
        this.Name = name;
    }
    public static Person create (int id,string name)
    {
        return new Person(id, name);
    }
    public string Display()
    {
        return Name;
    }


}



public class Ab
{
    int mx;
   public readonly int  xx;
    public Ab( int x)
    {
        mx = x;
        xx = x;
    }
    public void getdata()
    {
        Console.WriteLine(mx+xx);
    }
}
public struct Ahmed
{
    public int x;
    public int y;
}
public class Abdo
{
    public int  DoThing(ref int x)
    {
        x = (x * x + 2);
       return x;
    }
}


























        /* var name = "abdallah";
         var letters = name.ToCharArray();
         string a = "";
         var d = Convert.ToInt32(a, 10);
         Console.WriteLine(d);
         foreach (var l in letters)
         {
             int ascii = Convert.ToInt32(l);
             var output = $"'{l}' --> Ascii {ascii}," +
                 $"Binary : {Convert.ToString(ascii, 2).PadLeft(8, '0')}," +
                 $"Hexa : {ascii:o}";
             Console.WriteLine(output);
         }
        */






/*// Bit Converter
 * var number = 255;
byte[] bytes = BitConverter.GetBytes(number);
Console.WriteLine(bytes[0]);
foreach (var i in bytes)
{
    var bin = Convert.ToString(i, 10).PadLeft(8, '0');
    Console.WriteLine(bin);
}
var binary = Convert.ToString(bytes[0]).PadLeft(8, '0');
Console.WriteLine(binary);*/











