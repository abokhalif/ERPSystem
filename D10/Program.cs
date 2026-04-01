using System.Text.RegularExpressions;
using static D10.ListGenerators; 
namespace D10
{
    internal class Program
    {
        //static void Main(string[] args)
        //{

        #region where - filteration

        // where => the first shape where(list,bool)
        //var Result = ProductList.Where(p => p.UnitsInStock == 0);

        //foreach (var item in Result)
        //{
        //    Console.WriteLine(item);
        //}
        //Console.WriteLine();

        //var t = from p in ProductList
        //        where (p.UnitsInStock == 0) && (p.Category == "Meat/Poultry")
        //        select p;
        //foreach (var item in t)
        //{
        //    Console.WriteLine(item);
        //}
        //Console.WriteLine();
        //// where => the second shape where((list,index of the list),bool) => valid in fluent syntax only
        //var R = ProductList.Where((p, i) => (p.UnitsInStock == 0) && i <= 20);
        //foreach (var item in R)
        //{
        //    Console.WriteLine(item);
        //} 
        #endregion
        #region Select - transform operator
        // project / transform every element in the sequence to a new form of element in output sequence of new data type or the same type
        /* var Result = ProductList.Select(p => p.ProductName);//  Product => string (new data type)
          Result = from p in ProductList
                   select p.ProductName;*/

        /*var Result = ProductList.Where(P => P.UnitsInStock == 0)
                                .Select(P => new { Id = P.ProductID, P.ProductName });// Product => Anonymous type {int,string}
        Result = from p in ProductList
                     //.Where(p => p.UnitsInStock == 0)
                 select (new { Id = p.ProductID, ProductName = p.ProductName });

        foreach (var item in Result)
        {
            Console.WriteLine(item);
        }*/

        /* var DiscountList = ProductList.Select(p => new Product
         {
             ProductID = p.ProductID,
             Category = p.Category,
             ProductName = p.ProductName,
             UnitsInStock = p.UnitsInStock,
             UnitPrice = 0.95M * p.UnitPrice
         }); // Product => Product

        DiscountList = from p in DiscountList
                       select new Product
                       {
                           ProductID = p.ProductID,
                           Category = p.Category,
                           ProductName = p.ProductName,
                           UnitsInStock = p.UnitsInStock,
                           UnitPrice = 0.90M * p.UnitPrice
                       };
        foreach (var item in DiscountList)
        {
            Console.WriteLine(item);
        }
        */

        // Indexed Select => valid in fluent syntax
        /* var Result = ProductList.Where(P => P.UnitsInStock == 0)
                                 .Select((P,i) => new { Index=i+1, P.ProductName });
         foreach (var item in Result)
         {
             Console.WriteLine(item);
         }
        */
        #endregion
        #region OrderBy - ordering element
        // oreder by one key
        /**** you can custom the ordering base by implement Compare( , ) function in IComparer<>
        var Result = ProductList.OrderBy(P => P.UnitsInStock)
                                .Select((P) => new { P.ProductName,P.UnitsInStock ,P.UnitPrice});

        Result = from x in ProductList
                 orderby x.UnitsInStock
                 select new { x.ProductName, x.UnitsInStock, x.UnitPrice };

        // Descending order
        Result = ProductList.OrderByDescending(P => P.UnitsInStock)
                                .Select((P) => new { P.ProductName, P.UnitsInStock, P.UnitPrice });

        Result = from x in ProductList
                 orderby x.UnitsInStock descending
                 select new { x.ProductName, x.UnitsInStock, x.UnitPrice };

        // oreder by more than one key 

        Result = ProductList.OrderBy(P => P.UnitsInStock)
                            .ThenBy(x=>x.UnitPrice) // .ThenByDescending()
                               .Select((P) => new { P.ProductName, P.UnitsInStock, P.UnitPrice });

        Result = from x in ProductList
                 orderby x.UnitsInStock descending, x.UnitPrice descending // the order of the second key executed based on the first key 
                 select new { x.ProductName, x.UnitsInStock, x.UnitPrice };

        Result=ProductList.Reverse() ; // reverse the ordering 

        foreach (var item in Result)
        {
            Console.WriteLine(item);
        }*/
        #endregion
        #region Element Operators - Immediate Execution
        /*var Result = ProductList.First();
        Result=ProductList.Last(); 
        List<Product> DiscountedList = new List<Product>();//Empty Sequnce

       // Result=DiscountedList.First();// throw Exception => input sequence have no elemnts
        Result = DiscountedList.FirstOrDefault();// Not Found=> return first element of sequence or default value(Not Found)
        Result = DiscountedList.LastOrDefault();// Not Found , No Exception will be thrown
        Result = ProductList.FirstOrDefault();

        Result=ProductList.First(p=>p.UnitsInStock== 0);   // return the element of sequence that match the predicate
        //Result=ProductList.Last(p=>p.UnitPrice>=500);   //if no element match the predicate will throw Exception
        Result = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
        Result = ProductList.LastOrDefault(p => p.UnitPrice >= 500);// Not Found

        // to write query syntax (not available here) ,we write Hybrid syntax (Mix btw fluent and query syntax)
        var R= (from p in ProductList
               where p.UnitsInStock == 0
               select new {p.ProductName,p.Category,p.UnitPrice}).First();
        //Console.WriteLine(R);//{ ProductName = Chef Anton's Gumbo Mix, Category = Condiments, UnitPrice = 21.3500 }

        Result = ProductList.ElementAt(2);
        //Result = ProductList.ElementAt(700);// throw exception(ArgumentOutOfRangeException)
        Result = ProductList.ElementAtOrDefault(700);// return the default ("NotFound)

        // Single => throw exception if the sequence empty or have more one element
        DiscountedList.Add(ProductList[0]);// single element in the sequance
        Result = DiscountedList.Single();// return the only one element in the input sequance
        //Result= ProductList.Single(); // throw exception
        Result = ProductList.Single(p=>p.ProductID==7);// throw exception if no elements match the predicate or more than one element match the predicate

        DiscountedList.RemoveAt(0);
        Result = ProductList.SingleOrDefault();// return null , the input sequence is empty
        //Result= ProductList.SingleOrDefault(p=>p.UnitsInStock==0);// throw exception if more than one element match the predicate
        Result = ProductList.SingleOrDefault(p => p.ProductID == 0);// return default if No element match the predicate


        Console.WriteLine(Result?.ProductName??"Not Found");
        */
        #endregion
        #region Aggregate function - Immediate
        // Count => return numeric value
        //Console.WriteLine(ProductList.Count());
        //Console.WriteLine(ProductList.Count);
        //Console.WriteLine(ProductList.LongCount() );
        //var Result = ProductList.Count(P=>P.UnitsInStock==0);
        //Product? p = ProductList.Min();

        //var Result = ProductList.Max();// throw Exception => u must Implement IComparable (max ??? what)
        // return max element based on IComparable implementation
        //var Result = ProductList.Max(P=>P.UnitsInStock);
        //Console.WriteLine(Result);

        //Console.WriteLine(ProductList.Average(P=>P.UnitsInStock));
        //Console.WriteLine(ProductList.Sum(P=>P.UnitPrice));

        // Aggragate => return T
        //var R = ProductList.Aggregate((x, y) =>
        //{
        //    Console.WriteLine($" x= {x} \n  y= {y}");
        //    return x.UnitPrice > y.UnitPrice ? x : y;
        // });
        //Console.WriteLine(R);
        //int n = 5;
        //int factorial = Enumerable.Range(1, n).Aggregate(1, (currentFactorial, num) => currentFactorial * num);
        ////// Result: 120 (1 * 2 * 3 * 4 * 5);
        //Console.WriteLine(factorial);

        //string[] words = { "apple", "banana", "cherry", "date" };
        //string longestWord = words.Aggregate((current, next) => current.Length > next.Length ? current : next);
        //// Result: "banana"
        #endregion
        #region Genereator 
        // Generating output sequance from no thing
        // we call them as a static members from Enumerable class
        //var Result = Enumerable.Range(5, 5);// Range(int ,int) => return integer value
        //foreach (var item in Result)
        //{
        //    Console.WriteLine(item);
        //}

        //var r= Enumerable.Empty<Product>();// generate empty sequance of <T>

        //var R1 = Enumerable.Repeat(3, 5);// value type => when modifying 
        //R1= R1.Concat(R1);
        //R1=R1.Where(i=>i>5);
        //foreach (var item in R1)
        //{
        //    Console.WriteLine(item);
        //}
        //Console.WriteLine();
        //Console.WriteLine(ProductList[0]);
        //Console.WriteLine();
        //ProductList[0].ProductName = "temp";
        //var R2 = Enumerable.Repeat(ProductList[0],5);//Refrence type => the modification will change in R2             
        //foreach (var item in R2)
        //{
        //    Console.WriteLine(item);
        //}

        #endregion
        #region SelectMany
        // output Seq count > input Sequence count
        // transform each element in input seq to sup sequence(IEnumerable<>)
        /*List<string> list = new List<string>() { "Mohamed Ali", "Ahemd Khaled", "Jan Sami" };
        var Result = list.SelectMany(l => l.Split(" "));
        foreach (var item in Result)
        {
            Console.WriteLine(item);
        }
        // Query Syntax
        Result = from N in list 
                 from SN in N.Split(" ")
                 orderby SN.Length
                 select SN;
        foreach (var item in Result)
        {
            Console.WriteLine(item);
        }
        var R= Result.SelectMany(l => l.ToCharArray());
        foreach (var item in R)
        {
            Console.WriteLine(item);
        }*/

        #endregion
        #region Casting operator - Immediate Execution

        /*List<Product> list=ProductList.Where(P=>P.UnitsInStock==0).ToList();
        Product[] arr = ProductList.Where(P => P.UnitsInStock == 0).OrderBy(P => P.UnitPrice).ToArray();
        var Result = ProductList.Where(P => P.UnitsInStock == 0)
                                //.ToHashSet();
                                //.ToDictionary(P => P.ProductID);//(key selector),,Dic<long(key),Product(value)>
                                //.ToDictionary(P => P.ProductID, Prd => new { Prd.ProductID, Prd.ProductName });
                                // Dic<long,Anonynmous[long,string]> ,, Dic<KeySelector,ValueSelector(Anonymous)>

                                .ToLookup(P => P.ProductID);
        */


        #endregion
        #region Set operators
        /*
        var seq1 = Enumerable.Range(0, 100);// 0.. 99
        var seq2=Enumerable.Range(50, 100);// 50 .. 149
        var Result = seq1.Union(seq2);// remove dublicate
        Result=seq1.Concat(seq2);  // concatenate all element of 1 and 2 with dublication => to remove duplication use Distinct on the result
        Result = Result.Distinct();

        Result=seq1.Except(seq2);// the first without the duplication with the second
        Result=seq1.Intersect(seq2);
        foreach (var item in Result)
        {
            Console.Write($"{item},");
        }
        */
        #endregion
        #region Quantifier - return boolean
        /*var seq1 = Enumerable.Range(0, 100);// 0.. 99
        var seq2 = Enumerable.Range(50, 100);// 50 .. 149
        Console.WriteLine(
             //ProductList.Any()// retun true if input seq have at least one element 
             //ProductList.Any(P=>P.UnitPrice>200)// 
             //retun true if input seq have at least one element matching the predicate

             // ProductList.All(P=>P.UnitsInStock>0) // retun true if all element in input seq match the predicate
             seq1.SequenceEqual(seq2)// return true if the two seq are equals
             // the second overload have comperer by IEqualityComparer if u want custom it


            );
        */
        #endregion
        #region Zip 
        // input 2 seq and output combined one seq with two column
        /*/ You can mix between any two types
         * List<string> NameList = new List<string>() { "Ahmed", "Ali", "Mohamed" };
        var lst1=Enumerable.Range(0, 10);
        var Res = NameList.Zip(lst1, (N, i) => new { i, Name = N });
        //Res=
        //{ i = 0, Name = Ahmed }
        //{ i = 1, Name = Ali }
        //{ i = 2, Name = Mohamed }
        foreach (var item in Res)
        {
            Console.WriteLine(item);
        }
        */


        #endregion
        #region Groubing
        /*var Result = from P in ProductList
                     where P.UnitsInStock > 0
                     group P by P.Category // if u want to complete , u must use the (into) to generate anew seq
                    into ProductGroup
                     where ProductGroup.Count() >= 10
                     orderby ProductGroup.Count() descending
                     select ProductGroup;
         // use fluent syntax //select new {Category=ProductGroup.Key , ProductCount=ProductGroup.Count()};
        // we use 2 loops one to iterate on groups by its key and the second to iterate on the elements of the one group
        foreach (var ProductGroup in Result)
        {
            Console.WriteLine($"Group key = {ProductGroup.Key}");
            foreach (var Product in ProductGroup)
            {
                Console.WriteLine($".{Product.ProductName}");
            }
        }
        */







        #endregion
        #region Let/Into - introduce neew range variable in query syntax
        /* List<string> Names = new List<string>()
         { "Ahmed","Aly","Mai","Sally","Moemen","Shimaa","Mohammed"};
         //replace => aoieuAOIEU
         // using RegularExpressions (nameSpace)
         var Result = from N in Names
                      select Regex.Replace(N, "[aoieuAOIEU]", "*")
                      // Restart Query with new Range variable , old Range variable is not accessable
                      into NoVol
                      where NoVol.Length >= 3 // after replace if name.Lengh>=3 oreder it desc 
                      orderby NoVol, NoVol.Length descending
                      select NoVol;
         //*hm * d
         //* ly
         //M**
         //M** m*n
         //M* h*mm * d
         //S* lly
         //Sh* m**


         //var Result= from N in Names
         //         let NoVol= Regex.Replace(N, "[aoieuAOIEU]", "*")
         //         // Let=> continue query with added range variable , old range is accessable
         //         where NoVol.Length >= 3 
         //         orderby NoVol, N.Length descending
         //         select NoVol;
         //*hm * d
         //* ly
         //M**
         //M** m*n
         //M* h*mm * d
         //S* lly
         //Sh* m**

         foreach (var item in Result)
         {
             Console.WriteLine(item);
         }

         */
        #endregion


        #region Join





        #endregion


        /*
        int[] numbers  = { 10, 9, 8, 7, 6 };

// The natural ordering of numbers is honored, making the following queries possible:

numbers.Take (3)  .Dump ("Take(3) returns the first three numbers in the sequence");
numbers.Skip (3)  .Dump ("Skip(3) returns all but the first three numbers in the sequence");
numbers.Reverse() .Dump ("Reverse does exactly as it says");
        */

        //}
    }
}