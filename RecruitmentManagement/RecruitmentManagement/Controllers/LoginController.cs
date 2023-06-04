using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecruitmentManagement.Client.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecruitmentManagement.Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost, Route("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDTO.UserName) || string.IsNullOrEmpty(loginDTO.Password))
                    return BadRequest("Username and/or Password not specified");

                if (loginDTO.UserName.Equals("admin") && loginDTO.Password.Equals("admin"))
                {
                    var secretKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes("thisisasecretkey@123"));
                    var signinCredentials = new SigningCredentials
                   (secretKey, SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: "ABCXYZ",
                        audience: "http://localhost:5005",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                    return Ok(new JwtSecurityTokenHandler().
                            WriteToken(jwtSecurityToken));
                }
                else
                {
                    return BadRequest("Invalid Username or Password");
                }
            }
            catch
            {
                return BadRequest
                ("An error occurred in generating the token");
            }
          
        }
    }
}
