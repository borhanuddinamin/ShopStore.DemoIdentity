using Autofac;
using ShopStore.DemoIdentity.Entity;
using ShopStore.DemoIdentity.Models;
using ShopStore.DemoIdentity.Persistance;
using ShopStore.DemoIdentity.Persistance.Database;
using ShopStore.DemoIdentity.Persistance.Repository;
using ShopStore.DemoIdentity.Persistance.Repository.RepositoryInterface;

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


        builder.RegisterType<CustomerRepo>()
            .As<ICustomerRepo>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeRepo>()
            .As<IEmployeeRepo>().InstancePerLifetimeScope();

        builder.RegisterType<InvestorRepo>()
            .As<InvestorRepo>().InstancePerLifetimeScope();

        builder.RegisterType<OwnerRepo>()
            .As<IOwnerRepo>().InstancePerLifetimeScope();

        builder.RegisterType<CustomerModel>()
             .AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeModel>()
            .AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<InvestorModel>()
            .AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<OwnerModel>()
            .AsSelf().InstancePerLifetimeScope();

        base.Load(builder);
    }
}