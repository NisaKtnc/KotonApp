using Koton.Business.Abstract;
using Koton.DAL.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly ICustomerRepository _customerRepository;

        public TokenService(IConfiguration config,ICustomerRepository customerRepository)
        {
            _config = config;
            _customerRepository = customerRepository;
        }
        public async Task<string> CreateToken(string email)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var customer = await _customerRepository.GetCustomerByEmail(email);

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, email),
            };

            foreach (var role in customer.CustomerRoles.Select(x=> x.Role)) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config["Jwt:Issuer"],
                claims: claims,
                audience: _config["Jwt:Issuer"],
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
