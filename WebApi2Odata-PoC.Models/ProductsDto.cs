using System.Collections.Generic;

namespace WebApi2Odata_PoC.Models
{
	public class ProductsDto
	{
		public ProductsDto()
		{
			Order_Details = new List<Order_DetailsDto>();
		}


		public int ProductID { get; set; }


		public string ProductName { get; set; }

		public int? SupplierID { get; set; }

		public int? CategoryID { get; set; }


		public string QuantityPerUnit { get; set; }


		public decimal? UnitPrice { get; set; }

		public short? UnitsInStock { get; set; }

		public short? UnitsOnOrder { get; set; }

		public short? ReorderLevel { get; set; }

		public bool Discontinued { get; set; }

		public virtual CategoriesDto Categories { get; set; }


		public virtual List<Order_DetailsDto> Order_Details { get; set; }

		public virtual SuppliersDto Suppliers { get; set; }
		public int ProductId { get; set; }
	}
}