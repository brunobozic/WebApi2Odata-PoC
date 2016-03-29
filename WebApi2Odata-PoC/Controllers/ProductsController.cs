using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2Odata_PoC.Models;
using WebApi2Odata_PoC.Services;
using AttributeRouting;
using AttributeRouting.Web.Http;
namespace WebApi2Odata_PoC.Controllers
{
    public class ProductsController : ApiController
	{



		private readonly IProductServices _productServices;

		#region Public Constructor  

		/// <summary>  
		/// Public constructor to initialize product service instance  
		/// </summary>  
		public ProductsController()
		{
			_productServices = new ProductServices();
		}

		#endregion

		// GET api/product  
		[GET("allproducts")]
		[GET("all")]
		public HttpResponseMessage Get()
		{
			var products = _productServices.GetAllProducts();
			if (products != null)
			{
				var productEntities = products as List<ProductsDto> ?? products.ToList();
				if (productEntities.Any())
					return Request.CreateResponse(HttpStatusCode.OK, productEntities);
			}
			return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
		}

		// GET api/product/5 
		[GET("productid/{id?}")]
		[GET("particularproduct/{id?}")]
		[GET("myproduct/{id:range(1, 3)}")]
		public HttpResponseMessage Get(int id)
		{
			var product = _productServices.GetProductById(id);
			if (product != null)
				return Request.CreateResponse(HttpStatusCode.OK, product);
			return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
		}

		// POST api/product  
		[POST("Create")]
		[POST("Register")]
		public int Post([FromBody] ProductsDto productEntity)
		{
			return _productServices.CreateProduct(productEntity);
		}

		// PUT api/product/5  
		[PUT("Update/productid/{id}")]
		[PUT("Modify/productid/{id}")]
		public bool Put(int id, [FromBody]ProductsDto productEntity)
		{
			if (id > 0)
			{
				return _productServices.UpdateProduct(id, productEntity);
			}
			return false;
		}

		// DELETE api/product/5  
		public bool Delete(int id)
		{
			if (id > 0)
				return _productServices.DeleteProduct(id);
			return false;
		}
	}
}
