using ShopStore.DemoIdentity.Entity;
using ShopStore.DemoIdentity.Persistance;

namespace ShopStore.Web.Persistance.Repository.RepositoryInterface
{
    public interface ICustomerRepository:IRepository<Customer,Guid>
    {
    }
}
