using StructureMap;
using WebApi2OdataPoC.Repository.EF.UnitOfWork;
using WebApi2OdataPoC.Repository.EF.UnitOfWork.DataModel.UnitOfWork;
using WebApi2Odata_PoC.Services;

namespace WebApi2Odata_PoC.DependencyInjection
{
	public static class IoC
	{
		public static IContainer GetContainer()
		{
			return new Container(x =>
			{
				x.Scan(scan =>
				{
					// scan.Assembly("");
					scan.WithDefaultConventions();
				});
				x.For<IProductServices>().Use<ProductServices>();
			//	x.For<IDbContext>().Use<Northwind>();
				x.For<IUnitOfWork>().Use<UnitOfWork>();
			});
		}
	}
}