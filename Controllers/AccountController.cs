using EmployeeManagementSystem.Dto;
using EmployeeManagementSystem.Interface;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUnitofWork uow;
        private readonly IConfiguration configuration;
        public AccountController(IUnitofWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.uow = uow;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

           

            if (user == null)
            {
               
                return Unauthorized("Invalid userId or Password");
            } 

            var loginRes = new LoginResDto();
            loginRes.UserName = user.UserName;
            loginRes.Token = CreateJWT(user);
            return Ok(loginRes);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginReqDto loginReq)
        {
           

            if (await uow.UserRepository.UserAlreadyExists(loginReq.UserName))
            {
                
                return BadRequest("already exist");
            }

            uow.UserRepository.Register(loginReq.UserName, loginReq.Password);
            await uow.SaveAsync();
            return StatusCode(201);
        } 
        private string CreateJWT(User user)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        } 
    }
}
