using Microsoft.EntityFrameworkCore;
using ShopStoreWithIdentity.Entity;
using ShopStoreWithIdentity.Persistance.Database;
using ShopStoreWithIdentity.Persistance.Repository.RepositoryInterface;

namespace ShopStoreWithIdentity.Persistance.Repository
{
    public class InvestorRepo : Repository<Investor, Guid>,IInvestorRepo
    {
        public InvestorRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
