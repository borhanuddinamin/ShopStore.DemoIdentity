using Microsoft.AspNetCore.Identity;

namespace ShopStore.DemoIdentity.Feature.Membership
{
    public class User:IdentityUser<Guid>
    {
        public string Name { get; set; }

    }
}
