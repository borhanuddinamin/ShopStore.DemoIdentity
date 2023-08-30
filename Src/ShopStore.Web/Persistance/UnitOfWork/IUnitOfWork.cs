using ShopStore.DemoIdentity.Entity;
using ShopStore.Web.Persistance.GenericRepository;
using ShopStore.Web.Persistance.Repository;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;

namespace ShopStore.DemoIdentity.Persistance.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        public ICustomerRepository CustomerRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IInvestorRepository InvestorRepository { get; }
        public IOwnerRepository OwnerRepository { get; }
    }
}
