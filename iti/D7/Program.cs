using System;
using System.Collections;

namespace D7
{
    // D7_P1
    //internal class Program
    //{
    /*static int SumOfArrayList(ArrayList array)
    {
        int sum = 0;
        for (int i = 0; i < array?.Count; i++)
        {
            sum = sum + (int)array[i]; // array[int] but return object ,{int + (int) object } ,must explicitly casting (unBoxing) => unsafe
        }
        return sum;
    }*/
    /*static int SumOfList(List<int> list)
    {
        int sum = 0;
        for (int i = 0; i < list?.Count; i++)
        {
            sum = sum + list[i]; // list[int] and return list (no unboxing)
        }
        return sum;
    }*/
    //static void Main(string[] args)
    //{
    /* ArrayList arrayList= new ArrayList();
     arrayList.Add(1); // ArrayList.Add(Object) => it take int(stack) and convert it to object(in Heap) => BOXing
     arrayList.Add(2);
     arrayList.Add("3");//Compiler cannot enforece type safety at compilation
     arrayList.Add(1);
     arrayList.Add(2);
     arrayList.Add(3);
     arrayList.AddRange(new int[] { 4, 5, 6 ,5,7});
     arrayList.Remove(1); // value
     arrayList.RemoveAt(6);// index
     Console.WriteLine(arrayList.Capacity); // double of 0,4,8,...
     for (int i = 0; i < arrayList.Count; i++)
     {
         Console.WriteLine(arrayList[i]);

     }*/
    /* List<int> list = new List<int>();
     list.Add(1); // take int and return int (no Boxing)
     list.Add(2);
     list.Add(3);
     //list.Add("4");//Compiler can enforece type safety at compilation
     list.AddRange(list);
     foreach (var item in list)
     {
         Console.WriteLine(item);
     }
     list.TrimExcess();// size of array in memory = capacity - size
     Console.WriteLine(list.Capacity);
     Console.WriteLine(list.Count);
     Console.WriteLine(SumOfList(list));
     list[3] = 9; // update valid
     //list[7] = 10; // Add by indexer not valid => ArgumentOutOfRangeException
     Console.WriteLine(list[3]);*/
    /*Dictionary<string,long> phoneNote = new Dictionary<string,long>();
     phoneNote.Add("abdo", 01127558969);
     phoneNote["saber"] = 01110327815; // add by index is valid 
     phoneNote.Add("mohamed", 01127586969);
     phoneNote.Add("ahmed", 01177758969);
     phoneNote["ahmed"] = 01056897452;// update
     Console.WriteLine(phoneNote["abdo"]); // get value
     // To avoid the Exceptions
     if (phoneNote.TryGetValue("ahmed", out long v))
         Console.WriteLine(v);
     else
         Console.WriteLine("NotFound");


     // No duplicate keys allowed => to avoid this restrict use Try..
     //1-
     if (!phoneNote.TryAdd("xyz", 123456789))
      phoneNote["xyz"] = 123456789;
     //2-
     if (!phoneNote.ContainsKey("xyz"))
          phoneNote["xyz"] = 773456789;
     else
         phoneNote["xyz"] = 773456789;// update

     //foreach (var item in phoneNote)
     //{
     //    Console.WriteLine(item);
     //}

     /*foreach (KeyValuePair<string, long> item in phoneNote)
     {
         Console.WriteLine($"{item.Key} :: {item.Value}");
     }
     //Console.WriteLine(phoneNote["xyz"]); //KeyNotFoundException*/
    //}
    //}

    // D7_P2
    #region NonGeneric Delegete Examples
    // Ex01
    //public delegate void StringDel(string s);
    //class StringFunctions
    //{
    //    public string? S { get; set; } = default;
    //    public static void SToUpper(string s)
    //    {
    //        s = s.ToUpper();
    //        Console.WriteLine(s);
    //    }
    //    public static void SToLower(string s)
    //    {
    //        s = s.ToLower();
    //        Console.WriteLine(s);
    //    }
    //    public static void GetLength(string s)
    //    {
    //        int n = s.Length;
    //        Console.WriteLine(n);
    //    }
    //    public static void fun(string s, StringDel d) => d(s);

    //}
    ////EX02
    //public delegate int OpDel(int x, int y);

    //class Operations
    //{
    //    public static int sum(int x, int y) => x + y;
    //    public static int Multi(int x, int y) => x * y;
    //    public static int sup(int x, int y) => x - y;

    //    public int over(int x, int y) => x / y;
    //    public static int Functions(int x, int y,OpDel d)=>d(x, y);
    //}

    // Ex 03  
    /* class Condition
    {
        public static bool ChkOdd(int x) => x % 2 == 1;
        public static bool ChkEven(int x) => x % 2 == 0;
        public static bool ChkSeven(int x) => x % 7 == 0;


    }*/
    //internal class Program
    //{
    /* Without Delegete
     * public static List<int> FindOdd(List<int> list)
    {
        List <int>olist = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] % 2 == 1)
                olist.Add(list[i]);
        }
        return olist;
    }
    public static List<int> FindEven(List<int> list)
    {
        List<int> olist = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] % 2 == 0)
                olist.Add(list[i]);
        }
        return olist;
    }
    public static List<int> FindSeven(List<int> list)
    {
        List<int> olist = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] % 7 == 0)
                olist.Add(list[i]);
        }
        return olist;
    }*/

    /* with Delegete*/
    //public delegate bool NumberDel(int x);
    //public static List<int> NumberFunction(List<int> list,NumberDel d)
    //{
    //    List<int> olist = new List<int>();
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        if (d?.Invoke(list[i])==true)
    //            olist.Add(list[i]);
    //    }
    //    return olist;
    //}
    //static void Main(string[] args)
    //{
    /*
     * Ex01
    // OpDel d1 = Operations.sum;
    //int s = d1(5, 8);
    //d1 += Operations.Multi;
    //int m = d1(5, 8);
    // d1 += Operations.sup;
    //int n = d1(5, 8);
    //Operations op = new Operations();
    //d1 += op.over;
    //int v = d1(5, 8);
    //Console.WriteLine(s);
    //Console.WriteLine(m);
    //Console.WriteLine(n);
    //Console.WriteLine(n);
    //d1 += Operations.sup;

    //int n=Operations.Functions(5, 8, d1);
    //Console.WriteLine(n);
    //n= Operations.Functions(5, 8, d1);
    //Console.WriteLine(n);

    // Ex 02
    //OpDel d1 = Operations.sum;
    //d1 += Operations.Multi;// in return function ,it override on the variable the result of the last function in the quque
    //int n = Operations.Functions(5, 8, d1);
    //Console.WriteLine(n); // 40

    //StringDel d2 = StringFunctions.SToUpper;
    //d2 += StringFunctions.GetLength; // multicast delegete run as quque so in return void function 
    //StringFunctions.fun("ABCD xyz", d2);

    //// you can send the function by its name with out its delegate
    //int x = Operations.Functions(5, 8, Operations.sum);
    //Console.WriteLine(x); // 13

    //StringFunctions.fun("abcd", StringFunctions.SToUpper);
    */

    // Ex 03

    /* List<int> list = Enumerable.Range(0, 100).ToList();
     NumberDel d = Condition.ChkOdd;
     List<int> list1 = NumberFunction(list, d);
     foreach (var item in list1)
     {
         Console.Write(item);
     }

     d += Condition.ChkEven;
     list1=NumberFunction(list, d);
     foreach (var item in list1)
     {
         Console.Write($"{item} ,");
     }
     */

    //}
    // }

    //}
    #endregion

    // Generic Delegete
    //public delegate bool NumberDel< in T>(T x);

    //class GDel
    //{
    //    public static List<T> NumberFunction<T>(List<T> list, Func<T,bool> f)
    //    {
    //        List<T> olist = new List<T>();
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            if (f?.Invoke(list[i]) == true)
    //                olist.Add(list[i]);
    //        }
    //        return olist;
    //    }

    //    public static bool ChkLengh(string s) => s.Length >= 4;
        
       
    //}
    internal class Program
    {

        // Basic delegate
        public delegate bool OperationDel(int n);

        public static bool isEven(int x)
        {
            return x % 2 == 0;
        }
        public static List<int> OperationsFunc(List<int> nums,OperationDel del)
        {
            List<int> Rlist = new List<int>();
            foreach(int i in nums)
            {
               //bool istrue=del(i);
                if (del?.Invoke(nums[i]) == true)
                    Rlist.Add(i);
                else continue;
            }
            return Rlist;
        }
        //Using Func<T> and Action<T> and Predicate<T> Instead of Custom Delegates

        public static List<int> OperationsFunc2(List<int> nums, Func<int,bool> del) // 
        {

            List<int> Rlist = new List<int>();
            foreach (int i in nums)
            {
                bool istrue = del(i);
                if (istrue == true)
                    Rlist.Add(i);
                else continue;
            }
            return Rlist;
        }




        static void Main(string[] args)
        {

            //NumberDel<string> ptr = GDel.ChkLengh;
            //Func<string, bool> func = GDel.ChkLengh;// you can not declare the delegete , just send the function to the delegete
            //List<string> s=new List<string>() { "ahmed","ali","Khaled","Mohamed","Mai","Mariam"};
            //List<string> r = new List<string>();
            //r=GDel.NumberFunction(s, GDel.ChkLengh);
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item);
            //}
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 9, 7, 8, 5, 12, 10, 11, 55 };
            List<int> Result1=OperationsFunc(nums, isEven); // passing a method with name
            List<int> Result2 = OperationsFunc2(nums,delegate (int n){ return n % 2 != 0;});//Passing an anonymous method as a delegate
            List<int> Result3 = OperationsFunc(nums, (int n)=> n % 2 != 0);//// Passing lambda expression
            foreach (var item in Result2)
            {
                Console.WriteLine($"{item} ");
            }

        }
    }
}