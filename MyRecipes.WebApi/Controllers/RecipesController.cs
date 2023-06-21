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
    public sealed class RecipesController : Controller
    {
        private static IRecipesBusiness _recipesBusiness;

        public RecipesController(IRecipesBusiness recipesBusiness)
        {
            _recipesBusiness = recipesBusiness;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var t = await _recipesBusiness.GetAllRecipes();
                return Ok(t);
            }
            catch ( NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetById(int Id)
        {
            try
            {
                var t = await _recipesBusiness.GetRecipeById(Id);
                return Ok(t);
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
        [HttpGet("Ingredient/")]
        public async Task<ActionResult> GetRecipebyIngredientName(string Name)
        {
            try
            {
                var ret = await _recipesBusiness.FoundRecetteByIngredientName(Name);
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
        [HttpGet("Nationality/")]
        public async Task<ActionResult> GetByNationality(string nationality)
        {
            try
            {
                var ret = await _recipesBusiness.FoundRecetteByNationality(nationality);
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
        [HttpPost]
        public async Task<ActionResult> Post(RecipeRequest requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ret = await _recipesBusiness.CreateRecipe(requestModel);
                    return Created("Recipes/" + ret.Id,ret);
                }
                catch (NullReferenceException)
                {
                    return Conflict();
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
            
        }


        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                var currentUser = HttpContext.User.Identity as ClaimsIdentity;
                if (currentUser is not null)
                {
                    var user = await _recipesBusiness.FoundUserByRecipe(Id);
                    if (CurrentUserTools.CheckCurrentUserAccess(currentUser, user.Id))
                    {
                        var ret = await _recipesBusiness.DeleteRecipe(Id);
                        if (ret)
                            return Ok("Recipes Delete");
                        return NoContent();
                    }
                    return StatusCode(403, "Not Allow");
                }
                return StatusCode(401);
            }
            catch (NullReferenceException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(RecipeRequest request, int Id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = HttpContext.User.Identity as ClaimsIdentity;
                    if (currentUser is not null)
                    {
                        var user = await _recipesBusiness.FoundUserByRecipe(Id);
                        if (CurrentUserTools.CheckCurrentUserAccess(currentUser, user.Id))
                        {
                            var ret = await _recipesBusiness.ModifyRecipe(request, Id);
                            return Ok(ret);
                        }
                        return StatusCode(403, "Not Allow");
                    }
                    return StatusCode(401);

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
            return BadRequest(ModelState);

        }
    }
}
