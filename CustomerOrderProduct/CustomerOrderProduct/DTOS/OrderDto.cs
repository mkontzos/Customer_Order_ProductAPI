using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.DTOS
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? CanceledDate { get; set; }
		public DateTime? DeliveredDate { get; set; }

		public Guid CustomerId { get; set; }
		public Customer? Customer { get; set; }

		public ICollection<Product>? Products { get; set; }
	}
}
