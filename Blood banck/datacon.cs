using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Class1
{
	 public class datacon
	{
		
	
        public SqlConnection getConnection()
		{
			SqlConnection con = new SqlConnection();
			con.ConnectionString = "Data Source=DESKTOP-U34GA37;Initial Catalog=bloodbank;Integrated Security=True";
			return con;
		}
		public DataSet getData(string query) // select
		{
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			cmd.CommandText = query;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public void setData(string query) // insertion deletion updating
		{
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			con.Open();
			cmd.CommandText = query;
			cmd.ExecuteNonQuery();
			con.Close();
			MessageBox.Show("Data processed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}
		
	}
}
