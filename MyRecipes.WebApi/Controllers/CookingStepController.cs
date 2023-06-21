using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using MyRecipes.WebApi.Identity;
using MyRecipes.WebApi.Tools;
using System.Security.Claims;

namespace MyRecipes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class CookingStepController : Controller
    {

        private static ICookingStepsBusiness _cookingStepsBusiness;

        public CookingStepController(ICookingStepsBusiness cookingStepsBusiness)
        {
            _cookingStepsBusiness = cookingStepsBusiness;
        }
        [Authorize(Policy = IdentityData.SimpleUserPolicyName)]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var ret = await _cookingStepsBusiness.GetAllCookingSteps();
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

        [Authorize(Policy = IdentityData.SimpleUserPolicyName)]
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetById(int Id)
        {
            try
            {
                var ret = await _cookingStepsBusiness.GetCookingStepsById(Id);
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

        [Authorize(Policy = IdentityData.SimpleUserPolicyName)]
        [HttpGet("Recipe/{Id:int}")]
        public async Task<ActionResult> GetByRecipeId(int Id)
        {
            try
            {
                var ret = await _cookingStepsBusiness.GetCookingStepsByRecipeId(Id);
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
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeleteById(int Id)
        {
            try
            {
                var user = await _cookingStepsBusiness.FoundUserByCookingStepId(Id);
                var actualUser = HttpContext.User.Identity as ClaimsIdentity;
                if (user is not null)
                {
                    if (CurrentUserTools.CheckCurrentUserAccess(actualUser, user.Id))
                    {
                        var ret = await _cookingStepsBusiness.RemoveCookingStep(Id);
                        if (ret is false)
                            return NotFound();
                        return Ok("CookingStep Delete");
                    }
                    return StatusCode(403);
                }
                return NotFound();

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
        [HttpDelete("Recipe/{Id:int}")]
        public async Task<ActionResult> DeleteByRecipeId(int Id)
        {
            try
            {
                var user = await _cookingStepsBusiness.FoundUserByCookingStepId(Id);
                var actualUser = HttpContext.User.Identity as ClaimsIdentity;
                if (user is not null)
                {
                    if (CurrentUserTools.CheckCurrentUserAccess(actualUser, user.Id))
                    {
                        var ret = await _cookingStepsBusiness.RemoveAllCookingStepByRecipeId(Id);
                        if (ret == false)
                            return NoContent();
                        return Ok("CookingSteps Delete");
                    }
                    return StatusCode(403);
                }
                return NotFound();
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

        [Authorize(Policy = IdentityData.SimpleUserPolicyName)]
        [HttpPost]
        public async Task<ActionResult> CreateCookingStep(List<CookingStepRequest> cookingSteps)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ret = await _cookingStepsBusiness.CreateCookingStep(cookingSteps);
                    return Ok(ret);

                }
                catch (NullReferenceException)
                {
                    return Conflict("CookingSteps Allready exist");
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }

            }
            return BadRequest(ModelState);

        }

    }
}
