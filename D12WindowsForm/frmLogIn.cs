using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D12WindowsForm
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
            this.btnOk.Click += BtnOk_Click;
            frm1 = new Form1();// create only one object of the Form1 Cause it in the Constractor
            this.btnCancel.Click += (sender, e) => this.Close();
        }
        Form1 frm1;
        private void BtnOk_Click(object? sender, EventArgs e)
        {
            //frm1 = new Form1();// create anew object of the Form1 every click on the Ok buuton
            if (this.txtUsername.Text == "" && this.txtPassword.Text == "")
            {
                // 1-
                //frm1.Show(); // can access the parent form and it complete the runtime 
                //this.Text = "OK";// show during clicking on the button
                //2-
                this.Hide();
                frm1.ShowDialog();//can not access the parent form and runtime(control) stop in the parent until the child form is closed
                //this.Text= "OK";// show after closing the 
                //this.Close();// when close the startup form all the program is closed
                //this.Visible= true;
                this.Show();
            }
        }
        // FormClosing event
        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (
            MessageBox.Show("Are You sure exit (Yes or No)", "Warnning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            == DialogResult.No
                )
                e.Cancel = true;

        }
    }
}
