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
    public partial class TypeBlood : Form
    {
        Class1.datacon dc = new Class1.datacon();
        public TypeBlood()
        {
            InitializeComponent();
        }

        private void TypeBlood_Load(object sender, EventArgs e)
        {
            String query = "select * from NewDoner";
            DataSet ds = dc.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string query = "select * from NewDoner where typeblood like '" + textBox1.Text + "%' ";
                DataSet ds = dc.getData(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                string query = "select * from NewDoner";
                DataSet ds = dc.getData(query);
                dataGridView1.DataSource = ds.Tables[0];

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
