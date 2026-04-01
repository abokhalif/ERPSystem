using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AdoD12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }// Load event executed after ctor 
        SqlConnection SqlCN;  
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCN = new SqlConnection();// you can write the string connection in the ctor but can use ConnectionString prop
            //SqlCN.ConnectionString = "Server=.;Database=northwind;Integrated Security=true;TrustServerCertificate=true;";
            // true=>windows Auth
            // false => user Auth
            

            // using Configuration file => to modify on the changed data as id , dataname by writting on config.xml file without visual studio
            SqlCN.ConnectionString=
            ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString;

            this.Text = ConfigurationManager.AppSettings["BranchId"];


            SqlCN.StateChange += (sender, e) => 
            this.Text = $"state was {e.OriginalState} and become {e.CurrentState}";

            SqlCN.InfoMessage += (sender, e) => MessageBox.Show(e.Message);//this event => occurs when sql serever return a warning  or informational message

            /*
             In summary, while both Close() and Dispose() can be used to close a connection, Dispose() is the preferred method because 
            it not only closes the connection but also releases any associated unmanaged and managed resources, 
            ensuring proper resource management. Using the using statement is a best practice for 
            managing the lifecycle of objects that implement the IDisposable interface, like SqlConnection.
             */
            // the sql connection it is an unmanaged resorce ,for this the Garbage can not free the saved resources from the memory it free the sglcn object only and the db donnot sence that so we use
            // 1-
            this.FormClosed += (sender, e) => SqlCN.Dispose();// to free the reserved resources (sql server) during closing the program 
            // or 2- => Using (keyword to manage the unmanaged resources) 
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(SqlCN.State==ConnectionState.Closed) 
            {
                SqlCN.Open();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SqlCN.State != ConnectionState.Closed)
            {
                SqlCN.Close();
            }
        }

        private void btnChangeDB_Click(object sender, EventArgs e)
        {
            if(SqlCN.State==ConnectionState.Open)
            {
                SqlCN.ChangeDatabase("NorthWind2021");
            }
        }
    }
}