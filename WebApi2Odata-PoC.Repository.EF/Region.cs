using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("Region")]
	public class Region
	{
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Region()
		{
			Territories = new HashSet<Territories>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RegionID { get; set; }

		[Required]
		[StringLength(50)]
		public string RegionDescription { get; set; }

		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Territories> Territories { get; set; }
	}
}