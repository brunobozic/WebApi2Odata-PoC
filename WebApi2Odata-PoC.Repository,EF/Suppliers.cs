using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApi2OdataPoC.Repository.EF
{
	public class Suppliers
	{
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Suppliers()
		{
			Products = new HashSet<Products>();
		}

		[Key]
		public int SupplierID { get; set; }

		[Required]
		[StringLength(40)]
		public string CompanyName { get; set; }

		[StringLength(30)]
		public string ContactName { get; set; }

		[StringLength(30)]
		public string ContactTitle { get; set; }

		[StringLength(60)]
		public string Address { get; set; }

		[StringLength(15)]
		public string City { get; set; }

		[StringLength(15)]
		public string Region { get; set; }

		[StringLength(10)]
		public string PostalCode { get; set; }

		[StringLength(15)]
		public string Country { get; set; }

		[StringLength(24)]
		public string Phone { get; set; }

		[StringLength(24)]
		public string Fax { get; set; }

		[Column(TypeName = "ntext")]
		public string HomePage { get; set; }

		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Products> Products { get; set; }
	}
}