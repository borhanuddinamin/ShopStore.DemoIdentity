using Microsoft.AspNetCore.Identity;
using ShopStore.DemoIdentity.Feature.Membership;

namespace ShopStore.Web.Feature.Membership
{
    public class RoleManeger : RoleManager<Role>
    {
        public RoleManeger(
            IRoleStore<Role> store, 
            IEnumerable<IRoleValidator<Role>> roleValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            ILogger<RoleManager<Role>> logger) :
         base(store, roleValidators, keyNormalizer, errors, logger)
        {

        }
    }
}
