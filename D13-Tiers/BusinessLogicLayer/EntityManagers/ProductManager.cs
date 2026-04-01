using BusinessLogicLayer.Entities;
using BusinessLogicLayer.EntityLists;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EntityManagers
{
    public class ProductManager
    {
		static DBManager dbManager= new DBManager();
        public static ProductList SelectAllProducts()
        {
			try
			{
				return DataTableToProductList(
				dbManager.ExecuteDataTable("SelectAllProducts"));
			}
			catch 
			{

				
			}
			return new ProductList();
        }

        public static bool DeleteProductByID(int ProductID)
        {
            try
            {
				Dictionary<string, Object> ParamList = new Dictionary<string, object>()
				{
					["ProductID"] = ProductID
				};
				if (dbManager.ExecuteNonQuery("DeleteProductByID") > 0)
					return true;

            }
            catch
            {
            }
			return false;
        }

        #region Mapping Function
        internal static ProductList DataTableToProductList(DataTable Dt)
		{
			ProductList prdlst= new ProductList();
			try
			{
				if(Dt?.Rows.Count > 0)
				{
					foreach (DataRow Dr in Dt.Rows)
					{
						prdlst.Add(DataRowToProduct(Dr));
					}
				}
			}
			catch
			{

			}
			return prdlst;

		}

        internal static Product DataRowToProduct(DataRow Dr)
        {
			int TempInt;
			short TempShort;
			Product prd = new Product();
			try
			{
				prd.ProductID = Dr.Field<int>("ProductID"); // for non nullable attribute(strong)

                prd.ProductName = Dr["ProductName"]?.ToString() ?? "NA";


                if (int.TryParse(Dr["CategoryID"]?.ToString()??"0", out TempInt))
					prd.CategoryID = TempInt;


				if (bool.TryParse(Dr["Discontinued"]?.ToString()??"False",out bool TempBool))
					prd.Discontinued= TempBool;


                prd.QuantityPerUnit = Dr["QuantityPerUnit"]?.ToString() ?? "NA";


                if (int.TryParse(Dr["SupplierID"]?.ToString() ?? "0", out TempInt))
                    prd.SupplierID = TempInt;

                if (decimal.TryParse(Dr["SupplierID"]?.ToString() ?? "0", out decimal TempDec))
                    prd.UnitPrice = TempDec;

                if (short.TryParse(Dr["ReorderLevel"]?.ToString() ?? "0", out TempShort))
                    prd.ReorderLevel = TempShort;

                if (short.TryParse(Dr["UnitsInStock"]?.ToString() ?? "0", out TempShort))
                    prd.UnitsInStock = TempShort;

                if (short.TryParse(Dr["UnitsOnOrder"]?.ToString() ?? "0", out TempShort))
                    prd.UnitsOnOrder = TempShort;

				prd.State = EntityState.UnChanged;
            }
            catch (Exception)
			{

				throw;
			}

            return prd;
        }

        #endregion
    }
}
