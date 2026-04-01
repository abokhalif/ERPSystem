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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you want to log out ? ", "Log out", MessageBoxButtons.OK, MessageBoxIcon.Question);
            this.Close();
            //
            //this.Hide();
        }

        private void addNewDonerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HosForm hf = new HosForm();
            hf.Show();
            //this.Close();
        }

        private void updateDonerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDoner ud = new UpdateDoner();
            ud.Show();
            //this.Close();
        }

        private void allDonerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllDoner ad = new AllDoner();
            ad.Show();
            //this.Close();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Location l = new Location();
            l.Show();
            //this.Close();
        }

        private void bloodGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeBlood bg = new TypeBlood();
            bg.Show();
           // this.Close();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock s = new Stock();
            s.Show();
            //this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDoner dd = new DeleteDoner();
            dd.Show();
            //this.Close();
        }

        /* private void Dashboard_Load(object sender, EventArgs e)
         {
              Add_New_Doner and = new Add_New_Doner();
             and.Close();
         }*/
    }
}
