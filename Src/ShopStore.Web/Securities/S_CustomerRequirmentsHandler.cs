using Microsoft.AspNetCore.Authorization;

namespace ShopStore.Web.Securities
{
    public class S_CustomerRequirmentsHandler:AuthorizationHandler<SpecialCustomerRequirments>
    {

        protected override Task HandleRequirementAsync (
            AuthorizationHandlerContext context, 
            SpecialCustomerRequirments requirement )
        {

            if (context.User.HasClaim(x => x.Type == "SpecialStoreCustomer" 
                                & x.Value=="true"))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }

    }
}
