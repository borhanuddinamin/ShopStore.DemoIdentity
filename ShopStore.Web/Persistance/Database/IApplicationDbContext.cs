using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Entity;

namespace ShopStore.DemoIdentity.Persistance.Database
{
    public interface IApplicationDbContext
    {
        DbSet<Customer>Customers { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Investor> Investors { get; }

        DbSet<Owner> Owners { get; }


    }
}
