using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Products Above Average Price")]
	public class Products_Above_Average_Price
	{
		[Key]
		[StringLength(40)]
		public string ProductName { get; set; }

		[Column(TypeName = "money")]
		public decimal? UnitPrice { get; set; }
	}
}