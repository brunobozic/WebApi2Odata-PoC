using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Summary of Sales by Quarter")]
	public class Summary_of_Sales_by_Quarter
	{
		public DateTime? ShippedDate { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int OrderID { get; set; }

		[Column(TypeName = "money")]
		public decimal? Subtotal { get; set; }
	}
}