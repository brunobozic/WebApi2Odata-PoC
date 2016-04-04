using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi2OdataPoC.Repository.EF
{
	public class Tokens
	{
		[Key]
		public int TokenId { get; set; }

		public int UserId { get; set; }

		[Required]
		[StringLength(250)]
		public string AuthToken { get; set; }

		public DateTime IssuedOn { get; set; }

		public DateTime ExpiresOn { get; set; }

		public virtual User User { get; set; }
	}
}