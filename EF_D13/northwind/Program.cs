using Microsoft.EntityFrameworkCore;
using northwind.Models;

namespace northwind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (northwindContext context = new northwindContext())
            {
                #region Lazy Loading
                //var Result = from p in context.Products
                //             where p.UnitsInStock == 0
                //             //select p.ProductName// 1- fetch .ProductName only
                //             //select p              // 2- fetch all column of Product only - but i want the data of the Nav.prop
                //             //select new {p , p.Category.CategoryName}  //  3- fetch data of Product with join with Category table   // 1.2.3 => the default action of fetching data =>Lazy Loading
                //             ;                                           

                /* fetch all data during  Loading
                // if i want to fetch the all data of the table and of the Nav.prop(join) during Lazy Loading 
                //1- by using Eager Loading =>.Include(),.ThenInclude() =>fetch the all table with the all tables that has  arelation with them
                //2-default in EFcore5 will not load Null Nav.prop later if queried (iterated) after select statment
                //  In EF.net 6.4 =>load Null Nav.prop later if queried (iterated) after select statment (goes to Db every time is quered(print)) 
                //  To Enable old style - install-package mocrosoft.EntityFrameworkcore.Proxies
                //  and OnModelConfiguraing() Add optionBuilder.UseLazyLoadingProxies(true)
                //3- Explictly load =>using Context.Entry(item).Reference(p=>p.Category).Load; => if Nav.prop is one or Collection if Nav.prop is many and calling in 2 loop
                // if u want using EagerLoading after installing proxies by => OnModelConfiguraing() => {OptionBuilder.OnConfiguring(UseLazyLoadingProxies(false))
               //4-Lazy Loding by 1- install proxies and all Nav.prop make it virtual (applied On the all queris) or 2- (DP factory applied on specific query as u want [under study plan])
                 */

                /*Eager loading = Include() ,thenInclude() 
                var Result = (from p in context.Products.Include(P=>P.Category).Include(p=>p.Supplier)
                             where p.UnitsInStock == 0
                             select p)
                             ;
                */

                /*Explictly load by using Reference,collection
                var Result = (from p in context.Products
                              where p.UnitsInStock == 0
                              select p).ToList();// to convert to Immediate Execution
                */


                //foreach (var item in Result)
                //{
                //Console.WriteLine (item);

                //Console.WriteLine($"{item} , {item.Category?.CategoryName??"NA"}"); Error Null// when [select p ;] no fetching data over the selected table=>Lazy loading 
                //Console.WriteLine($"{item.ProductName} , {item.Category.CategoryName},{item.Supplier.CompanyName}");// after using Include

                /*Explictly load by using Reference,collection
                if (item.Category == null)
                    context.Entry(item).Reference(p => p.Category).Load(); // one , in each iterate goes to database to load the Category data record from the table
                //context.Entry(item).Collection(p => p."ICollection").Load(); // Many 
                //context.Entry(item).Collection(p => p."Employees").Query().where(e=>e.id>10);// EX for filtering 

                Console.WriteLine($"{item.ProductName} , {item.Category.CategoryName}");*/

                #endregion
                #region AsNoTracking() & AsNoTrackingWithIdentityResolution()

                //var entities = context.Products.AsNoTracking()// AsNoTracking() => if the 1 product supplied from
                //supplier A and the 2 product supplied from the same supplier A ,the method will generate for each row
                //in products a seperate instance from the same object [supplier A]
                /*    .Include(p=>p.Supplier).ToList(); /*Identity resolution is disabled, which means that if you retrieve the same entity twice, 
                                                       * EF Core will treat them as different objects even if they represent the same row in the database. 
                                                       * This can lead to multiple instances representing the same entity in memory.*/

                /* var entities2 = context.Products.AsNoTrackingWithIdentityResolution()//=> if the 1 product supplied from supplier A and the 2 product supplied from the same supplier A 
                 * ,the method will generate one instance from the same object [supplier A] for all rows in products that supplied from [supplier A]
                     .Include(p => p.Supplier).ToList();/* it enables identity resolution. When you retrieve the same entity twice within the same context instance, 
                                                         * EF Core will recognize them as the same entity and return the same object instance.*/

                #endregion

                #region Server-side & Client-side evaluation Example (review it)=> where the query executed
                /*
                          var users = context.Users
                 .Where(u => u.Name.StartsWith("J")) // Server-side evaluation: filtering is done in the database server.
                 .ToList(); // ToList() forces the query execution.

             // EF Core translates the LINQ query to SQL: SELECT * FROM Users WHERE Name LIKE 'J%';
             // The filtering is performed in the database server.

             // However, if you perform an unsupported operation:
             var filteredUsers = users //////Must the query in where()/////////
                 .Where(u => u.Name.ToUpper().Contains("A")) // Client-side evaluation: ToUpper() and Contains() are not translatable to SQL.
                 .ToList(); // ToList() forces the query execution.

                 // EF Core executes the previous query on the client side because ToUpper() and Contains() are not translatable to SQL.

             In this example, ToUpper() and Contains() are not directly translatable to SQL, so the query is partially evaluated on the client side after fetching the data from the server.

             Remember, it's essential to be cautious about client-side evaluation, as it can lead to performance issues, especially with large datasets. Whenever possible, aim to keep the query operations translatable to SQL for optimal performance.






                  */
                #endregion



                #region Find 
                // how to optimize the number of trips to DataBase
                // default for all L2E operator running against DBSet ,Run against Latest version in DB
                // var Result = context.Products.Take(10).ToList();

                //Console.WriteLine($"Local count {context.Products.Local.Count} ");
                //Console.WriteLine($"DataBase count {context.Products.Count()} ");

                // Go to Db to check if any products out of stock or not
                //if (context.Products.Any(p => p.UnitsInStock == 0))
                //    Console.WriteLine("Out of stock products"); // get the latest version of DB

                // optimize the trips to Db
                //if (context.Products.Local.Any(p => p.UnitsInStock == 0))// go to local first and check
                //    Console.WriteLine("Out of stock products");
                //else if (context.Products.Any(p => p.UnitsInStock == 0))//then go to DB if not found prds in Local
                //    Console.WriteLine("Out of stock products");
                //else
                //    Console.WriteLine("No Out of stock ");

                //context.Products.Load();// populate Local with all Data from DB and check as u want


                // EF have an operator (Find(PK)) check in Local firstly if not found check in Db by PK if not found return Null and not throw Exception 
                // var Result = context.Products.Find(5);
                //var Result = context.Products.Find(155);

                //Console.WriteLine( Result?.ProductName??"NA");
                #endregion


                

            }

        }
    }
}