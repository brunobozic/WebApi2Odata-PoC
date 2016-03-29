using System.Collections.Generic;
using WebApi2Odata_PoC.Models;

namespace WebApi2Odata_PoC.Services
{
	public interface IProductServices
	{
		ProductsDto GetProductById(int productId);
		IEnumerable<ProductsDto> GetAllProducts();
		int CreateProduct(ProductsDto productEntity);
		bool UpdateProduct(int productId, ProductsDto productEntity);
		bool DeleteProduct(int productId);
	}
}