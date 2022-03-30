using Homework4.Business.Abstracts;
using Homework4.Business.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Homework4.Business.Concretes
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration config;
        private readonly IUserLoginService userLoginService;

        public JwtService(IConfiguration config, IUserLoginService userLoginService)
        {
            this.config = config;
            this.userLoginService = userLoginService;
        }

        public TokenDTO Authenticate(UserDTO user)
        {
            if (!this.userLoginService.CheckCredentials(user))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenDTO { Token = tokenHandler.WriteToken(token) };
        }
    }
}
