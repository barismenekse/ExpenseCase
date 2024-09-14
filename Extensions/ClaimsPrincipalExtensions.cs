using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExpenseCase.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetName(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(JwtRegisteredClaimNames.Name)?.Value;
    }

    public static string GetEmail(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
    }
    
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        return userId == null ? 0 : int.Parse(userId);
    }
}