Imports System.Web.Http
Imports AttributeRouting.Web.Http.WebHost

<assembly: WebActivator.PreApplicationStartMethod(GetType(WebApi2Odata_PoC.AttributeRoutingHttpConfig), "Start")>

Namespace WebApi2Odata_PoC
    Public Class AttributeRoutingHttpConfig
		Public Shared Sub RegisterRoutes(routes As HttpRouteCollection)
            
			' See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			' To debug routes locally using the built in ASP.NET development server, go to /routes.axd
            
            routes.MapHttpAttributeRoutes()
		End Sub

        Public Shared Sub Start()
            RegisterRoutes(GlobalConfiguration.Configuration.Routes)
        End Sub
    End Class
End Namespace
