﻿using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using AttributeRouting.Web.Http;
using WebApi2Odata_PoC.Filters;
using WebApi2Odata_PoC.Services;

namespace WebApi2Odata_PoC.Controllers
{
	[ApiAuthenticationFilter]
	public class AuthenticateController : ApiController
	{
		#region Private variable.

		private readonly ITokenServices _tokenServices;
		private readonly IUserServices _userServices;

		#endregion

		#region Public Constructor

		/// <summary>
		/// Public constructor to initialize product service instance
		/// </summary>
		public AuthenticateController(ITokenServices tokenServices, IUserServices userServices)
		{
			_tokenServices = tokenServices;
			_userServices = userServices;
		}

		#endregion

		/// <summary>
		/// Authenticates user and returns token with expiry.
		/// </summary>
		/// <returns></returns>
		[POST("login")]
		[POST("authenticate")]
		[POST("get/token")]
		public HttpResponseMessage Authenticate()
		{
			if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
			{
				var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
				if (basicAuthenticationIdentity != null)
				{
					var userId = basicAuthenticationIdentity.UserId;
					return GetAuthToken(userId);
				}
			}
			return null;
		}

		/// <summary>
		/// Returns auth token for the validated user.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		private HttpResponseMessage GetAuthToken(int userId)
		{
			var token = _tokenServices.GenerateToken(userId);
			var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
			response.Headers.Add("Token", token.AuthToken);
			response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
			response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
			return response;
		}
	}
}
