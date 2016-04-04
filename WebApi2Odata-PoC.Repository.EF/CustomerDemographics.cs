using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApi2OdataPoC.Repository.EF
{
	public class CustomerDemographics
	{
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public CustomerDemographics()
		{
			Customers = new HashSet<Customers>();
		}

		[Key]
		[StringLength(10)]
		public string CustomerTypeID { get; set; }

		[Column(TypeName = "ntext")]
		public string CustomerDesc { get; set; }

		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Customers> Customers { get; set; }
	}
}