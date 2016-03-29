﻿using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using WebApi2Odata_PoC.Models;
using WebApi2Odata_PoC.Repository.EF;
using WebApi2Odata_PoC.Repository.EF.UnitOfWork;
using WebApi2Odata_PoC.Repository.EF.UnitOfWork.DataModel.UnitOfWork;

namespace WebApi2Odata_PoC.Services
{
	public class ProductServices : IProductServices
	{
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		///     Public constructor.
		/// </summary>
		public ProductServices()
		{
			_unitOfWork = new UnitOfWork();
		}

		/// <summary>
		///     Fetches product details by id
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		/// <summary>
		///     Fetches product details by id
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		public ProductsDto GetProductById(int productId)
		{
			var product = _unitOfWork.ProductRepository.GetByID(productId);
			if (product != null)
			{
				Mapper.CreateMap<Products, ProductsDto>();
				var productModel = Mapper.Map<Products, ProductsDto>(product);
				return productModel;
			}
			return null;
		}

		/// <summary>
		///     Fetches all the products.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<ProductsDto> GetAllProducts()
		{
			var products = _unitOfWork.ProductRepository.GetAll().ToList();
			if (products.Any())
			{
				Mapper.CreateMap<Products, ProductsDto>();
				var productsModel = Mapper.Map<List<Products>, List<ProductsDto>>(products);
				return productsModel;
			}
			return null;
		}

		/// <summary>
		///     Creates a product
		/// </summary>
		/// <param name="productEntity"></param>
		/// <returns></returns>
		public int CreateProduct(ProductsDto productEntity)
		{
			using (var scope = new TransactionScope())
			{
				var product = new Products
				{
					ProductName = productEntity.ProductName
				};
				_unitOfWork.ProductRepository.Insert(product);
				_unitOfWork.Save();
				scope.Complete();
				return product.ProductID;
			}
		}

		/// <summary>
		///     Updates a product
		/// </summary>
		/// <param name="productId"></param>
		/// <param name="productEntity"></param>
		/// <returns></returns>
		public bool UpdateProduct(int productId, ProductsDto productEntity)
		{
			var success = false;
			if (productEntity != null)
			{
				using (var scope = new TransactionScope())
				{
					var product = _unitOfWork.ProductRepository.GetByID(productId);
					if (product != null)
					{
						product.ProductName = productEntity.ProductName;
						_unitOfWork.ProductRepository.Update(product);
						_unitOfWork.Save();
						scope.Complete();
						success = true;
					}
				}
			}
			return success;
		}

		/// <summary>
		///     Deletes a particular product
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		public bool DeleteProduct(int productId)
		{
			var success = false;
			if (productId > 0)
			{
				using (var scope = new TransactionScope())
				{
					var product = _unitOfWork.ProductRepository.GetByID(productId);
					if (product != null)
					{
						_unitOfWork.ProductRepository.Delete(product);
						_unitOfWork.Save();
						scope.Complete();
						success = true;
					}
				}
			}
			return success;
		}
	}
}