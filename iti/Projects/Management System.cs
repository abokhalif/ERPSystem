using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects
{  
    class Department
    {
        public int DepartId { get; set; }
        public string DepartName { get; set; }=string.Empty;
        public Department(int departId,string departName)
        {
            DepartId = departId;
            DepartName= departName;
        }
        public override string ToString()
        {
            return $"DepartId={DepartId} , DepartName{DepartName}";
        }

    }
    abstract class StaffMember
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string EmpPhone { get; set; } = string.Empty;

        public string EmpEmail { get; set; } = string.Empty;
        public Department Dep { get; set; } 
        public StaffMember(int empId, string empName, string empPhone, string empEmail,Department dep)
        {
            EmpId = empId;
            EmpName = empName;
            EmpPhone = empPhone;
            EmpEmail = empEmail;
            Dep = dep;
        }
        public StaffMember()
        {

        }

        public abstract double Pay();
        public override string ToString()
        {
            return $"Id={EmpId},Name={EmpName},Phone={EmpPhone},Email={EmpEmail},Department={Dep}";
        }
    }
    class Volunteer: StaffMember
    {
        public string Amount { get; set; } = string.Empty;
        public Volunteer(int empId, string empName, string empPhone, string empEmail, string amount, Department department) : base(empId, empName, empPhone, empEmail, department)
        {
            Amount = amount;
        }
        public override double Pay()
        {
            return 0;
        }
        public override string ToString()
        {
            return $"Id={EmpId},Name={EmpName},Phone={EmpPhone},Email={EmpEmail},Amount={Amount}";
        }
    }
    class Employee:StaffMember
    {
        public string SSN { get; set; } = string.Empty;
        //public Project ProjectInfo { get; set; }
        public Employee(int empId, string empName, string empPhone, string empEmail, string ssn, Department department/*, Project projectInfo*/) : base(empId, empName, empPhone, empEmail, department)
        {
            SSN = ssn;
            //ProjectInfo = projectInfo;
        }
        public override double Pay()
        {
            return 0;
        }
        public override string ToString()
        {
            return $"Id={EmpId},Name={EmpName},Phone={EmpPhone},Email={EmpEmail},SSN={SSN}";
        }

    }
    class HourlyEmployee:Employee
    {
        public double HoursWorked { get; set; }
        public double Rate { get; set; }
        public HourlyEmployee(int empId, string empName, string empPhone, string empEmail,string ssn , Department department,double hoursWorked, double rate) : base(empId, empName, empPhone, empEmail,ssn, department)
        {
            HoursWorked= hoursWorked;   
            Rate= rate;
        }
        public void AddHours(int moreHour)
        {
            HoursWorked += moreHour;
        }
        public override double Pay()
        {
            return HoursWorked * Rate;
        }
        public override string ToString()
        {
            return $"Id={EmpId},Name={EmpName},Phone={EmpPhone},Email={EmpEmail},SSN={SSN},Department={Dep},HoursWorked{HoursWorked},Rate={Rate}";
        }

    }
    class SalaryEmployee : Employee
    {
        public double Salary{ get; set; }
        public SalaryEmployee(int empId, string empName, string empPhone, string empEmail, string ssn, Department department,double salary) : base(empId, empName, empPhone, empEmail, ssn, department)
        {
            Salary= salary; 
        }
        public override double Pay()
        {
            return Salary;
        }
        public override string ToString()
        {
            return $"Id={EmpId},Name={EmpName},Phone={EmpPhone},Email={EmpEmail},SSN={SSN},Department={Dep},Salary{Salary}";
        }

    }
    class CommissionEmployee : Employee
    {
        public double Target { get; set; }
        const double Com = 0.05;
        double salary =0;
        public CommissionEmployee(int empId, string empName, string empPhone, string empEmail, string ssn, Department department, double target) : base(empId, empName, empPhone, empEmail, ssn, department)
        {
            Target = target;
        }
        public override double Pay()
        {
            salary = Target * Com;
            return salary;
        }
        public override string ToString()
        {
            return $"Id={EmpId},Name={EmpName},Phone={EmpPhone},Email={EmpEmail},SSN={SSN},Department={Dep},Target{Target},Salary={salary}";
        }

    }
    class ExecutiveEmployee:SalaryEmployee 
    {
        public double Bonus { get; set; }
        public ExecutiveEmployee(int empId, string empName, string empPhone, string empEmail, string ssn, Department department, double salary,double bonus) : base(empId, empName, empPhone, empEmail,ssn, department,  salary)
        {
            Bonus = bonus;
        }
        public void AddBonus(double bonus)
        {
            Bonus += bonus;
        }
        public override double Pay()
        {
            return Salary+=Bonus;
        }
        public override string ToString()
        {
            return $"Id={EmpId},Name={EmpName},Phone={EmpPhone},Email={EmpEmail},SSN={SSN},Bonus{Bonus},Salary{Salary}";
        }

    }

    class Budget
    {
        public int Id { get; set;}
        public double Value { get; set;}
        public Budget(int id,double value)
        {
            Id= id;
            Value= value;   
        }
        public void IncreaseBudget(double amount)
        {
            Value+= amount;
        }
        public override string ToString()
        {
            return $"Id={Id},value={Value}";
        }
    }

    class Project
    {
        public int ProjectId { get; set; }
        public string Location { get; set; } = string.Empty;
        public Employee? Manager { get; set; }
        public double CurrentCost { get; set; }
        public Project(int id,string location,Employee manager,double currentCost )
        {
            ProjectId= id;
            Location= location;
            Manager= manager;
            CurrentCost= currentCost;

        }
        List<Budget>? BudgetList = new List<Budget>();
        
        public void AddBudget(Budget budget)
        {
            BudgetList?.Add(budget);
        }

        public void TotalBudget()
        {
            double total=0 ;
            for (int i = 0; i < BudgetList?.Count; i++)
            {
                total += BudgetList[i].Value;
            }
            Console.WriteLine($"Total buget for project {ProjectId} = {total }");

        }
        public override string ToString()
        {
            return $"Project Id={ProjectId},Location={Location},Manager{Manager},CurrentCost={CurrentCost}";
        }

    }

    class Staff
    {
        protected List<StaffMember> StaffList=new List<StaffMember> ();
        double totalPayroll = 0;
        public void CalcPayroll()
        {
            for(int i=0;i<StaffList.Count; i++)
            {
                totalPayroll += StaffList[i].Pay();
            }
            Console.WriteLine($"Total paying = {totalPayroll}");
        }
        public void AddMember(StaffMember member)
        {         
            StaffList?.Add(member);
        }
        public void DeleteMember(StaffMember member)
        {
            StaffList?.Remove(member);
        }
        public void ShowAll()
        {
            foreach (var item in StaffList)
            {
                //Console.WriteLine($"Id={item.EmpId},Name={item.EmpName},{item.EmpPhone},{item.EmpEmail},{item.Dep},{item.Pay");
                Console.WriteLine(item.EmpName);
            }
        }

    }
    internal class Project1
    {
        static void Main(string[] args)
        {
            Department dep1 = new Department(101, "CRM");
            Department dep2 = new Department(102, "ERP");
            Department dep3 = new Department(103, "ASP");
            Department dep4 = new Department(104, "SAP");            
            Console.WriteLine(dep1.DepartId);

            Employee e1 = new Employee(1001, "John Week", "0123456", "john@gmail.com","111111", dep1);
            Employee e2 = new Employee(1002, "Welaim deser", "0128556", "weliam@gmail.com", "111111", dep2);
            Employee e3 = new Employee(1003, "Asma Ali", "0178956", "asma@gmail.com", "111111", dep3);
            Employee e4 = new Employee(1004, "Domino", "0121476", "domino@gmail.com", "111111", dep1);
            Console.WriteLine(e2);
            Console.WriteLine(e1.Pay()); 


            Volunteer v1 = new Volunteer(2001, "Mohamed Ali", "01127558969", "ali@gmail.com","Junior", dep1);
            Volunteer v2 = new Volunteer(2002, "Eslam Ali", "01188888969", "eslam@gmail.com", "Senior", dep2);
            Console.WriteLine(v1);
            Console.WriteLine(v2.Pay());

            HourlyEmployee he1 = new HourlyEmployee(105, "Mohamed Ahmed", "11477", "@email", "147896523", dep4, 38, 20);
            HourlyEmployee he2 = new HourlyEmployee(106, "Ali Ahmed", "18777", "@email", "147896523", dep2, 40, 18);
            HourlyEmployee he3 = new HourlyEmployee(107, "Nadi Ahmed", "589632", "@email", "147896523", dep1, 33, 20);
            Console.WriteLine(he1);
            Console.WriteLine(he1.Pay());

            SalaryEmployee se1 = new SalaryEmployee(108, "ssssss", "111111", "email", "528555", dep1, 5000);
            SalaryEmployee se2 = new SalaryEmployee(109, "ssssss", "111111", "email", "528555", dep3, 5050);
            SalaryEmployee se3 = new SalaryEmployee(110, "ssssss", "111111", "email", "528555", dep4, 6000);
            Console.WriteLine(se1);
            Console.WriteLine(se2.Pay());

            CommissionEmployee ce1 = new CommissionEmployee(1111, "cccc", "88888888", "email", "111111", dep1, 500000);
            CommissionEmployee ce2 = new CommissionEmployee(1111, "cccc", "88888888", "email", "111111", dep3, 800000);
            CommissionEmployee ce3 = new CommissionEmployee(1111, "cccc", "88888888", "email", "111111", dep2, 900000);
            Console.WriteLine(ce1);
            Console.WriteLine(ce2.Pay());

            ExecutiveEmployee ee1 = new ExecutiveEmployee(112, "wwww", "77777", "email", "8888", dep1, 3000, 1000);
            ExecutiveEmployee ee2 = new ExecutiveEmployee(113, "wwww", "77777", "email", "8888", dep4, 2000, 8000);
            ExecutiveEmployee ee3 = new ExecutiveEmployee(114, "wwww", "77777", "email", "8888", dep2, 2500, 1500);
            Console.WriteLine(ee1);
            Console.WriteLine(ee2.Pay());

            Budget budget1 = new Budget(1, 2500);
            Budget budget2 = new Budget(2, 2800000);
            Budget budget3 = new Budget(3, 6000000);
            Console.WriteLine(budget1);
            budget1.IncreaseBudget(500);
            Console.WriteLine(budget1);

            Project proj1 = new Project(501, "Cairo", se1, 8000);
            Project proj2 = new Project(502, "Cairo", se3, 7000000);
            Project proj3 = new Project(503, "Cairo", ce1, 6000000);
            Project proj4 = new Project(504, "Cairo", ee2, 9000000);
            Console.WriteLine(proj1);
            proj1.AddBudget(budget1);
            Console.WriteLine(proj1);
            proj1.TotalBudget();

            Staff s1 = new Staff();
            s1.AddMember(e1);
            s1.AddMember(e2);
            s1.AddMember(e3);
            s1.AddMember(ce1);
            s1.AddMember(ce2);
            s1.AddMember(ce3);
            s1.DeleteMember(e1);
            s1.ShowAll();
            s1.CalcPayroll();
           // Console.WriteLine();
            

            //s1.CalcPayroll();

        }
    }
}
