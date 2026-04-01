namespace D9
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Anonymous type => (var VS. object)
            /*
           //// when using object  as Anonymous type // not access the attribute
           //object E1 = new { Id = 1, Name = "john", age = 33 };
           //object E2 = new { Id = 1, Name = "john", age = 33 };
           //Console.WriteLine(E1.GetType());//<>f__AnonymousType0`3[System.Int32,System.String,System.Int32]
           //Console.WriteLine(E1.Equals(E2));
           //Console.WriteLine(E1.ToString());
           //Console.WriteLine(E1.GetHashCode()); 
           //Console.WriteLine(E2.GetHashCode());


           //// when using var  as Anonymous type // can access the attribute of the class
           var E1 = new { Id = 1, Name = "john", age = 33 };
           var E2 = new { Id = 1, Name = "john", age = 33 };
           var E3 = new { Id = 3, Name = "ali", age = 22 };
           var E5 = new { Id = 3, Name = "ali" };


           Console.WriteLine(E1.GetType());//<>f__AnonymousType0`3[System.Int32,System.String,System.Int32]
           Console.WriteLine(E1.Equals(E2)); // true 
           Console.WriteLine(E3.Equals(E2)); //  false => based on values
           Console.WriteLine(E1.ToString());
           Console.WriteLine(E1.GetHashCode());
           Console.WriteLine(E2.GetHashCode());

           // the same type as long as (same property name,same number of property , same sequence )
           Console.WriteLine(E2.GetType()); //<>f__AnonymousType0`3[System.Int32,System.String,System.Int32]
           Console.WriteLine(E3.GetType());//<>f__AnonymousType 0=> the first oreder of compination (3 =>prop) =>`3[System.Int32,System.String,System.Int32]
           Console.WriteLine(E5.GetType());//<>f__AnonymousType1`2[System.Int32,System.String]
           Console.WriteLine(E1.Name);// john => accessing as read only 
           // E1.Id = 1;// in valid => it is immutable => readonly(get) , cannot change the data after assigning the data type
            */
            #endregion

            List<int> intlist = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<string> strlist = new List<string>() {"ali","maher" ,"kahraba","afsha","lili","farah","sally"};

            #region EX01 where
            ////IEnumerable<int> R =Enumerable.Where(intlist, i => i % 2 == 0);// this return IEnumerable type so u must assign the output to type implemented IEnumarable 
            /////1- Fluent Syntax
            ////1- static function member in Enymerable class
            //var R1=Enumerable.Where(intlist, i => i % 2 == 0); // or u can use var to not determine the type of return the output
            //// 2- Extention method
            //var R2 = intlist.Where(i => i % 2 == 0);//.OrderBy(i=>i); fluent => u can chaining the methods

            /////2- Query Syntax
            //var R3=from i in intlist
            //       where i%2 == 0
            //       select i;
            /// sql like style , valid for only supset of 40+ linq operator(join , let ,group ,into)
            /// start with form
            /// then range variable(i : represent each and every element in input sequence )
            /// end by select => for transformation, or group by
            /// 
            #endregion


            #region Defered and Immediate Execution

            //var Result = intlist.Where(i => i % 2 == 0);
            //Console.WriteLine(Result.GetType());//System.Linq.Enumerable+WhereListIterator`1[System.Int32]
            // casting operator to to convert the Enumerable to list,array, hashset,dictionary,..
            //List<int> Result2 = intlist.Where(i => i % 2 == 0).ToList();            
            //Console.WriteLine(Result2.GetType());//System.Collections.Generic.List`1[System.Int32]


            ////LINQ query with /**  deferred execution  **/:refers to the delayed execution of queries until the results are actually needed.
            //var Result = intlist.Where(i => i % 2 == 0);
            //Console.WriteLine(Result.GetType());//System.Linq.Enumerable+WhereListIterator`1
            ////  Enumerate the results, and the query is executed here.
            //foreach (var item in Result)
            //{
            //    Console.Write(item + " ");
            //}// Result= 2 4 6 8

            //Console.WriteLine();

            //intlist.Remove(2);
            //intlist.AddRange(new int[] { 10, 11, 12, 13, 14 });

            ////// the query will executed here too after the operations that executed on intlist ; because Enumerate the results.
            //foreach (var item in Result)
            //{
            //    Console.Write(item + " ");
            //}// Result=4 6 8 10 12 14

            /// u can convert the result to list/array => to run as immedite execution:casting element operator to exeute immediatly
            //List<int> R = intlist.Where(i => i % 2 == 0);// error
            //List<T>=IEnumerable
            // Derived = base
            // we using the Explict Casting
            List<int> R = intlist.Where(i => i % 2 == 0).ToList<int>();
            Console.WriteLine(R.GetType());//System.Collections.Generic.List`1[System.Int32]
            var Result = intlist.Where(i => i % 2 == 0).ToList();
            Console.WriteLine(Result.GetType());//System.Collections.Generic.List`1[System.Int32]
            foreach (var item in Result)
            {
                Console.Write(item + " ");
            }// Result= 2 4 6 8

            Console.WriteLine();

            intlist.Remove(2);
            intlist.AddRange(new int[] { 10, 11, 12, 13, 14 });
            // after modify : the result store the data and show it as the same cause his typr is Generic.List
            foreach (var item in Result)
            {
                Console.Write(item + " ");
            }// Result=2 4 6 8


            #endregion
        }
    }
}