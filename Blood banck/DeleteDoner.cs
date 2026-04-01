using Class1;
using System;
using System.Collections;
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
    public partial class DeleteDoner : Form
    {
        Class1.datacon dc = new datacon();
        public DeleteDoner()
        {
            InitializeComponent();
        }

       /* private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text.ToString());
            string query = "select * from NewDoner where DOner_id='" + id + "'";
            DataSet ds = dc.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                textBox5.Text = ds.Tables[0].Rows[0][4].ToString();
                textBox6.Text = ds.Tables[0].Rows[0][9].ToString();
                comboBox1.Text = ds.Tables[0].Rows[0][5].ToString();
                comboBox2.Text = ds.Tables[0].Rows[0][6].ToString();
                textBox7.Text = ds.Tables[0].Rows[0][7].ToString();

                textBox9.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                int id = int.Parse(textBox1.Text.ToString());
                string query = "delete from NewDoner where Doner_id = '" + id + "' ";
                dc.setData(query);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox7.Clear();
                textBox9.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
