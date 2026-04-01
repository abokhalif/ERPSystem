using System.Data.SqlTypes;

namespace D8
{
    #region Anonymous Method with Delegate
    /*class Condition
    {
        public static bool ChkOdd(int x) => x % 2 == 1;
        public static bool ChkEven(int x) => x % 2 == 0;
        public static bool ChkSeven(int x) => x % 7 == 0;
        public static bool ChkStringLength(string S) => S.Length >= 4;
        //public static string SToUpper(string s) => s.ToUpper();
        //public static string IntToStrong(int x) => x.ToString();
    }*/
    /* public delegate bool NumberDel(int x); // using user defined delegate 
     class BaseFunction
     {
         public static List<int> NumberFunction(List<int> list, NumberDel d)
         {
             List<int> olist = new List<int>();
             for (int i = 0; i < list.Count; i++)
             {
                 if (d?.Invoke(list[i]) == true)
                     olist.Add(list[i]);
             }
             return olist;
         }
     }*/
    /* class BaseFunction // useing the build in delegetes(Action,Func,predicate)
     {
         public static List<int> NumberFunction(List<int> list, Func<int,bool> f)//Func<in,out> name
         {
             List<int> olist = new List<int>();
             for (int i = 0; i < list.Count; i++)
             {
                 if (f?.Invoke(list[i]) == true)
                     olist.Add(list[i]);
             }
             return olist;
         }
     }*/
    /*class BaseFunction // using Generic
    {
        public static List<T> NumberFunction<T>(List<T> list, Func<T,bool> f)//Func<in,out> name
        {
            List<T> olist = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if (f?.Invoke(list[i]) == true)
                    olist.Add(list[i]);
            }
            return olist;
        }

        
    }*/

    /* internal class Program
     {
         static void Main(string[] args)
         {
             // List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
             //NumberDel del = new NumberDel(Condition.ChkEven);

             //Func<int, bool> f = new Func<int, bool>(Condition.ChkEven);
             //res= BaseFunction.NumberFunction(list,del); // you can send the method name directly

             //res= BaseFunction.NumberFunction(list, f);

             //list = BaseFunction.NumberFunction(list, Condition.ChkEven);
             //foreach (var item in list)
             //{
             //    Console.WriteLine(item);
             //}

             //List<string> s = new List<string>() { "ahmed", "ali", "Khaled", "Mohamed", "Mai", "Mariam" };
             //s = BaseFunction.NumberFunction(s, Condition.ChkStringLength);
             //foreach (var item in s)
             //{
             //    Console.WriteLine(item);
             //}

             // Anonymous Method => method on the fly =>C# 2.0 feature 

             //List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19,20,21 };

             // Anonymous Method - v01
             //Func<int, bool> ptr;
             //ptr= delegate (int x) { return x % 7 == 0; };
             //list =BaseFunction.NumberFunction(list, ptr);
             //foreach (var item in list)
             //{
             //    Console.WriteLine(item);
             //}

             // Anonymous Method - v02
             //list = BaseFunction.NumberFunction(list, delegate (int x) { return x % 7 == 0; });
             //foreach (var item in list)
             //{
             //    Console.WriteLine(item);
             //}

             // Anonymous Method - v03=>Lambda Expression 
             //list = BaseFunction.NumberFunction(list,  x=> x % 7 == 0);// if it has 2 or more var ( x,y,..) and more tham one condition => { ....} ;
             //foreach (var item in list)
             //{
             //    Console.WriteLine(item);
             //}





         }
     }*/

    #endregion

    #region Event Ex01
    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            Ball ball = new Ball();
            Player p1 = new() { Name = "Mohamed salah", Team = "liverbool" };
            Player p2 = new() { Name = "Ahmed salah", Team = "liverbool" };
            Player p3 = new() { Name = "Afsha", Team = "Ahly" };
            Player p4 = new() { Name = "Betso", Team = "Ahly" };
            Refree r1 = new() { Name = "Bazoka" };
            Location location = new() { X = 0, Y = 0, Z = 0 };
            Console.WriteLine(ball);
            ball.BallLocation = location;
            //ball.BallLocationChanged +=new Action( p1.Run);// old calling
            ball.BallLocationChanged +=new Action<Location>( p1.Run);// old calling
            // new calling 
            ball.BallLocationChanged += p2.Run;
            ball.BallLocationChanged += p3.Run;
            ball.BallLocationChanged += p4.Run;
            ball.BallLocationChanged += r1.Look;
            //ball.BallLocationChanged += () => Console.WriteLine("Adhck method");

            ball.BallLocation = new Location { X = 20, Y = 20, Z = 20 };
            Console.WriteLine(ball);


        }
    }*/
    #endregion
    
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //    }
    //}
}