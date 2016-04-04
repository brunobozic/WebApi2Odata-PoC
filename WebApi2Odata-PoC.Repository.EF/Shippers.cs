using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApi2OdataPoC.Repository.EF
{
	public class Shippers
	{
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Shippers()
		{
			Orders = new HashSet<Orders>();
		}

		[Key]
		public int ShipperID { get; set; }

		[Required]
		[StringLength(40)]
		public string CompanyName { get; set; }

		[StringLength(24)]
		public string Phone { get; set; }

		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Orders> Orders { get; set; }
	}
}