using System;
using System.Data.SqlClient;
public namespace Class1
{
	public Class1()
	{


        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "@Data Source=DESKTOP-U34GA37;Initial Catalog=bloodbank;Integrated Security=True";
            return con;
        }
        public DataSet getData(string query) // select
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.ConnectionText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.fill(ds);
            return ds;
        }

        public void setData(string query) // insertion deletion updating
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.ConnectionText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data processed successfully.", "Success", MessageBoxButtons.Ok, MessageBoxIcon.Information);

        }

    }

}
	
}
