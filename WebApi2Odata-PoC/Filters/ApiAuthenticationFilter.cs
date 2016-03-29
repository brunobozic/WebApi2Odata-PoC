﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using WebApi2Odata_PoC.Services;

namespace WebApi2Odata_PoC.Filters
{
	public class ApiAuthenticationFilter : GenericBasicAuthenticationFilter
	{
		/// <summary>
		/// Default Authentication Constructor
		/// </summary>
		public ApiAuthenticationFilter()
		{
		}

		/// <summary>
		/// AuthenticationFilter constructor with isActive parameter
		/// </summary>
		/// <param name="isActive"></param>
		public ApiAuthenticationFilter(bool isActive)
			: base(isActive)
		{
		}

		/// <summary>
		/// Protected overriden method for authorizing user
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="actionContext"></param>
		/// <returns></returns>
		protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
		{
			var provider = actionContext.ControllerContext.Configuration
							   .DependencyResolver.GetService(typeof(IUserServices)) as IUserServices;
			if (provider != null)
			{
				var userId = provider.Authenticate(username, password);
				if (userId > 0)
				{
					var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
					if (basicAuthenticationIdentity != null)
						basicAuthenticationIdentity.UserId = userId;
					return true;
				}
			}
			return false;
		}
	}
}