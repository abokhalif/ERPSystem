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
    public partial class frmProductDetailsView : Form
    {
        public frmProductDetailsView()
        {
            InitializeComponent();
        }
        SqlConnection SqlCN= new SqlConnection("Server=.;Database=northwind;Integrated Security=true;TrustServerCertificate=true;");

        SqlCommand SqlCmd;
        SqlDataAdapter dataAdapter;
        DataTable dataTable=new DataTable  ();
        private void frmProductDetailsView_Load(object sender, EventArgs e)
        {
            SqlCmd= new SqlCommand ("select * from Products", SqlCN);
            dataAdapter= new SqlDataAdapter(SqlCmd);
            dataAdapter.Fill(dataTable);

            // simple Data Binding => link small controls (label ,txtBox,..) with data table
            //lblProductId.DataBindings.Add("Text", dataTable, "ProductID");
            //txtProductName.DataBindings.Add("Text", dataTable, "ProductName");
            //numUnitsInStock.DataBindings.Add("Value", dataTable, "UnitsInStock");

            ProductbindingSource= new BindingSource(dataTable,"");// to move through data source
            lblProductId.DataBindings.Add("Text", ProductbindingSource, "ProductID");
            txtProductName.DataBindings.Add("Text", ProductbindingSource, "ProductName");
            numUnitsInStock.DataBindings.Add("Value", ProductbindingSource, "UnitsInStock");

        }
        BindingSource ProductbindingSource;

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ProductbindingSource.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ProductbindingSource.MoveNext();

        }

       
    }
}
