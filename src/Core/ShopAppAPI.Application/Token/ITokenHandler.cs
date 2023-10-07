using System.Security.Claims;

namespace ShopAppAPI.Application;

public interface ITokenHandler
{
    TokenDto CreateAccessToken(int minute, List<Claim>? authClaims);
    string CreateRefreshToken();
}
