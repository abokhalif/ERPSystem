using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Product:EntityBase
    {
        
        public int ProductID { get; set; }
        //public string ProductName { get; set; } // the old shape 
        // this is the new shape to control the state 
        string productName;
        public string ProductName { 
            get=> productName;
            set
            {
                if (productName != value)
                {
                    productName = value;
                    this.State = EntityState.Modified;
                }
                else if(productName == null) { productName = value; }
            }
        }

        public Nullable<int> SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set;}
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }




    }
}
