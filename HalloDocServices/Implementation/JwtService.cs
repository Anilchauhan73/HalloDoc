

//using HalloDocMVCRepository.Interface;
//using HalloDocMVCServices.Interface;
using HalloDocServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static HalloDocMVCServices.Implementation.JwtService;

namespace HalloDocMVCServices.Implementation
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;
        private readonly IAspNetUserRepo _aspNetUserRepo;
        public JwtService(IConfiguration configuration, IAspNetUserRepo aspNetUserRepo)
        {
            this.configuration = configuration;
            _aspNetUserRepo = aspNetUserRepo;
        }

        public string GenerateJWTAuthetication(string email)
        {

            string role = _aspNetUserRepo.FindRole(email);
            var claims = new List<Claim>
            {
                new Claim(JwtHeaderParameterNames.Jku, email),
                new Claim(ClaimTypes.Role,role),
                new Claim(JwtHeaderParameterNames.Kid, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, email)
            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(20);


            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public bool ValidateToken(string token, out JwtSecurityToken jwtSecurityToken)
        {
            jwtSecurityToken = null;

            if (token == null)
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                // Corrected access to the validatedToken


                jwtSecurityToken = (JwtSecurityToken)validatedToken;

                if (jwtSecurityToken != null)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
