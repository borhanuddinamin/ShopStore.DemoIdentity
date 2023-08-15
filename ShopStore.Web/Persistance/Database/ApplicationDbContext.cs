using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopStoreWithIdentity.Entity;

namespace ShopStoreWithIdentity.Persistance.Database
{
    public class ApplicationDbContext:IdentityDbContext,IApplicationDbContext
    {

        public readonly string _ConnectionString;
        public  readonly string _migrationString;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_ConnectionString,
                    
                    (x) => x.MigrationsAssembly("_migrationString")
                    );
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions
              (ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }


        public DbSet<Customer> Customers { get; }
        public DbSet<Employee> Employees { get; }
        public DbSet<Investor> Investors { get; }

        public DbSet<Owner> Owners { get; }
    }
}
