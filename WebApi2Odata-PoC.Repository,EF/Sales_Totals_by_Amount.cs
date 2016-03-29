using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Sales Totals by Amount")]
	public class Sales_Totals_by_Amount
	{
		[Column(TypeName = "money")]
		public decimal? SaleAmount { get; set; }

		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int OrderID { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(40)]
		public string CompanyName { get; set; }

		public DateTime? ShippedDate { get; set; }
	}
}