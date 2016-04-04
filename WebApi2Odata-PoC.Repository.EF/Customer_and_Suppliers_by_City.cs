using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Customer and Suppliers by City")]
	public class Customer_and_Suppliers_by_City
	{
		[StringLength(15)]
		public string City { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(40)]
		public string CompanyName { get; set; }

		[StringLength(30)]
		public string ContactName { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Relationship { get; set; }
	}
}