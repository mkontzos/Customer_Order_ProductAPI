using CustomerOrderProduct.Models;

namespace CustomerOrderProduct.DTOS
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		public string? Email { get; set; }
		public string? Gender { get; set; }
		public string? Address { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? CreatedDate { get; set; }

		public ICollection<Order>? Orders { get; set; }
	}
}
