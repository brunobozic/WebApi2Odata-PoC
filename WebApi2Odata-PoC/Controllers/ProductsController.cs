using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using AttributeRouting.Web.Http;
using WebApi2OdataPoC.Repository.EF;
using WebApi2Odata_PoC.Models;
using WebApi2Odata_PoC.Services;

namespace WebApi2Odata_PoC.Controllers
{
	public class ProductsController : ODataController
	{
		private readonly Northwind db = new Northwind();

		private bool ProductExists(int key)
		{
			return db.Products.Any(p => p.ProductID == key);
		}


		[EnableQuery]
		public IQueryable<Products> Get()
		{
			return db.Products;
		}

		[EnableQuery]
		public SingleResult<Products> Get([FromODataUri] int key)
		{
			var result = db.Products.Where(p => p.ProductID == key);
			return SingleResult.Create(result);
		}

		public async Task<IHttpActionResult> Post(Products product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			db.Products.Add(product);
			await db.SaveChangesAsync();
			return Created(product);
		}

		public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Products> product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var entity = await db.Products.FindAsync(key);
			if (entity == null)
			{
				return NotFound();
			}
			product.Patch(entity);
			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(key))
				{
					return NotFound();
				}
				throw;
			}
			return Updated(entity);
		}

		public async Task<IHttpActionResult> Put([FromODataUri] int key, Products update)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (key != update.ProductID)
			{
				return BadRequest();
			}
			db.Entry(update).State = EntityState.Modified;
			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(key))
				{
					return NotFound();
				}
				throw;
			}
			return Updated(update);
		}

		public async Task<IHttpActionResult> Delete([FromODataUri] int key)
		{
			var product = await db.Products.FindAsync(key);
			if (product == null)
			{
				return NotFound();
			}
			db.Products.Remove(product);
			await db.SaveChangesAsync();
			return StatusCode(HttpStatusCode.NoContent);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}

	//public class ProductsController : ApiController
	//{
	//	private readonly IProductServices _productServices;

	//	#region Public Constructor  

	//	/// <summary>
	//	///     Public constructor to initialize product service instance
	//	/// </summary>
	//	public ProductsController()
	//	{
	//		_productServices = new ProductServices();
	//	}

	//	#endregion

	//	// GET api/product  
	//	[GET("allproducts")]
	//	[GET("all")]
	//	public HttpResponseMessage Get()
	//	{
	//		var products = _productServices.GetAllProducts();
	//		if (products != null)
	//		{
	//			var productEntities = products as List<ProductsDto> ?? products.ToList();
	//			if (productEntities.Any())
	//				return Request.CreateResponse(HttpStatusCode.OK, productEntities);
	//		}
	//		return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
	//	}

	//	// GET api/product/5 
	//	[GET("productid/{id?}")]
	//	[GET("particularproduct/{id?}")]
	//	[GET("myproduct/{id:range(1, 3)}")]
	//	public HttpResponseMessage Get(int id)
	//	{
	//		var product = _productServices.GetProductById(id);
	//		if (product != null)
	//			return Request.CreateResponse(HttpStatusCode.OK, product);
	//		return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
	//	}

	//	// POST api/product  
	//	[POST("Create")]
	//	[POST("Register")]
	//	public int Post([FromBody] ProductsDto productEntity)
	//	{
	//		return _productServices.CreateProduct(productEntity);
	//	}

	//	// PUT api/product/5  
	//	[PUT("Update/productid/{id}")]
	//	[PUT("Modify/productid/{id}")]
	//	public bool Put(int id, [FromBody] ProductsDto productEntity)
	//	{
	//		if (id > 0)
	//		{
	//			return _productServices.UpdateProduct(id, productEntity);
	//		}
	//		return false;
	//	}

	//	// DELETE api/product/5  
	//	public bool Delete(int id)
	//	{
	//		if (id > 0)
	//			return _productServices.DeleteProduct(id);
	//		return false;
	//	}
	//}
}