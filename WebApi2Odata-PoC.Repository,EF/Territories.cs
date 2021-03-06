using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApi2OdataPoC.Repository.EF
{
	public class Territories
	{
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Territories()
		{
			Employees = new HashSet<Employees>();
		}

		[Key]
		[StringLength(20)]
		public string TerritoryID { get; set; }

		[Required]
		[StringLength(50)]
		public string TerritoryDescription { get; set; }

		public int RegionID { get; set; }

		public virtual Region Region { get; set; }

		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Employees> Employees { get; set; }
	}
}