using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MyRecipes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private static IUserBusiness _usersBusiness;
        private readonly string SecretToken = "ForTheLoveOfGodStoreAndLoadThisSecurely";

        public AuthController(IUserBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }

        [HttpPost]
        public async Task<ActionResult> ConnectUser(ConnectUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(SecretToken);
                UserModel userFound;
                try
                {
                    userFound = await _usersBusiness.AuthenticateUser(request);
                }
                catch (NullReferenceException )
                {
                    return BadRequest("Username or password is incorrect");
                }
                catch (Exception ){
                    return StatusCode(500);
                }
                if (userFound is not null)
                {
                    var Claims = new List<Claim>
                    {
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new(JwtRegisteredClaimNames.Sub, request.UserName),
                        new(JwtRegisteredClaimNames.UniqueName, request.UserName),
                        new("userid", userFound.Id.ToString())
                    };
                    Claim claim;
                    if (userFound.Role == "ADMIN")
                          claim = new Claim("admin", "true", "Boolean");
                    else
                        claim = new Claim("admin", "false", "Boolean");
                    Claims.Add(claim);
                    claim = new Claim("user", "true", "Boolean");
                    Claims.Add(claim);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(Claims),
                        Expires = DateTime.Now.AddHours(1),
                        Issuer = "MyRecipesAPI",
                        Audience = "Audience",
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwt = tokenHandler.WriteToken(token);
                    return Ok(jwt);
                }
                
            }

            return BadRequest(ModelState);
        }
    }
}
