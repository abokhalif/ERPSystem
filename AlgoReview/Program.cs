using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgoReview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fib(10)) ;
            int fib(int n)
            {
                // base cases
                if (n == 0) return 0;
                if (n == 1) return 1;

                // Transition
                return fib(n - 1) + fib(n - 2);
            }


            //    int[] arr = new int[100];

            //Console.WriteLine($"enter the size of array char");
            //int n = int.Parse(Console.ReadLine());
            //char[] arr = new char[n];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine($"enter the {i + 1} char");
            //    arr[i] = char.Parse(Console.ReadLine());
            //}
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (i%2!=0)
            //    {
            //        if (!IsLower(arr[i]))
            //        {
            //            Console.WriteLine((char)(arr[i] + 32));
            //            continue;
            //        }
            //        Console.WriteLine(arr[i]);

            //    }
            //    else if (i % 2 == 0)
            //    {
            //        if (!IsUpper(arr[i]))
            //        {
            //            Console.WriteLine((char)(arr[i] - 32));
            //            continue;

            //        }
            //        Console.WriteLine(arr[i]);



            //    }
            //}

            //bool IsUpper(char c)
            //{

            //    return c <= 'Z' && c >= 'A';

            //}
            //bool IsLower(char c)
            //{

            //    return c <= 'z' && c >= 'a';

            //}

            //Console.WriteLine($"enter the size of array char");
            //int n = int.Parse(Console.ReadLine());
            //char[] arr = new char[n];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine($"enter the {i+1} char");
            //    arr[i] = char.Parse(Console.ReadLine());
            //}
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i]<='Z'&& arr[i]>='A')
            //    {
            //        Console.WriteLine((char)(arr[i] + 32));
            //    }
            //    else if (arr[i] <= 'z' && arr[i] >= 'a')
            //    {
            //        Console.WriteLine((char)(arr[i] - 32));
            //    }
            //}

            //int[] arr =new int [5];
            //int[] arr2 = { 3, 3, 3 };

            //for (int i = 0; i < arr.Length; i++)
            //{

            //    Console.WriteLine(arr[i]);
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 5-i; j >0; j--)
            //    {
            //        Console.Write("* ");
            //    }
            //    Console.WriteLine("\n");
            //}


            //int number;
            //Console.Write("Enter a number: ");
            //number = int.Parse(Console.ReadLine());
            //int limit = (int)Math.Sqrt(number);
            //if (number == 0 || number == 1)
            //{
            //    Console.WriteLine("not prime");
            //}
            //for (int i = 2; i <= limit; i++)
            //{

            //    if (number % i == 0)
            //    {
            //        Console.WriteLine("not prime");
            //        break;
            //    }

            //    Console.WriteLine(" prime");

            //}


            #region problems


            //Console.Write("Enter a number: ");
            //int number = int.Parse(Console.ReadLine());

            //int min=0;int max = 0;
            //min = number;
            //max = number;
            //for (int i = 2; i <= 10; i++)
            //{
            //    Console.Write("Enter a number: ");
            //    number = int.Parse(Console.ReadLine());

            //        if(number<=min)
            //        {
            //            min = number;
            //        }
            //        else if(number>max)
            //        {
            //            max = number;
            //        }

            //}

            //Console.WriteLine( $"{ min} - { max}" );


            //IList<int>list = new List<int>() { 1, 12, 5, 8, 2, 6, 14, 8, 17, 0 };

            //for (int i = 0; i < list.Count; i++)
            //{
            //    for (int j= 0; i < list.Count-i; i++)
            //    {
            //        int x = list[i];
            //        if ( x < list[j])
            //        {
            //            x = list[j];
            //        }
            //    }

            //}



            // Selection sort ,
            // IList<int> unorderedlist = new List<int>() { 1, 12, 5, 8, 2, 6, 14, 8, 17, 0 };

            //for (int i = 0; i < unorderedlist.Count; i++)
            //{
            //    for(int j=0;j< unorderedlist.Count; j++)
            //    {
            //        if (unorderedlist[j]< unorderedlist[i])
            //        {
            //            int temp = unorderedlist[i];
            //            unorderedlist[i] = unorderedlist[j];
            //            unorderedlist[j] = temp;
            //        }
            //    }

            //} 













            //List<int> ints = new List<int> { 1, 12, 5, 8, 2, 6, 14, 8, 17, 0 };

            //// Bubble Sort Algorithm
            //for (int i = 0; i < ints.Count - 1; i++)
            //{
            //    for (int j = 0; j < ints.Count - 1 - i; j++)
            //    {
            //        if (ints[j] > ints[j + 1])
            //        {
            //            // Swap the elements
            //            int temp = ints[j];
            //            ints[j] = ints[j + 1];
            //            ints[j + 1] = temp;
            //        }
            //    }
            //}

            //// Print the sorted list
            //foreach (int num in ints)
            //{
            //    Console.WriteLine(num);
            //}


            #endregion
        }

    }
}
