using Microsoft.AspNetCore.Identity;
using ShopStore.DemoIdentity.Feature.Membership;
using ShopStore.DemoIdentity.Persistance.Database;
using ShopStore.Web.Feature.Membership;

namespace ShopStore.Web.Persistance.Extension
{
    public static class ServiceCollection
    {

        public static void AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManeger>()
                .AddRoleManager<RoleManeger>()
                .AddSignInManager<SignInManeger>()
                .AddDefaultTokenProviders();



            services.Configure<IdentityOptions>(
                options =>
                {

                    //Password Setting
                    options.Password.RequireDigit= true;
                    options.Password.RequireLowercase= true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 7;


                    //Locout setting

                    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 6;
                    options.Lockout.AllowedForNewUsers = true;

                    //user setting


                    options.User.AllowedUserNameCharacters =
                    "ZXCVBNMLKJHGFDSAQWERTYUIOPzxcvbnmlkjhgfdsaqwertyuiop0123456789@-_.+#";

                    options.User.RequireUniqueEmail = true;
                });

            services.AddRazorPages();

        }
    }
}
