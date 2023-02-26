using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using New.Context.DTO;
using New.JwtSet;

namespace New.JwtAyar
{
    public class CreateToken
    {
      
        public static string TokenOlustur(LoginDto customer, JwtRead _jwtSet)
        {
            if (_jwtSet.Key == null)
            {
                throw new Exception("Key değeri null olamaz");
            }
            var securtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSet.Key));
            var credentials = new SigningCredentials(securtyKey, SecurityAlgorithms.HmacSha256);
            var claimDizisi = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customer.UserName!)
            };

            var token = new JwtSecurityToken(
                _jwtSet.Issuer,
                _jwtSet.Audience,

                claimDizisi,
                expires: DateTime.Now.AddSeconds(2),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
