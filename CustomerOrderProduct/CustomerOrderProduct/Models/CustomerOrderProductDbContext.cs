using Microsoft.EntityFrameworkCore;

namespace CustomerOrderProduct.Models
{
	public class CustomerOrderProductDbContext : DbContext
	{
		public CustomerOrderProductDbContext(DbContextOptions<CustomerOrderProductDbContext> options)
				: base(options)
		{

		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Product { get; set; }
	}
}
