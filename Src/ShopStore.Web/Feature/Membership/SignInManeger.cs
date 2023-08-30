using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ShopStore.DemoIdentity.Feature.Membership;

namespace ShopStore.Web.Feature.Membership
{
    public class SignInManeger : SignInManager<User>
    {
        public SignInManeger(UserManager<User> userManager, 
                       IHttpContextAccessor contextAccessor, 
                       IUserClaimsPrincipalFactory<User> claimsFactory,
                       IOptions<IdentityOptions> optionsAccessor, 
                       ILogger<SignInManager<User>> logger,
                       IAuthenticationSchemeProvider schemes, 
                       IUserConfirmation<User> confirmation) : 
         base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {

        }


    }
}
