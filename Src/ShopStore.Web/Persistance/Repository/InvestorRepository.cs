using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Entity;
using ShopStore.DemoIdentity.Persistance;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;

namespace ShopStore.Web.Persistance.Repository
{
    public class InvestorRepository : Repository<Investor, Guid>, IInvestorRepository
    {
        public InvestorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
