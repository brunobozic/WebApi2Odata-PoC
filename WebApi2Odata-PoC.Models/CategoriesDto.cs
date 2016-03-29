using System.Collections.Generic;

namespace WebApi2Odata_PoC.Models
{
	public class CategoriesDto
	{
		public CategoriesDto()
		{
			Products = new List<ProductsDto>();
		}


		public int CategoryID { get; set; }


		public string CategoryName { get; set; }


		public string Description { get; set; }


		public byte[] Picture { get; set; }

		public virtual List<ProductsDto> Products { get; set; }
	}
}