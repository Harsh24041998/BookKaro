using System.Security.Claims;

namespace Bussiness.Contracts.Services
{
    public interface IAuthService
    {
        public string GenerateToken(Claim[] claimsIdentity);
    }
}
