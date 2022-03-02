using AppointmentScheduling.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace AppointmentScheduling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        //private readonly JwtSettings jwtSettings;
        //public AccountController(JwtSettings jwtSettings)
        //{
        //    this.jwtSettings = jwtSettings;
        //}
        private IEnumerable<Users> logins = new List<Users>() {
            new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        UserName = "Admin",
                        Password = "Admin",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        UserName = "User1",
                        Password = "Admin",
                }
        };
        [AllowAnonymous]
        [HttpPost]
        
        public IActionResult GetToken([FromBody]UserLogins userLogins)
        {
            try
            {
                var Token = String.Empty;
                var Valid = logins.Any(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    var user = logins.FirstOrDefault(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                    //Token = JwtHelpers.JwtHelpers.GenTokenkey(new UserTokens()
                    //{
                    //    EmailId = user.EmailId,
                    //    GuidId = Guid.NewGuid(),
                    //    UserName = user.UserName,
                    //    Id = user.Id,
                    //}, jwtSettings);

                    Token = GenerateJSONWebToken();
                }
                else
                {
                    return BadRequest($"wrong password");
                }
                return Ok(Token);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetList()
        {
            return Ok("Yor are authorized user");
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("W74eKLfl5nLlmgRfz-xrzPU5e6TAVwRFG"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("Appointment.com",
              "Appointment.com",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
