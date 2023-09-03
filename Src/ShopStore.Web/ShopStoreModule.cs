using Autofac;
using ShopStore.DemoIdentity.Models;

using ShopStore.DemoIdentity.Persistance.Database;
using ShopStore.Web.Models;
using ShopStore.Web.Persistance.Repository;
using ShopStore.Web.Persistance.Repository.RepositoryInterface;
using ShopStore.Web.Securities.Token;

internal class ShopStoreModule : Module
{

    public readonly string _ConnectionString;
    public readonly string _migrationString;

    public ShopStoreModule(string connectionString, string migrationString)
    {
        _ConnectionString = connectionString;
        _migrationString = migrationString;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ApplicationDbContext>().AsSelf()
            .WithParameter("connectionString", _ConnectionString)
            .WithParameter("migrationString", _migrationString)
            .InstancePerLifetimeScope();


        builder.RegisterType<ApplicationDbContext>()
            .As<IApplicationDbContext>()
            .WithParameter("connectionString", _ConnectionString)
            .WithParameter("migrationString", _migrationString)
            .InstancePerLifetimeScope();


        builder.RegisterType<CustomerRepository>()
            .As<ICustomerRepository>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeRepository>()
            .As<IEmployeeRepository>().InstancePerLifetimeScope();

        builder.RegisterType<InvestorRepository>()
            .As<IInvestorRepository>().InstancePerLifetimeScope();

        builder.RegisterType<OwnerRepository>()
            .As<IOwnerRepository>().InstancePerLifetimeScope();

        builder.RegisterType<CustomerModel>()
             .AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeModel>()
            .AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<InvestorModel>()
            .AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<OwnerModel>()
            .AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<LoginModel>()
           .AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<TokenService>().As<ITokenService>()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}