using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using WebApi2Odata_PoC.Repository.EF.GenericRepository.DataModel.GenericRepository;

namespace WebApi2Odata_PoC.Repository.EF.UnitOfWork
{

	#region Using Namespaces...  

	#endregion

	namespace DataModel.UnitOfWork
	{
		/// <summary>
		///     Unit of Work class responsible for DB transactions
		/// </summary>
		public class UnitOfWork : IUnitOfWork
		{
			public UnitOfWork(GenericRepository<Shippers> shippersRepository)
			{
			//	_shippersRepository = shippersRepository;
				_context = new Northwind();
			}

			public UnitOfWork()
			{
			}

			#region Public member methods...  

			/// <summary>
			///     Save method.
			/// </summary>
			public void Save()
			{
				try
				{
					_context.SaveChanges();
				}
				catch (DbEntityValidationException e)
				{
					var outputLines = new List<string>();
					foreach (var eve in e.EntityValidationErrors)
					{
						outputLines.Add(string.Format(
							"{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
							eve.Entry.Entity.GetType().Name, eve.Entry.State));
						foreach (var ve in eve.ValidationErrors)
						{
							outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
						}
					}
					File.AppendAllLines(@"C:\errors.txt", outputLines);

					throw e;
				}
			}

			#endregion

			#region Private member variables...  

			private readonly Northwind _context;

			public GenericRepository<Categories> CategoriesRepository { get; set; }
			public GenericRepository<Contacts> ContactsRepository { get; set; }
			public GenericRepository<CustomerDemographics> CustomerDemographicsRepository { get; set; }
			public GenericRepository<Customers> CustomersRepository { get; set; }
			public GenericRepository<Employees> EmployeesRepository { get; set; }
			public GenericRepository<Order_Details> OrderDetailsRepository { get; set; }
			public GenericRepository<Orders> OrdersRepository { get; set; }
			public GenericRepository<Products> ProductsRepository { get; set; }
			public GenericRepository<Region> RegionRepository { get; set; }
		//	private GenericRepository<Shippers> ShippersRepository { get; set; }
			public GenericRepository<Suppliers> SuppliersRepository { get; set; }
			public GenericRepository<sysdiagrams> SysdiagramsRepository { get; set; }
			public GenericRepository<Territories> TerritoriesRepository { get; set; }
			public GenericRepository<Alphabetical_list_of_products> AlphabeticalListOfProductsRepository { get; set; }
			public GenericRepository<Category_Sales_for_1997> CategorySalesFor1997Repository { get; set; }
			public GenericRepository<Current_Product_List> CurrentProductListRepository { get; set; }
			public GenericRepository<Customer_and_Suppliers_by_City> CustomerAndSuppliersByCityRepository { get; set; }
			public GenericRepository<Invoices> InvoicesRepository { get; set; }
			public GenericRepository<Order_Details_Extended> OrderDetailsExtendedRepository { get; set; }
			public GenericRepository<Order_Subtotals> OrderSubtotalsRepository { get; set; }
			public GenericRepository<Orders_Qry> OrdersQryRepository { get; set; }
			public GenericRepository<Product_Sales_for_1997> ProductSalesFor1997Repository { get; set; }
			public GenericRepository<Products_Above_Average_Price> ProductsAboveAveragePriceRepository { get; set; }
			public GenericRepository<Products_by_Category> ProductsByCategoryRepository { get; set; }
			public GenericRepository<Sales_by_Category> SalesByCategoryRepository { get; set; }
			public GenericRepository<Sales_Totals_by_Amount> SalesTotalsByAmountRepository { get; set; }
			public GenericRepository<Summary_of_Sales_by_Quarter> SummaryOfSalesByQuarterRepository { get; set; }
			public GenericRepository<Summary_of_Sales_by_Year> SummaryOfSalesByYearRepository { get; set; }

			#endregion

			#region Public Repository Creation properties...  

			/// <summary>
			///     Get/Set Property for product repository.
			/// </summary>
			public GenericRepository<Products> ProductRepository
			{
				get
				{
					if (_productRepository == null)
						_productRepository = new GenericRepository<Products>(_context);
					return _productRepository;
				}
			}

			/// <summary>
			///     Get/Set Property for user repository.
			/// </summary>
			public GenericRepository<Customers> CustomerRepository
			{
				get
				{
					if (_customerRepository == null)
						_customerRepository = new GenericRepository<Customers>(_context);
					return _customerRepository;
				}
			}

			/// <summary>
			///     Get/Set Property for token repository.
			/// </summary>
			public GenericRepository<Shippers> ShippersRepository
			{
				get
				{
					if (_shippersnRepository == null)
						_shippersnRepository = new GenericRepository<Shippers>(_context);
					return _shippersnRepository;
				}
			}

			#endregion

			#region Implementing IDiosposable...  

			#region private dispose variable declaration...  

			private bool disposed;
			private GenericRepository<Products> _productRepository;
			private GenericRepository<Customers> _customerRepository;
			private GenericRepository<Shippers> _shippersnRepository;

			#endregion

			/// <summary>
			///     Protected Virtual Dispose method
			/// </summary>
			/// <param name="disposing"></param>
			protected virtual void Dispose(bool disposing)
			{
				if (!disposed)
				{
					if (disposing)
					{
						Debug.WriteLine("UnitOfWork is being disposed");
						_context.Dispose();
					}
				}
				disposed = true;
			}

			/// <summary>
			///     Dispose method
			/// </summary>
			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			#endregion
		}
	}
}