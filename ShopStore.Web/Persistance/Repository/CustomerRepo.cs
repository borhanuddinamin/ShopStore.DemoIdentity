using Microsoft.EntityFrameworkCore;
using ShopStoreWithIdentity.Entity;
using ShopStoreWithIdentity.Persistance.Database;
using ShopStoreWithIdentity.Persistance.Repository.RepositoryInterface;

namespace ShopStoreWithIdentity.Persistance.Repository
{
    public class CustomerRepo : Repository<Customer, Guid>, ICustomerRepo
    {
        public CustomerRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
