using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8
{

    /// <summary>
    ///  Publisher
    /// </summary>
    class Employee
    {
        //public event EventHandler EmployeeLayOff; 
        public event EventHandler<EventArgs> EmployeeLayOff; 

        protected virtual void OnEmployeeLayOff(EventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);   
        }
        public int EmployeeID;//{ get; set; }
        public DateTime BirthDate;//{ get; set; }
        public int VacationStock;//{ get; set; }
        
        public Employee(int i,DateTime d,int v )
        {
            EmployeeID= i;
            BirthDate = d;
            VacationStock = v;
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            int Period = To.Day - From.Day;
            if (Period <= VacationStock) { return true; }
            else
            {
                // Notify Subs,
                OnEmployeeLayOff(new EventArgs());
                return false;
            }            
        }
        public void EndOfYearOperation()
        {
            int Years = (DateTime.Now.Year - BirthDate.Year);
            if (Years > 60) 
            {
                // Notify Subs.
                OnEmployeeLayOff(new EventArgs());
                Console.WriteLine($"Employee {EmployeeID} is Greater than 60 Years Thanks ,SO He in the End of Year Operation");
                
            }            
        }
        public override string ToString()
        {
            return $"Id {EmployeeID} born at {BirthDate} it's vacation is {VacationStock}";
        }
    }
    public enum LayOffCause
    {
        GreaterThan60 = 0,
        EmptyVacationStock = 1
    }

    class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public Department(int i,string d)
        {
            DeptID = i;
            DeptName = d;

        }
        List<Employee> Staff=new List<Employee> (10);
        public void AddStaff(Employee E)
        {
            
            Staff.Add(E);
            Console.WriteLine($"Employee {E.EmployeeID} is added To {this.DeptName}");
            E.EmployeeLayOff += RemoveStaff;

            ///Try Register for EmployeeLayOff Event Here
        }

        ///CallBackMethod
        public void RemoveStaff(object? sender,EventArgs e)
        {
            if(sender is Employee emp)
            {
                Staff.Remove(emp);
                Console.WriteLine($"the Employee {emp.EmployeeID} is Removed from {this.DeptName} ");
            }
            
        }
        public void PrintStaff(Employee E)
        {
            foreach (var item in this.Staff)
            {
                Console.WriteLine(item);
            }
        }
    }


    class Assignment
    {
        static void Main(string[] args)
        {
            DateTime d1 = new DateTime(199, 05, 05);
            Employee e1 = new Employee(01,d1,14) ;
            Console.WriteLine(e1);

            DateTime d2 = new DateTime(195, 05, 05);
            Employee e2 = new Employee(02, d2, 10);
            Console.WriteLine(e2);

            DateTime d3 = new DateTime(1990, 05, 05);
            Employee e3 = new Employee(03, d3, 5);
            Console.WriteLine(e3);

            Console.WriteLine();

            Department D = new Department(011, "Etisalat");
            DateTime dfrom = new DateTime(2000, 05, 01);
            DateTime dto = new DateTime(2000, 05, 30);

            // call the Event
            D.AddStaff(e1);
            D.AddStaff(e2);
            D.AddStaff(e3);

            //DateTime d4 = new DateTime(190, 05, 05);

            e1.RequestVacation(dfrom, dto);
            e2.EndOfYearOperation();
            //e1.EndOfYearOperation();

            //e1.EmployeeLayOff += D.RemoveStaff;
            //e2.EmployeeLayOff += D.RemoveStaff;

            //e1.RequestVacation(dfrom, dto);
            //e2.RequestVacation(dfrom, dto);
            //e2.EndOfYearOperation();

        }


    }
}
