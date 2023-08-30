
using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Persistance.Database;
using ShopStore.DemoIdentity.Persistance.UnitOfWork;
using ShopStore.Web.Persistance.Repository;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;

namespace ShopStore.Web.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        public bool disposed = false;
        public IApplicationDbContext applicationDb { get; set; }
        public UnitOfWork(IApplicationDbContext _applicationDb) 
        {
            applicationDb = _applicationDb;
        }
        public ICustomerRepository CustomerRepository {
            get
            {
                return new CustomerRepository((DbContext)applicationDb);
            }
        }
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return new EmployeeRepository((DbContext)applicationDb);
            }
        }

        public IInvestorRepository InvestorRepository
        {
            get
            {
                return new InvestorRepository((DbContext)applicationDb);
            }
        }

        public IOwnerRepository OwnerRepository
        {
            get
            {
                return new OwnerRepository((DbContext)applicationDb);
            }
        }

        public void Dispose()
        {
            CustomerRepository.DisposeASync();
            EmployeeRepository.DisposeASync();
            InvestorRepository.DisposeASync();
            OwnerRepository.DisposeASync();
            //GC.SuppressFinalize(CustomerRepository);// Dispose all ready use this
        }
     
    }
}
