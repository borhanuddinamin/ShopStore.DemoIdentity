using Microsoft.EntityFrameworkCore;
using ShopStoreWithIdentity.Entity;
using ShopStoreWithIdentity.Persistance.Database;
using ShopStoreWithIdentity.Persistance.Repository.RepositoryInterface;

namespace ShopStoreWithIdentity.Persistance.Repository
{
    public class EmployeeRepo : Repository<Employee, Guid>, IEmployeeRepo
    {
        public EmployeeRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
