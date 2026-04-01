using Class1;
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
    public partial class AllDoner : Form
    {
        datacon dc = new datacon();

        public AllDoner()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllDoner_Load(object sender, EventArgs e)
        {
            string query = "select * from NewDoner ";
            DataSet ds = dc.getData(query);
            dataGridView1.DataSource = ds.Tables[0];

        }
    }
}
