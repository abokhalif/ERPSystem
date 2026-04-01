using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static D10.ListGenerators;


namespace D10
{
    internal class Assignment
    {
        static void Main(string[] args)
        {
            //LINQ - Restriction Operators
            //IEnumerable<Product> R;
            //R = ProductList.Where(p => p.UnitsInStock == 0);

            //R= ProductList.Where(p => p.UnitsInStock != 0 && p.UnitPrice>3);

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var arr = Arr.Where((x,y)=>x.Length<y);
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            //LINQ - Element Operators
            //var R = ProductList.Where(p => p.UnitsInStock == 0).First();
            //var R = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(R?.ProductName??"NA");
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };// without ordering
            //var R=Arr.Where(a=>a>5).ElementAt(1);
            //Console.WriteLine(R);

            //LINQ - Set Operators
            //var seq1 = Enumerable.Range(0, 100);// 0.. 99
            //var seq2 = Enumerable.Range(50, 500);// 50 .. 149
            //var Result = seq1.Except(seq2);// the first without the second
            ////Result = seq1.Intersect(seq2);
            ///
            //Product p1= new Product();  
            //Product p2 = new Product();
            //var Result = ProductList.Select(p => p.Category).Distinct();
            //var r1 = Enumerable.Range(0,ProductList.Count).Select(l => ProductList[l].ProductName[0]);
            //var r2 = Enumerable.Range(0, CustomerList.Count).Select(i => CustomerList[i].CompanyName[0]);
            //var Result=r1.Union(r2);
            //Result=r1.Intersect(r2);    
            //Result=r1.Except(r2);   
            //var r1 = Enumerable.Range(0, ProductList.Count).Select(l => ProductList[l].ProductName[^3..]);
            //var r2 = Enumerable.Range(0, CustomerList.Count).Select(i => CustomerList[i].CompanyName[^3..]);
            //var Result =r1.Concat(r2);
            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            // LINQ - Aggregate Operators
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var R=Arr.Where(a=>a%2!=0).Count();
            //Console.WriteLine(R);
            //2. Return a list of customers and how many orders each has.
            //Customer c = new Customer();
            //var R = CustomerList.Select(C => $"{C.CompanyName} ,{C.Orders.Count()}");
            //3.Return a list of categories and how many products each has
            //List<string> R=new List<string> ();
            //ProductList.ForEach(product =>
            //{
            //    string item = $"{product.Category}  -> {ProductList.Count(p => p.Category == product.Category)}";
            //    if (!R.Contains(item))
            //        R.Add(item);
            //});

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //int c = Arr.Sum();
            //Console.WriteLine(c);
            //6. Get the total units in stock for each product category

            //var Result = from P in ProductList
            //             where P.UnitsInStock > 0
            //             group P by P.Category
            //             into ProductGroup
            //             select ProductGroup;
            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item.Key);
            //    decimal sum = 0;
            //    foreach (var i in item)
            //    {
            //        sum += i.UnitPrice;
            //    }
            //    Console.WriteLine(sum);
            //}

            var Result = from P in ProductList
                         where P.UnitsInStock > 0
                         group P by P.Category
                         into ProductGroup
                         select new{ Category= ProductGroup.Key,totalUnitInStock= ProductGroup.Sum(p=>p.UnitsInStock)};

            foreach (var item in Result)
            {
                Console.WriteLine(item);
            }

            



            //8. Get the cheapest price among each category's products
            //ProductList.ForEach(product =>
            //{

            //});

            //foreach (var item in R)
            //{
            //    Console.WriteLine(item);
            //}




        }


    }
}
