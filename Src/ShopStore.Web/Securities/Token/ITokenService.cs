using System.Security.Claims;

namespace ShopStore.Web.Securities.Token
{
    public interface ITokenService
    {
        Task<String> GetJwtToken(IList<Claim> claims);
    }
}
