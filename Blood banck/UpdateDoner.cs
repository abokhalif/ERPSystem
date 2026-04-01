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

namespace Blood_banck
{
    public partial class UpdateDoner : Form
    {
        Class1.datacon dc = new Class1.datacon(); 
        public UpdateDoner()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text.ToString());
            string query = "select * from NewDoner where DOner_id='" +id+ "'";
            DataSet ds = dc.getData(query);
            if (ds.Tables[0].Rows.Count!=0)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "update NewDoner set fname='" + textBox2.Text + "',lname='" + textBox3.Text + "'," +
                    "mobile='" + textBox4.Text + "',email='" + textBox5.Text + "',gender='" + comboBox1.Text + "'," +
                    "typeblood='" + comboBox2.Text + "', addr='" + textBox7.Text +"' , " +
                    "NoOfBags='" + Int32.Parse(textBox6.Text) + "',age='" + Int32.Parse(textBox9.Text) + "'";

                dc.setData(query);
                UpdateDoner_Load(this, null);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Fill all fields please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void UpdateDoner_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
