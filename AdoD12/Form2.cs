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
    public partial class Form2 : Form
    {
        public Form2()
        {

            //////** Connection Mode  ****///
            InitializeComponent();
            SqlCN = new SqlConnection("Server=.;Database=northwind;Integrated Security=true;TrustServerCertificate=true;");
            SqlCmd = new SqlCommand();
            SqlCmd.Connection= SqlCN;
            /* 1- Execute string query
            //the default type of Command is text(query) but if u use strored procedures or tableDirect of DB u must change the type of command to obj.CommandType=CommandType.StoredProcedure
            //SqlCmd.CommandText = "select count(*) from products"; */

            //2- Execute Non Query (stored Procedure)
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "UpdateProductNameByProductId";// this have parameters so we add them at sqlcmd
            SqlCmd.Parameters.Add("@ProductId", SqlDbType.Int);
            SqlCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 40);
            


        }
        SqlConnection SqlCN;
        SqlCommand SqlCmd;

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //if (SqlCN.State == ConnectionState.Closed)
            //    SqlCN.Open();

            /*1- Execute string query
            //if (int.TryParse(SqlCmd.ExecuteScalar()?.ToString()??"0", out int n))
            //    this.Text = $"Product Count ={n}";
            // */

            /* 2- Execute Non Query (stored Procedure)
            /// set sql parameters values u can set it from user (TextBox)
            SqlCmd.Parameters["@ProductId"].Value = 74;
            SqlCmd.Parameters["@ProductName"].Value = "Longlife Tofu";
            int Res = SqlCmd.ExecuteNonQuery();// return integer , nonQuery=> insert ,update delete
            this.Text = $"{Res} Rows Affected";*/
                      
            //SqlCN.Close();

            if(int.TryParse(cmbProductIds.SelectedItem?.ToString()??string.Empty, out int productId)) 
            {
                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();
                SqlCmd.Parameters["@ProductID"].Value = productId;
                SqlCmd.Parameters["@ProductName"].Value = txtNewProductName.Text;

                int Res = SqlCmd.ExecuteNonQuery();
                this.Text = $"{Res} Rows Affected";

                SqlCN.Close();  
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlCommand sqlGetProdId= new SqlCommand("Select ProductID from Products",SqlCN);
            SqlCN.Open();   
            SqlDataReader Dr= sqlGetProdId.ExecuteReader();// SqlDataReader=> not have a public ctor 
            while (Dr.Read())
            {
                cmbProductIds.Items.Add(Dr.GetInt32("ProductID"));
            }
            SqlCN.Close();  

        }
    }
}
