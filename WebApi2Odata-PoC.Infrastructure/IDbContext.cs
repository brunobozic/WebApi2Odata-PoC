using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WebApi2Odata_PoC.Infrastructure
{
	public interface IDbContext
	{
		DbEntityEntry Entry(object o);
		Database GetDatabase();
		DbChangeTracker GetChangeTracker();
		DbContextConfiguration GetConfiguration();
		int SaveChanges();
		IDbSet<TEntity> Set<TEntity>() where TEntity : class;
		void Dispose();
	}
}