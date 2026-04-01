using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public class DBManager
    {
        SqlConnection sqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter DA;
        DataTable DT;
        public DBManager()
        {
            try
            {
                sqlCn = new SqlConnection();
                sqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWindCn"].ConnectionString;
                sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlCn;
                DA = new SqlDataAdapter(sqlCmd);
                DT = new DataTable();
            }
            catch
            {
                //LogException => Search 
            }
        }

        public int ExecuteNonQuery(string SpName)// insert ,update,delete
        {
            int R=-1;
            try
            {
                if (sqlCn.State == ConnectionState.Closed)
                {
                    sqlCn.Open();
                    sqlCmd.CommandText = SpName;
                    sqlCmd.Parameters.Clear();
                    R = sqlCmd.ExecuteNonQuery();
                    sqlCn.Close();
                }
            }
            catch 
            {
                throw;
            }
            return R;
        }

        public int ExecuteNonQuery(string SpName,Dictionary<string,object> ParamList)// insert ,update,delete
        {
            int R = -1;
            try
            {
                if ((sqlCn.State == ConnectionState.Closed)&& (ParamList?.Count>0))
                {
                    sqlCn.Open();
                    sqlCmd.CommandText = SpName;
                    sqlCmd.Parameters.Clear();
                    foreach (var item in ParamList)
                    {
                        sqlCmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    R = sqlCmd.ExecuteNonQuery();
                    sqlCn.Close();
                }
            }
            catch
            {
                throw;
            }
            return R;
        }
        public object ExecuteScalar(string SpName)// max,min ..
        {
            object R=new object ();
            try
            {
                if (sqlCn.State == ConnectionState.Closed)
                {
                    sqlCn.Open();
                    sqlCmd.CommandText = SpName;
                    sqlCmd.Parameters.Clear();
                    R = sqlCmd.ExecuteScalar();
                    sqlCn.Close();
                }
            }
            catch
            {
                throw;
            }
            return R;
        }
        public int ExecuteScalar(string SpName, Dictionary<string, object> ParamList)
        { throw new NotImplementedException(); }

        public int ExecuteDataTable(string SpName, Dictionary<string, object> ParamList)
        { throw new NotImplementedException(); }
        public DataTable ExecuteDataTable(string SpName)// 
        {
            DT.Clear();
            try
            {
                sqlCmd.Parameters.Clear();
                sqlCmd.CommandText = SpName;
                DA.Fill(DT);
            }
            catch
            {
                // LogException type,time,message,stacktrace
            }
            return DT;
        }
    }
}