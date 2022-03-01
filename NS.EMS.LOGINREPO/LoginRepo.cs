using Microsoft.Extensions.Configuration;
using NS.EMS.DATABASE.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace NS.EMS.LOGINREPO
{
    public class LoginRepo: ILoginRepo
    {
        private readonly IConfiguration _configuration;
        public LoginRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetLogin(Login login)
        {
           
            using(var context = new UPSContext())
            {
                
                Login user = context.Login.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                if(user == null)
                {
                    return ("Error no account, Contact Admin");
                }
                else
                {
                    var token = GenerateToken(user.UserName, user.Role);
                    return token;
                }
                
            }
    
        }

        private string GenerateToken(string userName , string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
                {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Role, role),
                };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
