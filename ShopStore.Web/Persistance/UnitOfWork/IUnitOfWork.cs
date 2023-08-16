using ShopStore.DemoIdentity.Entity;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;

namespace ShopStore.DemoIdentity.Persistance.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Owner,Guid>OwnerRepo { get; }
    }
}
