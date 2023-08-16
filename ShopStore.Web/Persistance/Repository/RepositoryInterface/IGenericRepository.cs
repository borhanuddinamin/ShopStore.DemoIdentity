using ShopStore.DemoIdentity.Persistance;
using ShopStore.DemoIdentity.Persistance;

namespace ShopStore.Web.Persistance.Repository.RepositoryInterface
{
    public interface IGenericRepository<TEntity,Tkey>:IRepository<TEntity, Tkey>
                                  where TEntity : class, IDisposable
    {



    }
}
