using System.Collections.Generic;

namespace WebApi2Odata_PoC.Models
{
	public class RegionDto
	{
		public RegionDto()
		{
			Territories = new List<TerritoriesDto>();
		}


		public int RegionID { get; set; }


		public string RegionDescription { get; set; }


		public virtual List<TerritoriesDto> Territories { get; set; }
	}
}