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
    public partial class frmRtfNotePad : Form
    {
        public frmRtfNotePad()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //if(dlgOpen.ShowDialog()==DialogResult.OK)
            //    txtUserText.LoadFile(dlgOpen.FileName);//RichTextBoxStreamType.RichText//the default, but it can not open any files else .rtf
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                switch (dlgOpen.FilterIndex)
                {
                    case 1: 
                        txtUserText.LoadFile(dlgOpen.FileName,RichTextBoxStreamType.RichText);
                        break;
                    case 2:
                        txtUserText.LoadFile(dlgOpen.FileName, RichTextBoxStreamType.PlainText);
                        break;
                }
            }
        }

        private void frmRtfNotePad_Load(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Rich Text files|*.rtf|Text files|*.txt";
            dlgSave.Filter = "Rich Text files|*.rtf|Text files|*.txt";

            btnExit.Click += (S, E) => this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dlgSave.ShowDialog() == DialogResult.OK)
            {
                txtUserText.SaveFile(dlgSave.FileName,((RichTextBoxStreamType)dlgSave.FilterIndex-1));
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (txtUserText.SelectedText?.Length > 0)
                dlgFont.Font = txtUserText.SelectionFont;
            if(dlgFont.ShowDialog()==DialogResult.OK)
            {
                txtUserText.SelectionFont=dlgFont.Font;
            }
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (txtUserText.SelectedText?.Length > 0)
                dlgColor.Color = txtUserText.SelectionColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                txtUserText.SelectionColor = dlgColor.Color;
            }
        }
        frmCustDlg frmCust = new frmCustDlg();
        private void btnMyDlg_Click(object sender, EventArgs e)
        {
            frmCust.UserMessage = "Type Your Message";
            if (frmCust.ShowDialog() == DialogResult.OK)
                txtUserText.AppendText(frmCust.UserMessage);// frmCust.txtUserMessage =>this attribute is private so we must make a public property to can access the attribute
        }
    }
}
