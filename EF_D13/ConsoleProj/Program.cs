using Microsoft.EntityFrameworkCore;

namespace ConsoleProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(PersonContext context=new PersonContext())
            {
                /*Ex01 => TpH with DbSet per type
                // DbSet<> per concrete class , in this Ex01 we have two DbSet 
                context.Teachers.Add(new Teacher() { FullName = "Ahmed ali", HireDate = new DateTime(2000, 5, 5) });
                context.Students.Add(new Student() { FullName = "Mahmoud Mohamed", HireDate = new DateTime(2022, 9, 15) });

                context.SaveChanges();

                Console.WriteLine("Teachers");
                foreach (var item in context.Teachers)
                {
                    Console.WriteLine($"{item.FullName} {item.HireDate}");
                }
                Console.WriteLine("Students");
                foreach (var item in context.Students)
                {
                    Console.WriteLine($"{item.FullName} {item.HireDate}");
                }
                */

                //Ex02 => TpH with single DbSet per the all Hirwrechy
                //context.People.Add(new Teacher() { FullName = "Ahmed ali", HireDate = new DateTime(2000, 5, 5) });
                //context.People.Add(new Student() { FullName = "Mahmoud Mohamed", HireDate = new DateTime(2022, 9, 15) });

                //context.SaveChanges();
                /* to ignore .HasQueryFilter in this query only
                var Result = from t in context.People.IgnoreQueryFilters()
                             where t.IsEmployee == true
                             select t;
                */

                //Console.WriteLine("Teachers");
                //foreach (var item in context.People.OfType<Teacher>())
                //{
                //    Console.WriteLine($"{item.FullName} {item.HireDate}");
                //}
                //Console.WriteLine("Students");
                //foreach (var item in context.People.OfType<Student>())
                //{
                //    Console.WriteLine($"{item.FullName} {item.HireDate}");
                //}
                
            }
        }
    }
}