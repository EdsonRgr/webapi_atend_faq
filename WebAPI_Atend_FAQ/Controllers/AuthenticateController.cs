using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI_Atend_FAQ.IdentityAuth;
using WebAPI_Atend_FAQ.Models;

namespace WebAPI_Atend_FAQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;



        public AuthenticateController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null) 
            {
                return BadRequest(new Response { Status = "Error", Message = "Ususario já existe" });
            }

            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                UserAtendimento = model.UserAtendimento,
                Funcional = string.IsNullOrEmpty(model.Funcional) ? GenerateRandomNumber() : model.Funcional,
                NomeCompleto = model.NomeCompleto
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) 
            {
                return BadRequest(new Response { Status = "Error", Message = "Erro na criação de ususario" });
            }
            return Ok(new Response { Status = "Success", Message = "Ususario Criado com Sucesso" });

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }
            return Unauthorized();

        }


        [Authorize]
        [HttpGet]
        [Route("profile")]
        public async Task<ActionResult> UserProfile()
        {
            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "ID do usuário não encontrado" });
            }

            
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Usuário não encontrado" });
            }

            
            return Ok(new
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserAtendimento = user.UserAtendimento,
                Funcional = user.Funcional,
                NomeCompleto = user.NomeCompleto
           
            });
        }


        private string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return randomNumber.ToString();
        }

    }
}
