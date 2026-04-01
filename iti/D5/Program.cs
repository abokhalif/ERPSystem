using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace D5
{
    #region D5_P1=>Class and Ctor


    /*class Car : IComparable,ICloneable
{
    int id;
    string model;
    int speed;

    public int Id { get => id; set => id = value; }
    public string Model { get => model; set => model = value; }
    public int Speed { get => speed; set => speed = value; }

    public Car(int id, string model, int speed)
    {
        Id = id;
        Model = model;
        Speed = speed;

    }
    public Car(int id) { this.id = id; }

    // Copy Constructor => return anew objet with the same state of the this object
    public Car(Car old)
    {
        id = old.Id;
        model = old.Model;
        speed = old.Speed;

    }
    // implement Clone() function from IClonable 
    public object Clone()
    {
        return new Car(this);
        //return new Car(id,model, speed);
    }

    public int CompareTo(object? obj)
    {
        Car c= (Car) obj;
        return Speed.CompareTo(c.Speed);
    }
        /*public Car(int id) :this(id,"BMW",120)
            { 
            // without dublicate the code we can use Constractor Chaining 
            //this.id= id;
            //this.model = "BMW";
            //this.speed = 120;          

        }*/
    // without Constractor Chaining we can use default value on the Ctor parameters
    /*public Car(int _id,string _model ="Fiat",int _speed=120 )
    {
        this.id = _id;
        this.model = _model;
        this.speed = _speed;

    }
}
internal class Program
{

    static void Main(string[] args)
    {
        Car c1 = new Car(101,"BMW",180);
        Car c2 = new Car(102,"FIAT",120);
        Console.WriteLine(c1.GetHashCode());
        Console.WriteLine(c2.GetHashCode());
        Console.WriteLine(c1.CompareTo(c2)); // 1

        // c2 => new object with new identity, same state as c1 

        //c2 = new Car(c1);    // copy constructor
        c2 = (Car)c1.Clone();

        Console.WriteLine(c2.Speed);
        Console.WriteLine(c1.GetHashCode());
        Console.WriteLine(c2.GetHashCode());
        Console.WriteLine(c1.CompareTo(c2));//0



    }

}*/
    #endregion

    #region static members and atatic class
    //class Utility
    //{
    //    int x;
    //    int y;
    //    static int z;
    //    public void print()
    //    {
    //        Console.WriteLine("the multiplecation of x*y = ");
    //    }
    //    // static Ctor => exuted one time per life time program
    //    //    parameterless,canot specify  Access modifier
    //     //    one static ctor per class and not found static destractor
    //    static Utility ()
    //    {
    //        z = 2;
    //        Console.WriteLine(z);
    //    }
    //    public static int Get(Utility p)
    //    {
    //        //print(); // nonstatic member
    //        //return x * y; // static function cannot access the nonstatic member , functions,properties
    //        return p.x * p.y;// can access when pass an object refrence
    //    }
    //}

    // static class => contain only static members
    //   No object can be created
    // no inheritance
    //static class Utility2
    //{
    //    static int z;
    //    static Utility2()
    //    {
    //        z = 2;
    //        Console.WriteLine(z);
    //    }
    //    public static void Print()
    //    {
    //        z = 5555555;
    //        Console.WriteLine(z);
    //    }
    //}
    #endregion

    #region Singleton design Pattern
    //class GraphicCard   // v1=> the old version in c++
    //{
    //    // req ==> I need to generate an Max only one object from a class
    //    public int Data { get; protected set; }
    //    // 1- create a private ctor to control the intialization of object
    //    GraphicCard(int d )
    //    {
    //        Data = d;
    //        Console.WriteLine(" the Constructor");
    //    }
    //    // 2- crate a static method that return an object from the class
    //    // v1
    //    /*public static GraphicCard GetGraphicCard () // control the intialization of data but can create many objects
    //    {
    //        return new GraphicCard(10001);
    //    }*/
    //    // v2
    //    static GraphicCard? SingleCard;// if non static => that force me to genarate an object but the ctor is private so the refrence and the method is static
    //                                   // member variable => if it inside the scope of the function it terminate when the function terminate but i need it still to i can compare it if is null or not
    //                                   // intialized default value is null 
    //    public static GraphicCard GetGraphicCard()
    //    {
    //        //GraphicCard SingleCard;// local variable => should intialized when the method created and its scope within the method only but i need class scope
    //        if(SingleCard== null)
    //            SingleCard = new GraphicCard(1001); 
    //        return SingleCard;


    //    }
    //class GraphicCard // v2 => old c#
    //{
    //    public int Data { get; protected set; }
    //    static GraphicCard singleObj;
    //    GraphicCard(int d)
    //    {
    //        Data = d;
    //        Console.WriteLine(" the Constructor");
    //    }

    //    static GraphicCard()
    //    {
    //        singleObj = new GraphicCard(1001);
    //    }
    //    public static GraphicCard GetCard()
    //    {
    //        return singleObj;
    //    }


    //}
    //class GraphicCard // v3 => new c#
    //{
    //    public int Data { get; protected set; }
    //    GraphicCard(int d)
    //    {
    //        Data = d;
    //        Console.WriteLine(" the Constructor");
    //    }
    //    public static GraphicCard GetCard { get; } = new GraphicCard(1001); 


    //}


    //internal class Program
    //{

    //    static void Main(string[] args)
    //    {
    //        // v1 
    //        //GraphicCard g=new GraphicCard  ();
    //        //GraphicCard g1 = GraphicCard.GetGraphicCard();
    //        //Console.WriteLine(g1.GetHashCode());// 54267293
    //        //GraphicCard g2 = GraphicCard.GetGraphicCard();
    //        //Console.WriteLine(g2.GetHashCode());//54267293 the same HashCode

    //        // v2
    //        //GraphicCard g=GraphicCard.GetCard();
    //        //Console.WriteLine(g);

    //        // v3
    //        //GraphicCard g = GraphicCard.GetCard;
    //        //Console.WriteLine(g);






    //    }
    //}

    #endregion

    #region Operator overloading
    //class Operator
    //{
    //    public int Right { get; set; }
    //    public int Left { get; set; }
    //    // 1- to use p3 = p1 + p2;
    //    public static Operator operator +(Operator o1, Operator o2)
    //    {
    //        return new Operator()
    //        {
    //            //Op1 = o1.Op1 + o2.Op1, // unsafe code cause the params can nullable and you do not handle the nullable value
    //            //Op2 = o1.Op2 + o2.Op2

    //            //Op1 = o1?.Op1 + o2?.Op1, // op1 ==> int value && o1.op1 ==> nullable int value
    //            //Op2 = o1?.Op2 + o2?.Op2

    //            Right = (o1?.Right ?? 0) + (o2?.Right ?? 0), // Logic error  op1=Op1 = o1?.Op1?? && the copiler consider that (0 + o2?.Op1??0) as a separate operation 
    //            Left = (o1?.Left ?? 0) + (o2?.Left ?? 0)  // so that we use ()  to avoid the Logoc Error         
    //        };

    //    }
    //    // 2- to use p = p1 + int value
    //    public static Operator operator +(Operator o1, int x)
    //    {
    //        return new Operator()
    //        {
    //            Right = (o1?.Right ?? 0) + x
    //        };

    //    }
    //    // 3- to use  p =  int value + p2
    //    public static Operator operator +(int x, Operator o2)
    //    {
    //        return new Operator()
    //        {
    //            Right = x + (o2?.Right ?? 0)
    //        };

    //    }
    //    // * unary arithemitic operator
    //    public static Operator operator -(Operator o)
    //    {
    //        return new Operator() { Right = -o.Right, Left = -o.Left };
    //    }
    //    // *Compund operartor (++) Postfix ,Prefix 
    //    public static Operator operator ++(Operator o)
    //    {
    //        return new Operator() { Right = o.Right + 1, Left = o.Left + 1 }; // if we use (++) instead of (+1) in (Op1 = o.Op1+1) will Arithemitic Error
    //    }
    //    // *Greater than and smaller than operator (><) (== !=) (<= >=)
    //    // the compiler enforce you to overload the both (> <) 
    //    public static bool operator >(Operator o1, Operator o2)
    //    {
    //        if (o1.Right == o2.Right)
    //            return o1.Left > o2.Left;
    //        return o1.Right > o1.Left;
    //    }
    //    public static bool operator <(Operator o1, Operator o2)
    //    {
    //        if (o1.Right == o2.Right)
    //            return o1.Left > o2.Left;
    //        return o1.Right < o2.Right;
    //    }
    //    // implicit and explict operator do not take retun datatype
    //    public static explicit operator int(Operator o) { return o?.Right ?? 0; }// if change the explicit operator to (implicit) any operation like (p1=p2+p3) will return the first attribute not the both=>(Right,Left)
    //    public static explicit operator string(Operator o) { return o?.ToString() ?? "NotFound"; }

    //    /// <summary>
    //    /// I can create operator casting between any two userdefined data type as class&&class | Class&& struct ...... 
    //    /// </summary>
    //    /// <returns></returns>
    //    public override string ToString()
    //    {
    //        return $"{Right}+{Left}";
    //    }

    //}
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Operator p1 = new Operator() { Right = 10, Left = 20 };
    //        Operator p2 = new Operator() { Right = 30, Left = 40 };
    //        Operator p3 = new Operator();
    //        Operator p4 = new Operator();
    //        Operator p5 = new Operator();
    //        Operator p6 = new Operator();
    //        Operator p7 = new Operator();
    //        Operator p8 = new Operator();
    //        Operator p9 = new Operator();
    //        Operator p10 = new Operator();
    //        p3 = p1 + p2;
    //        p4 = p1 + 5;
    //        p5 = 5 + p2;
    //        p6 += p1;// when you make an explict overload on (+) you can use Compund operator by default cause (=) can not oveload
    //        p7 = (-p1) + p2;
    //        p8 = ++p1;
    //        p9 = p2++;
    //        p10 = p2;
    //        int n = (int)p1;
    //        string s = (string)p1;

    //        Console.WriteLine(p3); ////40+60
    //        Console.WriteLine(p4); //15 + 0
    //        Console.WriteLine(p5); //35 + 0
    //        Console.WriteLine(p6); //10 + 20
    //        Console.WriteLine(p7); //20 + 20
    //        Console.WriteLine(p8); //11 + 21
    //        Console.WriteLine(p9); //30 + 40
    //        Console.WriteLine(p10);// 31 + 41
    //        Console.WriteLine(p1 > p2);
    //        Console.WriteLine(p1 < p2);
    //        Console.WriteLine(n);
    //        Console.WriteLine(s);


    //    }
    //}

    //implicit Operator
    // The implicit operator allows for a type conversion that doesn't require an explicit cast. This is used when the conversion is guaranteed to succeed and there is no risk of data loss.

    //public class Meter
    //{
    //    public double Value { get; }

    //    public Meter(double value)
    //    {
    //        Value = value;
    //    }

    //    // Implicit conversion from double to Meter
    //    public static implicit operator Meter(double value)
    //    {
    //        return new Meter(value);
    //    }

    //    // Implicit conversion from Meter to double
    //    public static implicit operator double(Meter meter)
    //    {
    //        return meter.Value;
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Meter meter = 10.5; // Implicit conversion from double to Meter
    //        double value = meter; // Implicit conversion from Meter to double

    //        Console.WriteLine("Meter: " + meter.Value); // Output: Meter: 10.5
    //        Console.WriteLine("Value: " + value);       // Output: Value: 10.5
    //    }
    //}


    //explicit Operator
    /*
     The explicit operator requires an explicit cast to be used when converting between types. This is typically used when there is a potential for data loss, or when the conversion might fail, so the user must explicitly state their intent to perform the conversion.*/
    //public class Fraction
    //{
    //    public int Numerator { get; }
    //    public int Denominator { get; }

    //    public Fraction(int numerator, int denominator)
    //    {
    //        Numerator = numerator;
    //        Denominator = denominator;
    //    }

    //    // Explicit conversion from Fraction to double
    //    public static explicit operator double(Fraction fraction)
    //    {
    //        if (fraction.Denominator == 0)
    //            throw new DivideByZeroException("Denominator cannot be zero.");

    //        return (double)fraction.Numerator / fraction.Denominator;
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Fraction fraction = new Fraction(3, 4);

    //        // Explicit conversion from Fraction to double
    //        double value = (double)fraction;

    //        Console.WriteLine("Fraction as double: " + value); // Output: Fraction as double: 0.75
    //    }
    //}



    #endregion
  
    //internal class Program
    //{
    //    public static int Add(int a, int b)
    //    {
    //        int c = 2;
    //        return a + b *c;
    //    }
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine(Add(2, 5));
    //    }
    //}

}
