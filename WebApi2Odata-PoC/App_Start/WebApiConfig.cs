using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using WebApi2OdataPoC.Repository.EF;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
namespace WebApi2Odata_PoC
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			// Configure Web API to use only bearer token authentication.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			// Web API routes
			config.MapHttpAttributeRoutes();
			ODataModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<Products>("Products");
			config.MapODataServiceRoute(
				routeName: "ODataRoute",
				routePrefix: "OData",
				model: builder.GetEdmModel());
			config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
				);
		}
	}
}