using Autofac.Features.OwnedInstances;
using Microsoft.EntityFrameworkCore;
using ShopStoreWithIdentity.Entity;
using ShopStoreWithIdentity.Persistance.Database;

namespace ShopStoreWithIdentity.Persistance.Repository
{
    public class OwnerRepo : Repository<Owner, Guid>
    {
        public OwnerRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
