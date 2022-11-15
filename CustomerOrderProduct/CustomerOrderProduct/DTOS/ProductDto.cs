using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.DTOS
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public string? Title { get; set; }
		public string? Manufacturer { get; set; }
		public DateTime? ProductionDate { get; set; }
		public DateTime? ReturnDate { get; set; }

		public ICollection<Order>? Orders { get; set; }
	}
}
