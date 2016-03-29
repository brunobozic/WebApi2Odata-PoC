using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Order Subtotals")]
	public class Order_Subtotals
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int OrderID { get; set; }

		[Column(TypeName = "money")]
		public decimal? Subtotal { get; set; }
	}
}