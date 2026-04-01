using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Class1;

namespace Blood_banck
{
   
    public partial class Add_New_Doner : Form
    {
        Class1.datacon dc = new datacon();
       

       

        public Add_New_Doner()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      /*  private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
      */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" &&
                    textBox6.Text != "" && textBox7.Text != "" && textBox9.Text != "" &&
                    comboBox1.Text != "" && comboBox2.Text != "" && textBox8.Text != "")
                {
                   
                    String query3 = "insert into NewDoner ( DOner_id,fname,lname,mobile,email,gender,typeblood,addr,DRid,NoOfBags,age)" +
                        "values ('" +Int32.Parse( textBox1.Text) + "','" + textBox2.Text + "' ,'" + textBox3.Text + "' ,'" + textBox4.Text + "','" + textBox5.Text + "' " +
                        ",'" + comboBox1.Text + "'  ,'" + comboBox2.Text + "','" + textBox7.Text + "' ,'" + textBox8.Text + "' ,'" + Int32.Parse(textBox6.Text) + "','" + Int32.Parse(textBox9.Text) + "' )";
                    
                    dc.setData(query3);

                }
                else
                {
                    MessageBox.Show("Fill all fields please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Fill all fields please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text!="" || textBox3.Text != "" || textBox4.Text != ""
               || textBox5.Text != "" || textBox6.Text != "" || textBox7.Text != ""
                || textBox8.Text != "" || textBox9.Text != "")
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                comboBox1.ResetText();
                comboBox2.ResetText();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
        }
    }

    
}
