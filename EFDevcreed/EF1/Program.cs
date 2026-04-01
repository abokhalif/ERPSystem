using EF1.Context;
using EF1.Models;
using Microsoft.EntityFrameworkCore;

namespace EF1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Publisher p1 = new Publisher() {FName = "Abdallah", LName = "saber" };

            var context = new EFContext();
            //var p2 = context.Find<Publisher>(1);
            //p2.LName = "Khalifa";
            ////context.Add(p2);
            //var Blog=context.Blogs.Where(b=>b.Id>=900).ToList().Append(new Blog { Name="df",Url="sdds"});// adding after fetching data from Db,adding from last 
            //var Blog2= context.Blogs.Where(b => b.Id >= 900).ToList().Prepend(new Blog { Name = "df", Url = "sdds" });// adding after fetching data from Db,adding from First 
            //var Blog = context.Blogs.Skip(1).Take(10);
            //var Blog = context.Blogs.Skip(1).Take(new Range(10, 20));

            #region global query filter
            //var publisher=context.Publishers.Select(p=>p.Id).ToList();//applied global query filter
            //var publisher =context.Publishers.IgnoreQueryFilters().Select(p=>p.Id).ToList();//Ignore global query filter
            
            //foreach (var item in publisher)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Types of Grouping
            //var Blog = context.Blogs.GroupBy(b => b.Url).Select(b => new { Url = b.Key ,BlogCount=b.Count(),BlogSum=b.Sum(p=>p.Id)}).ToList();
            //List<Publisher> publisher = new List<Publisher>();
            //var cat = context.Publishers.GroupBy(p => p.FName).Select(p => new { FName = p.Key, publisher = p.ToList() }).OrderBy(p=>p.FName);
            //var cat = context.Publishers.ToLookup(P => P.FName); ***//very good and very nice
            //var cat = context.Publishers.Select(p => new { p.FName, p.Id, p.DisplayName }).ToLookup(P => P.FName);
            // var cat = context.Publishers.GroupBy(p => p.FName).ToDictionary(g => g.Key, g => g.ToList());
            /*foreach (var item in cat)
            {
                Console.WriteLine($"key={item.FName}");
                foreach (var i in item.publisher)
                {
                    Console.WriteLine($"value={i.Id} {i.DisplayName}");
                }
                Console.WriteLine();
            }*/
            //foreach (var item in cat)
            //{
            //    Console.WriteLine($"key={item.Key}");
            //    foreach (var i in item.Value)
            //    {
            //        Console.WriteLine($"value={i.Id} {i.DisplayName}");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region Join
            //var post0 = context.Posts.Join(context.Blogs, P => P.Blog.Id, B => B.Id, (post, blog) => new { postId = post.Id, BlogUrl = blog.Url, BlogName=blog.Name });
            //var post1 = from p in context.Posts
            //            join b in context.Blogs
            //            on p.Blog.Id equals b.Id
            //            select new { postId = p.Id, BlogUrl = b.Url, BlogName = b.Name };
            //foreach (var item in post1)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            //context.SaveChanges();

        }
    }
}