namespace D6
{
    // D6 p1
    #region Class Equality
    
      class Point
     { 
         //private int x;
         //private int y;
         //private int z;
         public int X { get; set; }
         public int Y { get; set; }
         public int Z { get; set; }
         public Point(int x,int y,int z)
         {
             X = x;
             Y = y;
             Z = z;
         }
         //Try to Cast Point3D to string type
         public static explicit operator string(Point p) => p?.ToString() ?? "NotFound";


         public override string ToString()
         {
             return $"Point Coordinates:({X}, {Y}, {Z})";
         }
         // override object.Equals => Class (ref) Equality 
         // **************optimization Code********
         public override bool Equals(object? obj)
         {
             Point? point = obj as Point; // casting ising as or is
             if (point == null) return false; // check nullable
             if (this.GetType() != point?.GetType()) return false;// check type => occurding to (Base class = derived class) and casting derived to the base so they not the same type then they not Equals 
             if (Object.ReferenceEquals(this, point)) return true;  // check THE SAME REFRENCE OR NOT => donot use (==) operator beacause it may make opereator overloading
                                                                    //  => if the two object have the same ref (identity) then have the same values +==> optimization the code 
             return (this?.X == point?.X && this?.Y == point?.Y && this?.Z == point?.Z);//check the values of the attribute 

         }
     }

     struct Emp
     {
         public int Id { get; set; }
         public int Salary { get; set; }
         public Emp(int i,int s)
         {
             Id= i;
             Salary= s;
         }
         public override bool Equals( object obj)
         {
             Emp e = (Emp)obj;
             return (Id == e.Id && Salary == e.Salary);
         }

     }
     internal class Assignments
     {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 2, 3);
            Point p2 = p1;
            Point p3 = new Point(1, 2, 3);
            // .Equals() => depend on the Identity 
            Console.WriteLine(p1.Equals(p2));// p1&p2 is the same Identity , mean that p1,p2 references to the same object
            Console.WriteLine(p3.Equals(p1));// true => because the same values [check Equals override]p1,p3 is the same values but diffrerent Identity , p1 ref to object not the same object of p3
            Point? p4 = default;
            Console.WriteLine(p1.Equals(p4));
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p1);
            Console.WriteLine(p1 == p3);//f == => check reference only [ not recommend to use because overloading]
            object o = new object();
            object o1 = new object();
            o.Equals(o1);
            Console.WriteLine(  "Dddddddddddddddddd");
            //value Equality 
            Emp e1 = new Emp(101, 3000);
            Emp e2 = new Emp(101, 3000);
            Emp e3 = e1;
            //Console.WriteLine(object.ReferenceEquals(e1,e3)); // false => this method for Reference equality only 
            Console.WriteLine(e1.Equals(e2));
            Console.WriteLine(e1.Equals(e3));
        }

    }

}
    #endregion

    // D6 p2
    #region Virtual and override
    /*class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Parent(int x, int y)
        {
            X = x;
            Y = y;
        }
        //Statically Binded Methods (Non Virtual)
        public void StaticallyBindedShow()
        {
            Console.WriteLine($"In the Base Class");
        }
        // Conditions to virtual method
        // 1- non private (public , internal ,prot...)
        // 2- To override on it use the same access modifier
        // 3- override on the child class only 
        internal virtual void DynamicallyBindedShow()
        {
            Console.WriteLine("Base Class");
        }
        public int Product() => X * Y;
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
    class Child1 : Parent
    {
        public int Z { get; set; }
        public Child1(int x,int y,int z) :base(x,y)
        {
            Z = z;
        }
        public new int Product ()
        {
            // key word => base used only inside the derived class only not oyt side it 
            return base.Product()*Z;
        }
        public new void StaticallyBindedShow()
        {
            Console.WriteLine($"In the Child1 Class");
        }
        internal override void DynamicallyBindedShow()
        {
            Console.WriteLine("Child Class");
        }
        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }
              
    }
    class Child2:Child1
    {
        public int S { get; set; }
        public Child2(int x, int y, int z, int s):base(x,y,z)
        {
            S = s;  
        }
        public new void StaticallyBindedShow()
        {
            Console.WriteLine($"In the Child2 Class");
        }
        internal override void DynamicallyBindedShow()
        {
            Console.WriteLine("child2 two class");
        }
    }
    class Child3 : Child2
    {
        
        public Child3(int x, int y, int z, int s) : base(x, y, z,s)
        {
            
        }
        public new void StaticallyBindedShow()
        {
            Console.WriteLine($"In the Child3 Class");
        }
        // to break the hirarichy 
        internal new virtual void DynamicallyBindedShow() // or may new only if u want to ovveride on it in the derived class
        {
            Console.WriteLine("child3 three class");
        }
    }
    class Child4 : Child3
    {

        public Child4(int x, int y, int z, int s) : base(x, y, z, s)
        {

        }
        public new void StaticallyBindedShow()
        {
            Console.WriteLine($"In the Child4 Class");
        }
        internal override void DynamicallyBindedShow()
        {
            Console.WriteLine("child 4 four class");
        }
    }
    internal class Assignments
    {
        static void Main(string[] args)
        {
            Parent p1 = new Parent(3, 6);
            Child1 c1 = new Child1(3, 6, 2);
            //p1.StaticallyBindedShow();  //In the Base Class
            //c1.StaticallyBindedShow(); //In the Child Class

            //p1.DynamicallyBindedShow();//"base Class"
            //c1.DynamicallyBindedShow();//"Child Class"

            /****** up casting  ****/
    //Reference to base = Derived object ,  up casting =>create a base class reference point to derived object
    //Parent p2 = new Child1(3, 6, 3);

    //Statically Binded Methods (Non Virtual) => compiler bind(link) Function call based on Reference type not object type
    //p2.StaticallyBindedShow();//"In the Base Class"

    //Dynamically Binded Methods (Virtual) => CLR bind function call besed on object type in Runtype
    //p2.DynamicallyBindedShow(); //"Child Class"

    /******down casting****/
    //Parent p3 = new Parent(5, 5);
    //Child c3 =p3 as Child;// ref to derived = base object => unsafe (Runtime Error)
    //c3.StaticallyBindedShow();
    //c3.DynamicallyBindedShow();

    //Console.WriteLine();
    //Parent p4=new Child2 (2,4,6,3);
    //p4.StaticallyBindedShow(); //  In the Base Class
    //p4.DynamicallyBindedShow();// child2 two class

    //        Child3 c4 = new Child3(7, 8, 9, 5);
    //        c4.DynamicallyBindedShow(); //child3 three class => to access the new virtual
    //        c4.StaticallyBindedShow();  //In the Child3 Class
    //        Console.WriteLine();


    //        Parent p5 = new Child3(2, 4, 6, 3);
    //        p5.DynamicallyBindedShow();// child2 two class => the latest override method in the first hirarichy
    //        p5.StaticallyBindedShow();//In the Base Class
    //        Console.WriteLine();

    //        Child3 c5 = new Child4(5, 8, 7, 4);
    //        c5.DynamicallyBindedShow();//child 4 four class => the latest override method in the second hirarichy 
    //        c5.StaticallyBindedShow();//In the Child3 Class => based on the ref class




    //    }
    //}
    #endregion

    #region Abstract 
    // class donot instanciated 
    /*abstract class Shape
    {
        public int Dim1 { get; set; }
        public int Dim2 { get; set; }
        public Shape(int x, int y) { Dim1 = x; Dim2 = y; }
        public abstract double Area(); // it is virtual method+No Implementation + must be in abstract class+ must the derived class ovveride it
    }
    abstract class BaseRect : Shape
    {
        public BaseRect(int x, int y) : base(x, y) { }

        //public override double Area() { } // if u donnot make an override to the abstract method make the class is abstract


    }
    class Rect : Shape
    {
        public Rect(int x, int y) : base(x, y) { }

        public override double Area()
        {
            return Dim1 * Dim2;
        }
    } */
    #endregion

    #region Sealed
    //class TypeA
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    //public sealed void Print() // must the method be override to be sealed => prevent the heirarchy , it finish yhr overriding chainning
    //    public virtual void Print()
    //    {
    //        Console.WriteLine(" base class Type A");
    //    }
    //}
    //class TypeB : TypeA
    //{
    //    public override void Print()
    //    {
    //        Console.WriteLine("Type B");
    //    }

    //}
    //class TypeD : TypeB
    //{
    //    public sealed override void Print()
    //    {
    //        Console.WriteLine(" Type D");
    //    }
    //}

    //// sealed class => restrict the inheretance , it should a derived class not abase class,the last class in the hierarcy
    //sealed class TypeE : TypeD
    //{
    //    //public sealed override void Print() // cannot override the inherited sealed method
    //    //{
    //    //    Console.WriteLine(" Type E");
    //    //}
    //}



    //internal class Assignments
    //{
    //    static void Main(string[] args)
    //    {
    //        TypeE e1= new TypeE();  
    //        e1.Print(); //Type D


    //    }
    //}
    #endregion

    #region Generics
    //class Helper<T>
    //    where T : IComparable<T>
    //    // secondary constraint => interface constraint 
    //    // T => must be class/struct implement IComparable , IClonable,.....
    //    // 0 : * zero: many 

    //    //primary constraint
    //    // 1-where T: class => 0 : 1 and have two types
    //    // 1- special prim => T must be class,struct ...
    //    //2- where T: class_Name(Point)  => 0 : 1
    //    // 2- general prim => T => may Point or child Point

    //    // Ctor constraint
    //    //where T:new () => tell only one available ctor constraint( Parameterless ctor), 0:1

    //{

    //    // Non Generic
    //    //public static int Sum(int x, int y)
    //    //{
    //    //    return x + y;
    //    //}
    //    //public static void BSort(int[] arr)
    //    //{
    //    //    for (int i = 0; i < arr?.Length; i++)
    //    //    {
    //    //        for (int j = 0; j < arr.Length-i; j++)
    //    //        {
    //    //            if (arr[j] > arr[j+1])
    //    //                Helper<int>.Swap(ref arr[j], ref arr[j+1]);
    //    //        }
    //    //    }

    //    //}
    //    //public static int SearchArr(int[] arr,int value)
    //    //{
    //    //    for (int i = 0; i < arr?.Length; i++)
    //    //    {
    //    //        if (arr[i]==value) 
    //    //            return i;
    //    //    }
    //    //    return -1;
    //    //}

    //    public Helper()
    //    {
    //        // valid statments
    //        // 1- Declare vatiables
    //        T x;
    //        T y;
    //        // 2- Intialization 
    //        x=default; y=default;
    //        //3- Assignment Operator
    //        x = y; y = x;
    //        // 4- return statment 
    //        T myfun(T x)
    //        { x = default; return x; }

    //        //5- access members of System.Object
    //        object o1 = x;
    //        if (x.Equals(y)) ;
    //        int H = x?.GetHashCode()??0;
    //        if (x?.GetType() == y?.GetType()) ;
    //        string s = x?.ToString();

    //        // 1-  where T: class => this statements will valid
    //        // y = null
    //        // if(x==y) 

    //        // 1-  where T: struct => this statements will valid
    //        // x = new T();

    //        // not valid statments 
    //        // x=0; // => not valid in classes,struct ,interface
    //        //y = null; => not valid in nonnullable data types
    //        //x = new T(); => not valid in classes with parameterless
    //        Point p1 = new Point(2, 5);
    //        Point p2= new Point(2, 58);
    //        // Helper<Point>.Swap(p1, p2); it run without Generic constraint but now the constraint enforce u to imlement IComparable in any data type u will use in this class 
    //        Console.WriteLine(Helper<Point>.Swap(ref p1, ref p2));
    //    }

    //    // Gneric => I need to non generic method to generic method by using the valid statments

    //    //public static int Sum(T x, T y) // not found operator Genaric
    //    //{
    //    //    return x + y;
    //    //}
    //    public static void BSort(T[] arr)
    //    {
    //        for (int i = 0; i < arr.Length; i++)
    //        {
    //            for (int j = 0; j < arr.Length - i; j++)
    //            {
    //                if (arr[j].CompareTo(arr[j + 1])>1 ) // to use comparing , add constraint on T type that not accept any datatype else implement IComparable interface as int , string ,double , and any user defined implement CompareTo()
    //                    Swap(ref arr[j], ref arr[j + 1]);
    //            }
    //        }

    //    }
    //    public static int SearchArr(T[] arr, T value)
    //    {
    //        for (int i = 0; i < arr?.Length; i++)
    //        {
    //            if (arr[i].Equals(value)) // change == by O,Equals();
    //                return i;
    //        }
    //        return -1;
    //    }

    //    public static string Swap(ref T x, ref T y)
    //    {
    //        T temp = x; x = y; y = temp;
    //        return $"X={x}, Y={y}";

    //    }


    //}

    //class Point : IComparable<Point>  // we use IComparable<Point> with generics to restrect the argument that must to be point only 
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public Point(int x, int y)
    //    {
    //        X = x;
    //        Y = y;
    //    }

    //    public int CompareTo(Point p)
    //    {
    //        if(p==null) return 1;
    //        if(X==p.X)
    //            return Y.CompareTo(p.Y);
    //        return X.CompareTo(p.X);
    //    }
    //}
    //internal class Program
    //{
    //    public static string Swap<T>(ref T x, ref T y)
    //    {
    //        T temp=x; x=y; y=temp;
    //        return $"X={x}, Y={y}";

    //    }
    //    static void Main(string[] args)
    //    {


    //        double x = 34.545;
    //        double y = 22.434;
    //        Console.WriteLine(Program.Swap(ref x, ref y)); // type inference in method Generic in non Generic Class; the Jet Compilor in runtime produce 4 Versions of method so that easy to detect which the choose version by detect the argument
    //        Console.WriteLine(Helper<double>.Swap(ref x,ref y));//no type inference in method Generic in Generic Class ; the Jet Compilor in runtime produce 4 Versions of class so you must determine which version u need 

    //    }
    //} 
    #endregion
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //    }
    //}
//}