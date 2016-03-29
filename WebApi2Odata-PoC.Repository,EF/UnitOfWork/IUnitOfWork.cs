using System;
using WebApi2Odata_PoC.Repository.EF.GenericRepository.DataModel.GenericRepository;

namespace WebApi2Odata_PoC.Repository.EF.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();
		void Dispose();
		GenericRepository<Categories> CategoriesRepository { get; set; }
		GenericRepository<Contacts> ContactsRepository { get; set; }
		GenericRepository<CustomerDemographics> CustomerDemographicsRepository { get; set; }
		GenericRepository<Customers> CustomersRepository { get; set; }
		GenericRepository<Employees> EmployeesRepository { get; set; }
		GenericRepository<Order_Details> OrderDetailsRepository { get; set; }
		GenericRepository<Orders> OrdersRepository { get; set; }
		GenericRepository<Products> ProductsRepository { get; set; }
		GenericRepository<Region> RegionRepository { get; set; }
		GenericRepository<Suppliers> SuppliersRepository { get; set; }
		GenericRepository<sysdiagrams> SysdiagramsRepository { get; set; }
		GenericRepository<Territories> TerritoriesRepository { get; set; }
		GenericRepository<Alphabetical_list_of_products> AlphabeticalListOfProductsRepository { get; set; }
		GenericRepository<Category_Sales_for_1997> CategorySalesFor1997Repository { get; set; }
		GenericRepository<Current_Product_List> CurrentProductListRepository { get; set; }
		GenericRepository<Customer_and_Suppliers_by_City> CustomerAndSuppliersByCityRepository { get; set; }
		GenericRepository<Invoices> InvoicesRepository { get; set; }
		GenericRepository<Order_Details_Extended> OrderDetailsExtendedRepository { get; set; }
		GenericRepository<Order_Subtotals> OrderSubtotalsRepository { get; set; }
		GenericRepository<Orders_Qry> OrdersQryRepository { get; set; }
		GenericRepository<Product_Sales_for_1997> ProductSalesFor1997Repository { get; set; }
		GenericRepository<Products_Above_Average_Price> ProductsAboveAveragePriceRepository { get; set; }
		GenericRepository<Products_by_Category> ProductsByCategoryRepository { get; set; }
		GenericRepository<Sales_by_Category> SalesByCategoryRepository { get; set; }
		GenericRepository<Sales_Totals_by_Amount> SalesTotalsByAmountRepository { get; set; }
		GenericRepository<Summary_of_Sales_by_Quarter> SummaryOfSalesByQuarterRepository { get; set; }
		GenericRepository<Summary_of_Sales_by_Year> SummaryOfSalesByYearRepository { get; set; }

		/// <summary>
		///     Get/Set Property for product repository.
		/// </summary>
		GenericRepository<Products> ProductRepository { get; }

		/// <summary>
		///     Get/Set Property for user repository.
		/// </summary>
		GenericRepository<Customers> CustomerRepository { get; }

		/// <summary>
		///     Get/Set Property for token repository.
		/// </summary>
		GenericRepository<Shippers> ShippersRepository { get; }

	
	}
}