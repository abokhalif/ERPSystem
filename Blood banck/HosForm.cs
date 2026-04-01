using Class1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using Class1;
namespace Blood_banck
{
    public partial class HosForm : Form
    {
        Class1.datacon dc = new datacon();
        public HosForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrForm df = new DrForm();
            df.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    String query1 = "insert into Hos (HosName,HAdd) " +
                    "values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                    dc.setData(query1);

                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
