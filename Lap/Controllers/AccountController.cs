using Lap.DTO;
using Lap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userDTO.username;
                user.PasswordHash = userDTO.password;
                user.Email = userDTO.email;
                var result = await userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(userDTO.username);
                if (user != null)
                {

                    bool found = await userManager.CheckPasswordAsync(user, userDTO.password);
                    if (found)
                    {
                        // Add Claims for the Token 
                        List<Claim> myCalim = new List<Claim>();
                        myCalim.Add(new Claim(ClaimTypes.Name, user.UserName));
                        myCalim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        myCalim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        var roles = await userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            myCalim.Add(new Claim(ClaimTypes.Role, role));
                        }


                        /// Create Signature ==>
                        var signInKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["JWT:SecritKey"]));//"fdfgdfdfgdgfd

                        SigningCredentials signingCredentials = new SigningCredentials(
                            signInKey,
                            SecurityAlgorithms.HmacSha256
                            );
                        /// Generate Token 
                        JwtSecurityToken token = new JwtSecurityToken(
                          issuer: config["JWT:ValidIss"],
                            audience: config["JWT:ValidAud"],
                           expires: DateTime.Now.AddDays(1),
                       claims: myCalim,
                           signingCredentials: signingCredentials

                           );
                        /// Return Token
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            exiperd = token.ValidTo
                        });
                    }
                }
                return Unauthorized();

            }
            return BadRequest(ModelState);
        }
    }
}
