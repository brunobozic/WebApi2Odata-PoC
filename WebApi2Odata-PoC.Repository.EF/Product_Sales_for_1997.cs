using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Product Sales for 1997")]
	public class Product_Sales_for_1997
	{
		[Key]
		[Column(Order = 0)]
		[StringLength(15)]
		public string CategoryName { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(40)]
		public string ProductName { get; set; }

		[Column(TypeName = "money")]
		public decimal? ProductSales { get; set; }
	}
}