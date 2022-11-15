namespace CustomerOrderProduct.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string? Title { get; set; }
		public string? Manufacturer { get; set; }
		public DateTime? ProductionDate { get; set; }
		public DateTime? ReturnDate { get; set; }
		public virtual ICollection<Order>? Orders { get; set; }
	}
}
