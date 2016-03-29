namespace WebApi2Odata_PoC.Models
{
	public class Order_DetailsDto
	{
		public int OrderID { get; set; }


		public int ProductID { get; set; }


		public decimal UnitPrice { get; set; }

		public short Quantity { get; set; }

		public float Discount { get; set; }

		public virtual OrdersDto Orders { get; set; }

		public virtual ProductsDto Products { get; set; }
	}
}