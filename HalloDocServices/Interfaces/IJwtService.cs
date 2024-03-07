using HalloDocRepository.DataModels;
using System.IdentityModel.Tokens.Jwt;

namespace HalloDocServices.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(AspNetUser model);
        bool ValidateToken(string token, out JwtSecurityToken jwtSecurityToken);
    }
}