﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2Odata_PoC.Models
{
	public class UserDto
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
	}
}