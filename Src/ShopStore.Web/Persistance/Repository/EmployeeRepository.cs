using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Entity;
using ShopStore.DemoIdentity.Persistance;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;

namespace ShopStore.Web.Persistance.Repository
{
    public class EmployeeRepository : Repository<Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
