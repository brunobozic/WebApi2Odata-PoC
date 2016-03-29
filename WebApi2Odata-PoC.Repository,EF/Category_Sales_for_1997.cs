using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Category Sales for 1997")]
	public class Category_Sales_for_1997
	{
		[Key]
		[StringLength(15)]
		public string CategoryName { get; set; }

		[Column(TypeName = "money")]
		public decimal? CategorySales { get; set; }
	}
}