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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                Dashboard db = new Dashboard();
                db.Show();
               this.Close();
            }
            else
            {
                MessageBox.Show("Enter valid user name","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
