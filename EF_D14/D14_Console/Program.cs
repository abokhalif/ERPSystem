using D14_Console.Context;
using D14_Console.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace D14_Console
{
    /// <summary>
    /// UnManaged Resource => release the resource after using it by
    /// 1- DeConstructor(close())
    /// 2- Dispose();
    /// 3- using(context=new context()){code} == 
    /// Context context=new( ) ;
    /// try{code } ... finally{context.Dispose()} }; 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            using(EnterpriseContext context=new EnterpriseContext ())
            {
                #region Drop and Creation DB
                ///adding new class not suitable for the database schema so we delete the db and create anew db but the data will droped
                // Very bad practice to drop DB each run to code => we will use Migration
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated ();
                #endregion
                // Migration => allow you to evolve your database schema over time as your application's data model changes.
                // we have two ways to use Migration :-
                // 1-  CLI (package manager console)
                // * To add a new migration => for creating DB or any modification on DB [Add-Migration InitialCreate(migration_Name)] 
                // * To apply the migration and update the database schema, use [Update-Database]
                // in code (in VisualStudio)
                //*context.Database.Migrate(); with each modifying in the structure of tables[data model]
                //* context.SaveChanges(); 


                #region Insert
                //Department D01 = new Department() { Name = "Engineering" };// DepartmentID = > PK its default identity
                //Department D02 = new Department() { Name = "Hr" };

                //context.Departments.Add(D01);// to add the object to DbSet<> in EnterpriseContext class , the object now in LocalMemory not arrived to data base  
                //context.Add(D02);// start from EFcore 3.1

                //Console.WriteLine(context.Departments.Local.Count());// 2 object in Memory

                //context.SaveChanges();// connect to database and commit all changes


                //Console.WriteLine(D01.Name);
                //Console.WriteLine(D02.Name);
                #endregion
                #region Select , Update
                //// Linq to EF
                //var result = context.Departments.Where(d => d.Name == "Hr"); // do not listen in database because Defferd execution so we use immediate execution (as single operator) or use .ToList() ...
                ////Console.WriteLine(result.Name); // Error result is null here
                //Department? D = result.FirstOrDefault();
                //Console.WriteLine(context.Departments.Local.Count()); // 1 => only one object => .First())
                //Console.WriteLine(context.Entry(D).State); // unchanged
                ////Console.WriteLine(  D?.Name); // Hr
                //////D.Name = "Human Resources";
                //// context.SaveChanges ();
                #endregion
                #region Delete

                //context.Departments.Remove(context.Departments.First());// remove from memory
                //context.SaveChanges();// remove from data base

                #endregion

                //Department department = new Department() { Name = "CS" };
                //Department department1 = new Department() { Name = "IS" };
                //Department department2 = new Department() { Name = "GIS" };

                //TrainingCourse course = new TrainingCourse() { CourseTitle = "8th Habbits", CourseDuration = 8 };
                Employee employee = new Employee()
                {
                    
                    FName = "Ahmed",
                    LName = "Ali",
                    Age = 22,
                    Salary = 6000,
                    Address = "Cairo",
                    DepartmentID=10
                    
                };

                //context.Add(course);// add to context cache memory by default without define DbSet<TrainingCourse>
                //context.TrainingCourses.Add(course); // after define DbSet<TrainingCourse>
                //context.Departments.Add(department);
                //context.Departments.Add(department1);
                //context.Departments.Add(department2);
                context.Employees.Add(employee);
                context.SaveChanges(); 



            }

        }
    }
}