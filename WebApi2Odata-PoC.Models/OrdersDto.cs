using System;
using System.Collections.Generic;

namespace WebApi2Odata_PoC.Models
{
	public class OrdersDto
	{
		public OrdersDto()
		{
			Order_Details = new List<Order_DetailsDto>();
		}


		public int OrderID { get; set; }


		public string CustomerID { get; set; }

		public int? EmployeeID { get; set; }

		public DateTime? OrderDate { get; set; }

		public DateTime? RequiredDate { get; set; }

		public DateTime? ShippedDate { get; set; }

		public int? ShipVia { get; set; }


		public decimal? Freight { get; set; }


		public string ShipName { get; set; }


		public string ShipAddress { get; set; }


		public string ShipCity { get; set; }


		public string ShipRegion { get; set; }


		public string ShipPostalCode { get; set; }


		public string ShipCountry { get; set; }

		public virtual CustomersDto Customers { get; set; }

		public virtual EmployeesDto Employees { get; set; }


		public virtual List<Order_DetailsDto> Order_Details { get; set; }

		public virtual ShippersDto Shippers { get; set; }
	}
}