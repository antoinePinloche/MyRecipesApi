using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Models.Request;
using MyRecipes.WebApi.Identity;
using MyRecipes.WebApi.Tools;
using System.Security.Claims;

namespace MyRecipes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class RecipesUserController : Controller
    {
        private static IRecipesUserBusiness _recipesUserBusiness;

        public RecipesUserController(IRecipesUserBusiness recipesUserBusiness)
        {
            _recipesUserBusiness = recipesUserBusiness;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var ret = await _recipesUserBusiness.GetAllRecipesUser();
                return Ok(ret);
            }
            catch (NullReferenceException)
            {
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [Authorize]
        [HttpGet("User/{Id:int}")]
        public async Task<ActionResult> GetByUserId(int Id)
        {
            try
            {
                var ret = await _recipesUserBusiness.GetRecipesUserById(Id);
                return Ok(ret);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                var currentUser = HttpContext.User.Identity as ClaimsIdentity;
                if (currentUser == null)
                {
                    var uuserFound = await _recipesUserBusiness.GetUserByRecipesUserId(Id);
                    if (CurrentUserTools.CheckCurrentUserAccess(currentUser, uuserFound.Id))
                    {
                        var ret = await _recipesUserBusiness.DeleteRecipesUser(Id);
                        if (ret)
                            return Ok("RecipesUser Delete");
                        return NoContent();
                    }
                }
                return StatusCode(401);

            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostRecipesUser(RecipesUserRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ret = await _recipesUserBusiness.CreateRecipesUser(request);
                    return Ok(ret);
                }
                return BadRequest(ModelState);
            }
            catch(NullReferenceException)
            {
                return Conflict("RecipeUser all ready Exist");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
