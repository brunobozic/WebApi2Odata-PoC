using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Current Product List")]
	public class Current_Product_List
	{
		[Key]
		[Column(Order = 0)]
		public int ProductID { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(40)]
		public string ProductName { get; set; }
	}
}