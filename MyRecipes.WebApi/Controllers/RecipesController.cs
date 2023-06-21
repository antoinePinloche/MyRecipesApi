using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Models.Request;
using MyRecipes.WebApi.Identity;

namespace MyRecipes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : Controller
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
        public async Task<ActionResult> Get(int Id)
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
        public async Task<ActionResult> GetbyRecipe(string Name)
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


        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                var ret = await _recipesBusiness.DeleteRecipe(Id);
                if (ret)
                    return Ok("Recipes Delete");
                return NoContent();
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

        [Authorize(Policy =IdentityData.AdminUserPolicyName)]
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(RecipeRequest request, int Id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ret = await _recipesBusiness.ModifyRecipe(request, Id);
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
            return BadRequest(ModelState);

        }
    }
}
