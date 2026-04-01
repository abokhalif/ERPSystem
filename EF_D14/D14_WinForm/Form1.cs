using D14_WinForm.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace D14_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => context?.Dispose();
        }
        northwindContext context;

        private void Form1_Load(object sender, EventArgs e)
        {
            context= new northwindContext();
            ///Error
            //dataGridView1.DataSource= context.Products;// Error => DeferedExecution (the memory is Empty)
            //var Result=from P in context.Products
            //           where P.UnitsInStock>0
            //           select P;
            //dataGridView1.DataSource=Result;

            // Two way to Binding with DB
            // 1-
            //context.Products.Load();// fetch all record(as Objects) from database into Local Memory
            //dataGridView1.DataSource= context.Products.Local.ToBindingList();// All Columns in Product will shown but Category not show because Lazy Loading that get the specific data (Products) and Category not belong to Product(Navigatinal prop)
            // 2-
            //var Result = (from P in context.Products
            //              where P.UnitsInStock == 0
            //              select P.ProductName);//SELECT [ProductName] from Product

            var Result = (from P in context.Products
                          where P.UnitsInStock == 0
                          select P).ToList();// select * from Product

            //var Result = from P in context.Products
            //              where P.UnitsInStock == 0
            //              select new { P.ProductName, P.Category.CategoryName };//  Eager Loading 
            // With Join in DB

            // 
            //var Result = from P in context.Products.Include(p=>p.Category)//when select from Product table join with category Table
            //             where P.UnitsInStock == 0
            //             select new { P.ProductName, P.Category.CategoryName };//Lazy Loading but Include force it to fetch Nav.prop and it can fetch more than nav => new { , , }

            foreach (var item in Result)//Deffered execution => the query executed when iterate on its result or converted to immedute exec. by .ToList() or any operator support immedute exec
            {
                //1-
                //Trace.WriteLine(item.Category?.CategoryName??"NF"); //Lazy Loading =>select and fetch the specific Column from DB and show them
                //2-
                //Trace.WriteLine(item);//Eager Loading => select all and Fetch all the data of Tables from DB and show u select
                // 3- (Include)
                Trace.WriteLine(item.ProductName);
            }
             





        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1- 
            //dataGridView1.EndEdit();
            //context.SaveChanges();  
        }
    }
}