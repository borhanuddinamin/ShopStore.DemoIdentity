using Microsoft.EntityFrameworkCore;
using ShopStoreWithIdentity.Entity;

namespace ShopStoreWithIdentity.Persistance.Database
{
    public interface IApplicationDbContext
    {
        DbSet<Customer>Customers { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Investor> Investors { get; }

        DbSet<Owner> Owners { get; }


    }
}
