using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using ShopStore.DemoIdentity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//<!---Autofac Setting--->
var connectionString = builder.Configuration.GetConnectionString("connectionString");
var assembly=Assembly.GetExecutingAssembly().FullName;
  builder.Host
     .UseServiceProviderFactory(new AutofacServiceProviderFactory());
  builder.Host
    .ConfigureContainer<ContainerBuilder>(container =>
  {
      container.RegisterModule(new ShopStoreModule(connectionString, assembly));
   });


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
