using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_banck
{
    public partial class Stock : Form
    {
        Class1.datacon dc = new Class1.datacon();

        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            String query = "select typeblood,sum(NoOfBags) as Quantity from NewDoner group by(typeblood)";
            DataSet ds = dc.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
