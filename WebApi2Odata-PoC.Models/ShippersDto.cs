using System.Collections.Generic;

namespace WebApi2Odata_PoC.Models
{
	public class ShippersDto
	{
		public ShippersDto()
		{
			Orders = new List<OrdersDto>();
		}


		public int ShipperID { get; set; }


		public string CompanyName { get; set; }


		public string Phone { get; set; }


		public virtual List<OrdersDto> Orders { get; set; }
	}
}