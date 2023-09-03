using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Entity;
using ShopStore.DemoIdentity.Feature.Membership;
using ShopStore.Web.Feature.Membership;

namespace ShopStore.DemoIdentity.Persistance.Database
{
    public class ApplicationDbContext:IdentityDbContext<User,Role,Guid,
                 UserClaim,UserRole,UserLogin,RoleClaim,UserToken>,IApplicationDbContext
    {

        public readonly string _ConnectionString;
        public  readonly string _migrationString;

        public ApplicationDbContext(string connectionString, string migrationString)
        {
            _ConnectionString = connectionString;
            _migrationString = migrationString;
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_ConnectionString,
                    
                    (x) => x.MigrationsAssembly(_migrationString)
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
