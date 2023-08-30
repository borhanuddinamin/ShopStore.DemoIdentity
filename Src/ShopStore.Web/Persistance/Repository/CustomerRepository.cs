using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Entity;
using ShopStore.DemoIdentity.Persistance;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;

namespace ShopStore.Web.Persistance.Repository
{
    public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
