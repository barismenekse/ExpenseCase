using System.Security.Claims;

namespace ExpenseCase.Infrastructure.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(string userId, string email, string name);
    ClaimsPrincipal VerifyToken(string token);
}