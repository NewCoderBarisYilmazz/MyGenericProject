using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using New.Context.DTO;
using New.JwtAyar;
using New.JwtSet;

namespace New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly JwtRead _jwtSet;
        private readonly IConfiguration _config;
        public KullaniciController(IOptions<JwtRead> jwtOptions, IConfiguration config)
        {
            _jwtSet = jwtOptions.Value;
            _config = config;
        }
        [Route("giris")]
        [HttpPost]
        public IActionResult Giris(LoginDto loginDto) 
        {
            if (!CheckUser(loginDto,_config))
                return BadRequest("Kullanıcı adı veya Parola yanlış");
                 return Ok(CreateToken.TokenOlustur(loginDto,_jwtSet));
        }
    

        private bool CheckUser(LoginDto loginDto,IConfiguration config)
        {
            var res = config.GetSection("Jwt:userName").Value;
            if (loginDto.UserName != config.GetSection("Jwt:userName").Value
                || loginDto.Password != config.GetSection("Jwt:password").Value
                )
                return false;
            return true;
        }
    }
}
