using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApi2OdataPoC.Repository.EF
{
	[Table("User")]
	public class User
	{
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public User()
		{
			Tokens = new HashSet<Tokens>();
		}

		public int UserId { get; set; }

		[Required]
		[StringLength(50)]
		public string UserName { get; set; }

		[Required]
		[StringLength(50)]
		public string Password { get; set; }

		[StringLength(50)]
		public string Name { get; set; }

		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Tokens> Tokens { get; set; }
	}
}