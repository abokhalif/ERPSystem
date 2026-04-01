using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class1;
namespace Blood_banck
{
    internal static class Program
    {




        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());
           Application.Run(new Dashboard());
            //Application.Run(new Add_New_Doner());
           
            

        }
    }
}
