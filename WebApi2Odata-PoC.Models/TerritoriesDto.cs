using System.Collections.Generic;

namespace WebApi2Odata_PoC.Models
{
	public class TerritoriesDto
	{
		public TerritoriesDto()
		{
			Employees = new List<EmployeesDto>();
		}


		public string TerritoryID { get; set; }


		public string TerritoryDescription { get; set; }

		public int RegionID { get; set; }

		public virtual RegionDto Region { get; set; }


		public virtual List<EmployeesDto> Employees { get; set; }
	}
}