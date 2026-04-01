using ConsoleApp.Context;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(CompanyContext context =new CompanyContext())
            {

                /* Employee Entity 
                context.Database.Migrate(); // == Update-database in CLI
                 * 
                 * //Employee E = new Employee()
                //{
                //    Name = "Ahmed Ali",
                //    Age = 25,
                //    Salary = 4000,
                //    Email = "Ahmed.Ali@gmail.com"
                //};

                // Does SaveChanges() detect the validation ????
                Employee E = new Employee()
                {
                    Name = "Samer Ali",
                    Age = 20,
                    //Salary = 4000,
                    //Email = "Samer.Ali"
                };
                Console.WriteLine(context.Entry(E).State);// Detached => not bind with Changetracker

                context.Add(E);// this add not in Db but in [context.Employees.Local]
                // u can not use context.Add() and u can change the state of the entity that u want (context.Entry(E).State=EntityState.Added
                Console.WriteLine(context.Entry(E).State); // Added

                context.SaveChanges();// Not check the validation=> this feture removed begin EF6.4 => because UI and Business Layer validate data
                // but we want to check the validation in EF runtime so we must override on SaveChanges() ;

                Console.WriteLine(context.Entry(E).State);// UnChanged

                Console.WriteLine(E.ID);   //1
                */

                //context.Departments.Add(new Department() { Name = "Engineering", YearOfCreation = 2020 });

                /* Adding in two table with Many to many relationShip without attribute 
                 */
                //Student s1 = new Student() { Name = "s1" };
                //Student s2 = new Student() { Name = "s2" };
                //Subject sub1 = new Subject() { Title = "Math" };
                //Subject sub2 = new Subject() { Title = "Finance" };
                //Subject sub3 = new Subject() { Title = "IT" };

                //s1.Subjects.Add(sub1);
                //s1.Subjects.Add(sub2);
                //s2.Subjects.Add(sub2);
                //s2.Subjects.Add(sub3);

                //context.AddRange(new Subject[] { sub1, sub2, sub3 });
                //context.AddRange(new Student[] { s1, s2});

                Student s1 = new Student() { Name = "s1" };
                Student s2 = new Student() { Name = "s2" };
                Subject sub1 = new Subject() { Title = "Math" };
                Subject sub2 = new Subject() { Title = "Finance" };
                Subject sub3 = new Subject() { Title = "IT" };

                s1.StudentSubjects.Add(new StudentSubject { Student=s1,Subject=sub1,Grade=10});
                s1.StudentSubjects.Add(new StudentSubject { Student = s1, Subject = sub2, Grade =8  });
                s2.StudentSubjects.Add(new StudentSubject { Student = s2, Subject = sub2, Grade = 7 });
                s2.StudentSubjects.Add(new StudentSubject { Student = s2, Subject = sub3, Grade = 6 });

                context.AddRange(new Subject[] { sub1, sub2, sub3 });
                context.AddRange(new Student[] { s1, s2 });


                context.SaveChanges();  

            }

        }
    }
}