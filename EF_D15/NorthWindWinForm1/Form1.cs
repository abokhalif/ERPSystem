using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthWindWinForm1.Context;

namespace NorthWindWinForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBContext context = new DBContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            // to execute sql query or Stored procedures return object of Entities
            /* List<Product> products = //context.Products.FromSqlRaw($"Exec [TenProducts]").ToList(); // sp_ without parameters
                                      // context.Products.FromSqlRaw($"select * from Products where UnitPrice<@unitprice", new SqlParameter("@unitprice", 10)).OrderBy(p=>p.ProductID).ToList();
                                      context.Products.FromSqlRaw($"select * from Products where UnitPrice<{100}").ToList();
             this.grdProducts.DataSource = products;

            // to execute sql NONquery or Stored procedures return number of row (update,insert delete)
            // var R = context.Database.ExecuteSqlRaw("Any non Querysql statement ");
            // var r = context.Database.ExecuteSqlInterpolated($"");
            */

            // 
            // what do u want when the sql query., stored procedure , function , view => return not mapped data type , I create a keyLess class where it map the return DT  
            // KeyLess Class(DTO data Transfer object) => not maaped to database(not need to Migration) and not run CRUD operation(Read only and returned entities not tracked) its as a virtual class can use it in queries only
            #region KeyLess Class Ex
            // Execute sp_GetTopIDs
            // declare the variables
            SqlParameter Top = new SqlParameter() { ParameterName = "@Top", SqlDbType = System.Data.SqlDbType.Int, Value = 5 };
            SqlParameter OverAllCount = new SqlParameter() { ParameterName = "@OverAllCount", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            // define DbSet and Exec
            var Result =
            context.Set<TopCustID>().FromSqlRaw("Exec GetTopIDs @Top ,@OverAllCount", Top, OverAllCount).ToList();

            this.grdProducts.DataSource = Result;
            this.Text = OverAllCount.Scale.ToString();//An Error , output var not exec in sql server
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.grdProducts.EndEdit();
            context.SaveChanges();
        }
    }
}