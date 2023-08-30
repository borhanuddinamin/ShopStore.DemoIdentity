using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using ShopStore.DemoIdentity;
using System.Reflection;
using ShopStore.Web.Persistance.Extension;
using ShopStore.Web.Securities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopStore.DemoIdentity.Persistance.Database;
using ShopStore.DemoIdentity.Feature.Membership;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity();


builder.Services.AddAuthentication().AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/AccessDenied");
        options.LogoutPath = new PathString("/Account/LogOut");
        options.Cookie.Name = "ShopStore_BorhanAmin";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan= TimeSpan.FromMinutes(20);

    });


builder.Services.AddAuthentication()
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                          .GetBytes(builder.Configuration["JWT:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],


        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("StoreAdmin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");

    });

    options.AddPolicy("AccountEmployee", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Accountend");

        });

    options.AddPolicy("StaffEmployee", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Satff");
    });

    options.AddPolicy("RegularCustomer", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Customer");
    });
    options.AddPolicy("SpecialCustomer", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("SpecialStoreCustomer","true");
        policy.Requirements.Add(new SpecialCustomerRequirments());
    });
});





builder.Services.AddSingleton<IAuthorizationHandler,S_CustomerRequirmentsHandler>();


//<!---Autofac Setting--->
var connectionString = builder.Configuration.GetConnectionString("connectionString");

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
var assembly = Assembly.GetExecutingAssembly().FullName;
builder.Host
     .UseServiceProviderFactory(new AutofacServiceProviderFactory());
  builder.Host
    .ConfigureContainer<ContainerBuilder>(container =>
  {
      container.RegisterModule(new ShopStoreModule(connectionString, assembly));
   });





var app = builder.Build();
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
