using System.Collections.Generic;

namespace WebApi2Odata_PoC.Models
{
	public class CustomersDto
	{
		public CustomersDto()
		{
			Orders = new List<OrdersDto>();
			CustomerDemographics = new List<CustomerDemographicsDto>();
		}


		public string CustomerID { get; set; }


		public string CompanyName { get; set; }


		public string ContactName { get; set; }


		public string ContactTitle { get; set; }


		public string Address { get; set; }

		public string City { get; set; }


		public string Region { get; set; }


		public string PostalCode { get; set; }


		public string Country { get; set; }


		public string Phone { get; set; }


		public string Fax { get; set; }


		public virtual List<OrdersDto> Orders { get; set; }

		public virtual List<CustomerDemographicsDto> CustomerDemographics { get; set; }
	}
}