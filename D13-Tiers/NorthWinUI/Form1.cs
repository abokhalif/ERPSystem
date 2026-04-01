using BusinessLogicLayer.EntityLists;
using BusinessLogicLayer.EntityManagers;
using System.Diagnostics;

namespace NorthWinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.toolStripMenuDown.Click += (sen, e) =>
            {
                CurrentPage = CurrentPage > 0 ? CurrentPage - 1 : 0;
                Display();
            };
        }
        ProductList prds;
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
             prds = ProductManager.SelectAllProducts();

            //var prds = (from p in ProductManager.SelectAllProducts()
            //            where p.UnitsInStock > 0
            //            select p)
            //            .Take(10)
            //            .ToList();
            this.dataGridView1.DataSource = prds;
            
        }
        int CurrentPage=0;
        public void Display()=>
            this.dataGridView1.DataSource= prds.Skip(CurrentPage*10).Take(10).ToList();
        int PageNum => (prds.Count / 10) + 1;
        private void toolStripMenuUp_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            if (CurrentPage >= PageNum) CurrentPage = 0;

            Display();  
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ProductManager.DeleteProductByID(1); // Donot Deleted ; the FK

            foreach (var item in prds)
            {
                Debug.WriteLine($"{item.ProductID} {item.State}");
            }
        }
    }
}