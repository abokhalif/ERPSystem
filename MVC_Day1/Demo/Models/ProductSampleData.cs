namespace Demo.Models
{
	public class ProductSampleData
	{
		List<Product> products;
		public ProductSampleData()
		{
			products = new List<Product>();
			products.Add(new Product { Id = 1, Name = "Phone1", Description = "the 1 mobile", Price = 2000, Image = "1.jpeg" });
			products.Add(new Product { Id = 2, Name = "Phone2", Description = "the 2 mobile", Price = 3000, Image = "2.jpg" });
			products.Add(new Product { Id = 3, Name = "Phone3", Description = "the 3 mobile", Price = 4000, Image = "3.jpeg" });
			products.Add(new Product { Id = 4, Name = "Phone4", Description = "the 4 mobile", Price = 5000, Image = "4.jpeg" });
			products.Add(new Product { Id = 5, Name = "Phone5", Description = "the 5 mobile", Price = 2500, Image = "5.jpeg" });
		}
		public List<Product> GetAll() => products;
		public Product GetById(int id) => products.FirstOrDefault(p=>p.Id==id);
		
	}
}
