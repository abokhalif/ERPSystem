using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoD12
{
    public partial class frmSqlDataAdapter : Form
    {
        public frmSqlDataAdapter()
        {
            InitializeComponent();
        }
        SqlConnection SqlCN = new SqlConnection("Server=.;Database=northwind;Integrated Security=true;TrustServerCertificate=true;");

        SqlCommand SqlCmd;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;

        private void frmSqlDataAdapter_Load(object sender, EventArgs e)
        {/*1-
            SqlCmd= new SqlCommand("Select * from Products",SqlCN);
            dataAdapter= new SqlDataAdapter(SqlCmd);
            dataTable=new DataTable();
            // Demo => the way that the list display the item(ToString())
            this.lstProducts.Items.Add(new { Id = 1, Name = "Ali" });
            this.lstProducts.Items.Add(new { Id = 2, Name = "Ahmed" });
            */
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            /* 1-
            dataAdapter.Fill(dataTable);// fill => open connection,execute the command,fetch data int datatable , close the connection
            this.Text=dataTable.Rows.Count.ToString();
            // Complex Data Binding => fill the control (list,Grid) by the all data of the command
             lstProducts.DataSource= dataTable;
            lstProducts.DisplayMember = "ProductName";
            lstProducts.ValueMember = "ProductID";// to determine wich data of column will dispaly 
            */

            //SqlCmd = new SqlCommand("Select * from Products where UnitsInStock > 45", SqlCN); // the first solution
            SqlCmd = new SqlCommand("Select * from Products where UnitsInStock > @UnitsInStock", SqlCN);// the second solutio
            SqlCmd.Parameters.AddWithValue("@UnitsInStock", 50); 
            dataAdapter = new SqlDataAdapter(SqlCmd);
            dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            grdViewProducts.DataSource = dataTable;
            
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = $"{lstProducts.SelectedValue}";// if without (.ValueMember) it display ToString() of the item => system.....
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCn = new SqlConnection("Server=.;Database=northwind;Integrated Security=true;TrustServerCertificate=true;");

            grdViewProducts.EndEdit();
            SqlDataAdapter adapter= new SqlDataAdapter("select * from Products", SqlCn);

            SqlCommand InsertCmd = new SqlCommand("Insert into Products values(@ProductName,@SupplierID,@CategoryID," +
                            "@QuantityPerUnit,@UnitPrice,@UnitsInStock," +
                            "@UnitsOnOrder,@ReorderLevel,@Discontinued ", SqlCn);
            InsertCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 40, "ProductName");
            InsertCmd.Parameters.Add("@SupplierID", SqlDbType.Int, 0, "SupplierID");
            InsertCmd.Parameters.Add("@CategoryID", SqlDbType.Int, 0, "CategoryID");
            InsertCmd.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar, 20, "QuantityPerUnit");
            InsertCmd.Parameters.Add("@UnitPrice", SqlDbType.Money, 0, "UnitPrice");
            InsertCmd.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt, 0, "UnitsInStock");
            InsertCmd.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt, 0, "UnitsOnOrder");
            InsertCmd.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt, 0, "ReorderLevel");
            InsertCmd.Parameters.Add("@Discontinued", SqlDbType.Bit, 0, "Discontinued");
            adapter.UpdateCommand = InsertCmd;

            SqlCommand UpdateCmd = new SqlCommand("Update Products set ProductName=@ProductName,SupplierID=@SupplierID,CategoryID=@CategoryID," +
                "QuantityPerUnit=@QuantityPerUnit,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock," +
                "UnitsOnOrder=@UnitsOnOrder,ReorderLevel=@ReorderLevel,Discontinued=@Discontinued ", SqlCn);
            UpdateCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 40,"ProductName");
            UpdateCmd.Parameters.Add("@SupplierID", SqlDbType.Int,0,"SupplierID");
            UpdateCmd.Parameters.Add("@CategoryID", SqlDbType.Int,0, "CategoryID");
            UpdateCmd.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar, 20, "QuantityPerUnit");
            UpdateCmd.Parameters.Add("@UnitPrice", SqlDbType.Money,0, "UnitPrice");
            UpdateCmd.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt,0,"UnitsInStock");
            UpdateCmd.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt,0,"UnitsOnOrder");
            UpdateCmd.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt,0, "ReorderLevel");
            UpdateCmd.Parameters.Add("@Discontinued", SqlDbType.Bit,0, "Discontinued");
            adapter.UpdateCommand=UpdateCmd;

            SqlCommand DeleteCmd = new SqlCommand("delete from Products where ProductID=@ProductID", SqlCn);
            DeleteCmd.Parameters.Add("@ProductID", SqlDbType.Int);
            adapter.DeleteCommand = DeleteCmd;

            DataTable dt = new DataTable();
            adapter.Update(dataTable);






            
        }
    }
}
