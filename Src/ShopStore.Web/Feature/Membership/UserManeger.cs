using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ShopStore.DemoIdentity.Feature.Membership;

namespace ShopStore.Web.Feature.Membership
{
    public class UserManeger : UserManager<User>
    {
        public UserManeger(
            IUserStore<User> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators, 
            IEnumerable<IPasswordValidator<User>> passwordValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
            IServiceProvider services, ILogger<UserManager<User>> logger) :

         base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators,
                      keyNormalizer, errors, services, logger)
        {

        }
    }
}
