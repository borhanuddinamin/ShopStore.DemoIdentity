using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Persistance;
using ShopStore.DemoIdentity.Persistance.Database;

namespace ShopStore.Web.Persistance.GenericRepository
{
    public class GenericRepository<TEntity, Tkey> : Repository<TEntity, Tkey>
                            where TEntity : class, IDisposable
    {
        public GenericRepository(IApplicationDbContext dbContext) : base((DbContext)dbContext)
        {
        }
    }
}
