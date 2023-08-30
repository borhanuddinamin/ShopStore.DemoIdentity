using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Entity;
using ShopStore.DemoIdentity.Persistance;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;

namespace ShopStore.Web.Persistance.Repository
{
    public class OwnerRepository : Repository<Owner, Guid>, IOwnerRepository
    {
        public OwnerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
