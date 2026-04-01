global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{

    #region calling by value or ref the difference between pass reference type by value and by ref
    //class person
    //{

    //    public int id;
    //    public string name;
    //    public person(int i, string n)
    //    {
    //        id = i;
    //        name = n;

    //    }
    //    public static void Swap(ref int x, ref int y)
    //    {
    //        int temp;
    //        temp = x;
    //        x = y;
    //        y = temp;


    //    }
    //    public static int[] Print(ref int[] arr)
    //    {
    //        for (int i = 0; i < arr.Length; i++)
    //        {
    //            arr[i] += 1;
    //        }
    //        return arr;

    //    }
    //    {
    //    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
    //    int[] arrr = Print(ref arr);
    //        for (int i = 0; i<arrr.Length; i++)
    //        {
    //            Console.WriteLine(arrr[i]);

    //        } 
    //public static void printval( person per)
    //{
    //    Console.WriteLine();

    //    Console.WriteLine(per.GetHashCode());
    //    per = new person(2, "abdo");
    //    Console.WriteLine(per.GetHashCode());//  another ref after the method modifiy it
    //    Console.WriteLine(per.id * 2);
    //    Console.WriteLine(per.name);
    //    // the method will return the passed ref 

    //}
    //public static void printref(ref person per)
    //{
    //    Console.WriteLine();

    //    Console.WriteLine(per.GetHashCode());
    //    per = new person(5, "abdallah");
    //    Console.WriteLine(per.GetHashCode());// another ref after the method modifiy it

    //    Console.WriteLine(per.id * 5);
    //    Console.WriteLine(per.name);
    //    // the method will return the modified ref 


    //}
    //public static void Main()
    //{
    //    person pf = new person(1, "ahmed");
    //    Console.WriteLine(pf.GetHashCode());
    //    Console.WriteLine();

    //    person.printref(ref pf);
    //    Console.WriteLine();

    //    Console.WriteLine(pf.GetHashCode());
    //    Console.WriteLine();


    //    person.printval(pf);
    //    Console.WriteLine();

    //    Console.WriteLine(pf.GetHashCode());
    //    Console.WriteLine();
    //}


    //}
    #endregion
    #region Enum
    //enum Char : byte
    //{
    //    A, B, C, D, E, F

    //}
    //[Flags]
    //enum Permissins : byte
    //{
    //    None = 0b000_000_00,
    //    Read = 0b000_000_01,
    //    Write = 2,
    //    Execute = 0b000_001_00,
    //    Delete = 8,
    //    Admin = 0xF

    //}
    //class Program
    //{
    //    public static void Main()
    //    {

    //        Permissins userper = Permissins.Read | Permissins.Write;
    //        Console.WriteLine(userper);

    //        userper = userper | Permissins.Execute;
    //        Console.WriteLine(userper);

    //        userper ^= Permissins.Execute;//except
    //        Console.WriteLine(userper);

    //        userper = ~Permissins.Execute;//all possible values of [found or not] of the enum minus which after ~ 
    //                                      //255-4=251=>not has a string value so it print its binary value 2^8-2^2
    //        Console.WriteLine(userper);
    //    }

    //}
    

    #endregion
    #region property
    //class Person
    //{
    //    public int Id;
    //    private string? name;
    //    public string? Name
    //    {
    //        get { return name == null ? "NotFound" : name; }
    //        set { name = value?.Length <= 20 ? value : null; }
    //    }
    //    private int salary;
    //    public int Salary
    //    {
    //        get { return salary; }

    //        set { salary = value >=1200?value:1200; }
    //    }

    //}
    #region Automatic Property
    /*class Prop
    {
        // public int Value { get; set; }// automatic property => declare hidden variable (Backing field)but you donot access the attribute you allow
        // access the property only (get,set).
        // when you will use the attribute as when Filteration declare it 
        // for easability
        // 
        // readonly int s; // intializing with declaration or in the ctor only



    }*/
    #endregion
    //static void Main(string[] args)
    //{
    //    Person p = new Person();
    //    p.Id = 1;
    //    Console.WriteLine(p.Id);
    //    p.Name = "Abdo";
    //    Console.WriteLine(p.Name);
    //    Console.WriteLine("dsdddd");
    //    p.Salary = 3000;
    //    Console.WriteLine(p.Salary);

    //} 
    #endregion
    #region Indexer
    //struct PhoneBook
    //{
    //    string[] Names;
    //    long[] Numbers;
    //    int size;
    //    public int Size { get { return size; } }
    //    public PhoneBook(int _Size)
    //    {
    //        size= _Size;
    //        Names= new string[size];
    //        Numbers= new long[size];    

    //    }
    //    public void SetEntry(int index,string name,long number)
    //    {
    //        if(index>=0&&index<size)
    //        {
    //            Names[index]=name;
    //            Numbers[index]=number;
    //        }
    //    }
    //    public long GetNumber(string name)
    //    {
    //        for(int i=0; i<Names.Length; i++)
    //        {
    //            if (Names[i]==name)
    //                return Numbers[i];

    //        }
    //        return -1;
    //    }
    //    public long this[string name]  // hidden input parameter (value)
    //    {
    //        get {
    //            for (int i = 0; i < Names.Length; i++)
    //            {
    //                if (Names[i] == name)
    //                    return Numbers[i];

    //            }
    //            return -1;
    //        }
    //        set {
    //            for(int i = 0; i < Names.Length; i++)
    //            {
    //                if (Names[i] == name)
    //                    Numbers[i]=value;

    //            }
    //        }

    //    }
    //    public string this[int index] 
    //    {
    //        get
    //        {
    //            if (index >= 0 && index < size)
    //            {
    //                return $"{Names[index]} :: {Numbers[index]}";

    //            }
    //            return "NotFound";
    //        }

    //    }
    //    public long this[int index , string name]
    //    {
    //        set 
    //        {
    //            if (index >= 0 && index < size)
    //            {
    //                Names[index] = name;
    //                Numbers[index] = value;
    //            }
    //        }
    //    }
    //}
    //static void Main(string[] args)
    //{
    //    PhoneBook book = new PhoneBook(5);
    //    book.SetEntry(0, "Jack", 123);
    //    book.SetEntry(1, "John", 589);
    //    book.SetEntry(2, "waek", 741);
    //    book["waek"] = 789;
    //    book[4, "abdo"] = 258;
    //    Console.WriteLine(book.Size);
    //    Console.WriteLine(book[4]);

    //} 
    #endregion

    #region Interface

    //interface IPerson
    //{
    //    string Name { get; }    
    //    long Id { get; }
    //    public void SetEntry(long id, string name);
    //    public void Print(long id);

    //}
    //struct Employee : IPerson,IComparable// we use Compareto() in Sort() function so we implented it using IComparable
    //{

    //    string name;
    //    long id;
    //    public Employee(long id, string name)
    //    {
    //        this.id = id;
    //        this.name = name;
    //    }
    //    public string Name
    //    { get
    //        {
    //            return name;
    //        } 

    //    }

    //    public long Id { get { return id; }  }

    //    public int CompareTo(object? obj)
    //    {
    //        if(obj == null)
    //        { return 1; }
    //        Employee e= ( Employee) obj;
    //        return id.CompareTo(e.id);
    //    }

    //    public void Print(long id)
    //    {
    //        Console.WriteLine($"{Name} :: {Id}");
    //    }

    //    public void SetEntry(long id, string name)
    //    {
    //        this.name = name;
    //        this.id = id;               
    //    }
    //}
    //class Program
    //{
    //    public static void GetNextPerson(IPerson person)
    //    {
    //        person.Print(person.Id + 1);

    //    }
    //    static void Main(string[] args)
    //    {
    //        IPerson p;
    //        p = new Employee();
    //        p.SetEntry(1, "John");
    //        p.SetEntry(2, "Jack");
    //        p.SetEntry(3, "Mass");
    //        Console.WriteLine(p.Id);
    //        Console.WriteLine(p.Name);
    //        GetNextPerson(p);

    //        int[] arr = { 1, 5, 2, 4, 7, 8, 9, 6, 4, 5 };
    //        Array.Sort(arr);
    //        foreach (var item in arr) // item => arr[i]
    //        {
    //            Console.WriteLine(item);
    //        }
    //        Employee[] employees = { new Employee(1, "John"), new Employee(2, "Jack"), new Employee(3, "Mass"), new Employee(4, "leen") };
    //        Array.Sort(employees);
    //        for (int i = 0; i < employees.Length; i++)
    //        {
    //            employees[i].Print(i + 1);

    //        }




    //    }
    //} 
    #endregion
    #region Exception
    //class MyEx :Exception
    //{
    //    public MyEx():base("enter Positive number")
    //    { }

    //}
    //class Program
    //{
    //    public static void TestMyEx(int y)
    //    {
    //        if(y < 0) throw new MyEx();
    //    }
    //    public static void Dividebyzero(int x, int y)
    //    {
    //        Exception ex = new Exception();
    //        if (y == 0)
    //            throw ex;
    //        Console.WriteLine(x / y);



    //    }
    //    public static void Divide(int dividend, int divisor)
    //    {
    //        if (divisor == 0)
    //        {
    //            throw new DivideByZeroException("Cannot divide by zero.");
    //        }

    //        int result = dividend / divisor;
    //        Console.WriteLine("Result: " + result);
    //    }
    //    static void Main(string[] args)
    //    {
    //        int x = 5, y = 0;
    //        Divide(x, y);
    //        try
    //        {
    //            TestMyEx(y);
    //        }
    //        catch(MyEx e)
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //        catch (Exception ex) { Console.WriteLine(ex.Message); }





    //    }
    //} 
    #endregion
}