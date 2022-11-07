namespace CustomerOrderProduct.Models
{
	public class Order
	{
		public Guid Id { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? CanceledDate { get; set; }
		public DateTime? DeliveredDate { get; set; }
		
		public Guid CustomerId { get; set; }
		public Customer? Customer { get; set; }

		public virtual ICollection<Product>? Products { get; set; }
	}
}
