using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text;

namespace linq
{
    #region Anonymous data type(var)
    /*class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int salary { get; set; }

        public override bool Equals(object obj)
        {
            if(obj ==null || !(obj is Employee )) return false;
            Employee employee= obj as Employee; 
            return this.Id ==  employee.Id && this.Name== employee.Name && this.salary==employee.salary;

        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash=(hash*3)+Id.GetHashCode();
            return hash;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee { Id = 1, Name = "Ahmed", salary = 4000 };// the same content with emp11 but difference addresses
            Employee emp11 = new Employee { Id = 1, Name = "Ahmed", salary = 4000 };// 
            Employee emp2= new Employee { Id = 2, Name = "Amr", salary = 3000 };
            Employee emp3 = new Employee { Id = 3, Name = "Abdallah", salary = 8000 };
            Employee emp4 = emp2; // emp4 => reference to the same address(location) of the emp2

            // using == operetor that used for compare the value types and the references(addresses) regardless it is contenr same as the string class 
            Console.WriteLine(emp1==emp11);// false
            Console.WriteLine(emp2==emp3);// false
            Console.WriteLine(emp2==emp4);// true

            // using .Equals before override it in the Employee class
            //Console.WriteLine(emp1.Equals(emp11));// false 
            //Console.WriteLine(emp2.Equals(emp3));// false
            //Console.WriteLine(emp2.Equals(emp4));// true                             

            // using .Equals after override it in the Employee class , it compare the content of the 
            Console.WriteLine(emp1.Equals(emp11));// true 
            Console.WriteLine(emp2.Equals(emp3));// false
            Console.WriteLine(emp2.Equals(emp4));// true

            // the hashcode 
            Console.WriteLine(emp1.GetHashCode());//  52
            Console.WriteLine(emp2.GetHashCode());//  53 
            Console.WriteLine(emp3.GetHashCode());//  54
            Console.WriteLine(emp4.GetHashCode());//  53

            //var s = "ddd";
            //Console.WriteLine(s.GetHashCode());
            //s = "dddd";
            //Console.WriteLine(s.GetHashCode());
              

            /// *** Anonymous type => create class with the assigned attribute and do override for the functions(GetHashCode(),Equals(),ToString(),...)
            Console.WriteLine(emp1.GetType().Name);  // Employee
            
            object E1 = new { Id = 101, Name = "John", Salary = 1500 };
            Console.WriteLine(E1.GetType().Name);     // <>f__AnonymousType0`3 =>  0 -> the first type of (object) datatype ,but you can not access the 3 -> attribute
            //Console.WriteLine(E1.Id);  // compileError
            Console.WriteLine(E1.ToString());// 
            
            var E2 = new { Id = 101, Name = "John", Salary = 1500 };// anonymous dt=> Immutable data type that mean when change any of the 3 attribute if in values or in order that lead to create a new object
            Console.WriteLine(E2.GetType().Name);     //<>f__AnonymousType0`3 =>  0 -> the first type of (var) datatype ,but you can access the 3 -> attribute
            Console.WriteLine(E2.Id);// is available //101
            Console.WriteLine(E2.ToString());

            var E3 = new { Id = 101, Name = "John", Salary = 1500 };
            Console.WriteLine(E2.Equals(E3)); // true
            Console.WriteLine(E2.GetHashCode()); // -1540915581
            Console.WriteLine(E3.GetHashCode());//  -1540915581 the same GetHashCode  based on values not identity (this is a story ........) 

            var E4 = new { Id = 105, Name = "John", Salary = 1500 };
            Console.WriteLine(E2.Equals(E4));  // false
            Console.WriteLine(E2.GetHashCode()); // difference in GetHashCode 
            Console.WriteLine(E4.GetHashCode()); // ~  ~

        }
    }
    */
    #endregion

    #region Genric why and how and its constraints
    /*class Helper1
    {
        public static void swap <T>(ref T x,ref T y)
        {
            T temp = x; x = y;
            y = temp;

        }
    }*/
    class Helper2<T>
        where T : IComparable
    {
        public static void swap<T>(ref T x, ref T y)
        {
            T temp = x; x = y;
            y = temp;

        }
        #region the problem of => Are the Operands (+,==,-,*,<,>,/) applied on the data types (T) in Generics?!
        /*public static T Sum(ref T x,ref T y)  // the operands(+,-,*,<,>,/) donnot allow to use with generics  
        {
            T z = x + y;
            return z;
        }

        public static bool  SearchArrv1(T[]arr , T x) // donot allow it cause (==) 
        {
            for (int i=0; i<arr?.Length;i++) 
            {
                if (x == arr[i]) return true;
                else return false;
            }
        }

        public static void BubbleSortv1<T>(T[] arr)
        {
            for(int i=0; i<arr?.Length;i++)
            {
                for (int j = 0; j < arr.Length-i-1; j++)
                {
                    if (arr[j] >arr[j+1])
                    {
                        swap(ref arr[j], ref arr[j+1]);

                    }
                }
            }

        }*/
        #endregion

        #region the attribute of Generic (Rules) => why the problems(reasons)
        public Helper2() 
        {
            // we will define the statements that valid on (T) Generic

            //1-Declare Variables
            T x;
            T y;

            //x=0; // it is not valid for all  the datatypes in c# as (claass,record,interface,struct,string,..)
            //y=null;// it is not valid for all  the datatypes in c# as (nullable datatypes as struct not accept the null)
            //x= new T();// it is not valid as ( class that has a identified Constructor ie. it donot has defualt constructor)

            // 2- Initialization
            x = default;


            // 3-Assignment Operator(=)
            y = x;

            //4-return statement 
            T MyFunc()
            { T X = default; return X; }
            //5- System.Object =>x access all members of the object class
            object o = x;
            x.Equals(y);
            x.ToString();
            x.GetType();
            x.GetHashCode();

            x.CompareTo(y);// after add constraint IComparable interface



        }
        #endregion

        #region the Solution to use Generics

        public static int SearchArrv2(T[] arr, T x)//the operand(==) donnot allow to use with generics but we use the functions of object class(4) as a solution
        {
            for (int i = 0; i < arr?.Length; i++)
            {
                if (x.Equals( arr[i])) return 1;
                else return i;
            }
            return -1;   
        }
        public static void BubbleSortv2<T>(T[] arr)
        {
            for (int i = 0; i < arr?.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if ( arr[j].CompareTo(arr[j + 1]))
                    {
                        swap(ref arr[j], ref arr[j + 1]);

                    }
                }
            }

        }
        
        #endregion

    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            int x=9; int y=10;
            //  Helper1.swap(ref x, ref y); // in Generic Methods (only ie.not in class or struct or iterface generic) Compiler can detect the data type of the method 
            //Helper1.swap<int>(ref x, ref y);
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
