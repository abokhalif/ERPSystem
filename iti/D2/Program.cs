using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace D2
{   internal class Program
    {
        #region StackTrace
        //public static void fun1()
        //{
        //    Console.WriteLine("this is fun 1 ");
        //    fun2(2);
        //}
        //public static void fun2(int a)
        //{
        //    Console.WriteLine($"this is fun 2 {a}");
        //    fun3(a);
        //}
        //public static void fun3(int b)
        //{
        //    Console.WriteLine($"this is fun 3 {b}");
        //    StackTrace st = new StackTrace();
        //    StackFrame[] sf = st.GetFrames();
        //    for (int i = 0; i < sf?.Length; i++)
        //    {
        //        Console.WriteLine(sf[i].GetMethod().Name);

        //    }
        //}
        #endregion
        public static void Main()
        {
            // fun1();
            #region switch
            /*
            String str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    Console.WriteLine("Jan");
                    break;
                case "2":
                    Console.WriteLine("Feb");
                    break;
                case "3":
                    Console.WriteLine("March");
                    break;
                case "4":
                    Console.WriteLine("April");
                    break;
                case "5":
                    Console.WriteLine("May");
                    break;
                case "6":
                    Console.WriteLine("June");
                    break;
                case "7":
                    Console.WriteLine("July");
                    break;
                case "8":
                    Console.WriteLine("Aug");
                    break;
                default:
                    Console.WriteLine("NF");
                    break;
            }
            String str2 = Console.ReadLine();
            switch (str2)
            {
                case "a":
                    Console.WriteLine("Jan");
                    break;
                case "b":
                    Console.WriteLine("Feb");
                    break;
                case "c":
                    Console.WriteLine("March");
                    break;
                default: Console.WriteLine("nf"); break;
            }

            String str3 = Console.ReadLine();
            if (str3 == "a")
                Console.WriteLine("Jann");
            else if (str3 == "b")
                Console.WriteLine("febb");
            else if (str3 == "c")
                Console.WriteLine("marchh");
            else Console.WriteLine("Nf");
            */
            #endregion

            #region shallow copy

            //int[] originalArray = { 1, 2, 3, 4, 5 };

            //// Perform a shallow copy using Array.Clone()
            //int[] shallowCopy = (int[])originalArray.Clone();

            //// Modify an element in the shallow copy
            //shallowCopy[0] = 10;
            //Console.WriteLine(originalArray.GetHashCode()); //not the same code so not the same object
            //Console.WriteLine(shallowCopy.GetHashCode());
            //Console.WriteLine(originalArray);
            //// Print the elements of the original array
            //Console.WriteLine("Original array:");
            //foreach (int num in originalArray)
            //{
            //    Console.Write(num + " "); // Output: 1 2 3 4 5
            //}

            //// Print the elements of the shallow copy
            //Console.WriteLine("\nShallow copy:");
            //foreach (int num in shallowCopy)
            //{
            //    Console.Write(num + " "); // Output: 10 2 3 4 5
            //}
            #endregion

            #region Nullable
            //int x = 700;
            //int? y = null;
            //x = y ?? 0;
            //Console.WriteLine($"X={x}");
            //Console.WriteLine($"Y={y}");



            //int[]? arr =new int[55];
            //arr = null;
            //for (int i = 0;i < arr?.Length ; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            #endregion


            #region out & ref used to return multiple values 
            // static void summul(int x, int y, out int s, out int m)
            //{
            //    //Console.WriteLine(s);//error not intialized
            //    //Console.WriteLine(m);
            //    s = x + y;
            //    m = x * y;
            //    Console.WriteLine(s);
            //    Console.WriteLine(m);

            //}

            //int x = 5, y = 10, s, m ; //s,m not intialized just declared
            //summul(x, y, out s, out m);

            //static void sum(int x,ref int y)
            //{
            //    y +=x;
            //}
            //int n = 9;//must be intialized brfore passed to the method arguments when calling
            //sum(4, ref n);
            //Console.WriteLine(n);

            #endregion

            #region Task1 => find the longest distance between Two equal values in the array

            //Console.WriteLine("Enter the size of array ");
            //int sizeArray = Convert.ToInt32(Console.ReadLine());
            //int[] array = new int[sizeArray];
            //int res = 0;
            //int fres = 0;
            //int z = 0, w = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //for (int i = 0; i < array.Length; i++)
            //{
            //    for (int r = array.Length - 1; r >= i; r--)
            //    {
            //        if (array[i] == array[r])
            //            res = (r - i) - 1;
            //        if (res > fres)
            //        {
            //            fres = res;
            //            z = i;
            //            w = r;
            //        }


            //    }

            //}
            //Console.WriteLine($"the longest distance is between index [{z + 1}] and index [{w + 1}] the number Of cells {fres}");


            #endregion

            #region Task2 => Given a list of space separated words, reverse the order of the words.
            /*string s = Console.ReadLine();
            string[] s1 = s.Split(' ');
            Array.Reverse(s1);

            string reversed = string.Join(' ', s1);

            Console.WriteLine(reversed); */
            #endregion

            /*Stopwatch stopwatch= Stopwatch.StartNew();
            //long num = 99_999_999;
            ////string s=num.ToString();
            //int count = 0;
            //for (int i = 1; i < num; i++)
            //{
            //    string s =i.ToString();
            //    for (int r = 0; r < s.Length; r++)
            //    {
            //        if (s[r] == '1')
            //            count++;

            //    }


            //}
            //Console.WriteLine(count);
            int count = 0;

            for (int number = 1; number <= 99999999; number++)
            {
                count += CountOnes(number);
            }

            Console.WriteLine("Occurrences of digit 1: " + count);
            static int CountOnes(int number)
            {
                string numberString = number.ToString();
                int count = 0;

                foreach (char digit in numberString)
                {
                    if (digit == '1')
                    {
                        count++;
                    }
                }

                return count;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            */







        }

    }
}