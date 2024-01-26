using CvAPI.Application.Abstractions.AccessToken;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public (string Token, DateTime Expires) CreateAccessToken(int minute)
        {
            

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials=new(securityKey,SecurityAlgorithms.HmacSha256);
            DateTime tokenExpires = DateTime.Now.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: tokenExpires,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();

            string token=tokenHandler.WriteToken(securityToken);

            return new()
            {
                Token = token,
                Expires = tokenExpires,
            };
        }

        public (string Token, DateTime Expires) CreateRefreshToken(DateTime tokenExpiresDate,int addedMinutes)
        {
            byte[] number=new byte[32];
            using RandomNumberGenerator random= RandomNumberGenerator.Create();
            random.GetBytes(number);

            return new()
            {
                Token = Convert.ToBase64String(number),
                Expires = tokenExpiresDate.AddMinutes(addedMinutes)
            };
        }
    }
}
