using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Models;
using MyRecipes.Domain.Models.Request;
using MyRecipes.WebApi.Identity;

namespace MyRecipes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class IngredientController : Controller
    {
        private static IIngredientBusiness _ingredientBusiness;

        public IngredientController(IIngredientBusiness ingredientBusiness)
        {
            _ingredientBusiness = ingredientBusiness;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            try
            {
                var t = await _ingredientBusiness.GetAllIngredients();
                return Ok(t);
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
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> Get(int Id)
        {

            try
            {
                var t = await _ingredientBusiness.GetIngredientById(Id);
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
        [HttpGet("Recipe/{Id:int}")]
        public async Task<ActionResult> GetbyRecipe(int Id)
        {

            try
            {
                var ret = await _ingredientBusiness.FoundIngredientByRecetteId(Id);
                return Ok(ret);
            }
            catch (NullReferenceException )
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                var ret = await _ingredientBusiness.DeleteIngredient(Id);
                if (ret)
                    return Ok("Ingredient Delete");
                return NoContent();
            }
            catch (NullReferenceException )
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpDelete("Recipe/{Id:int}")]
        public async Task<ActionResult> DeleteIngredientsByRecipeId(int Id)
        {
            try
            {
                var ret = await _ingredientBusiness.DeleteIngredientByRecipeId(Id);
                if (ret)
                    return Ok("Ingredient Delete");
                return NoContent();
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

        [HttpPost]
        public async Task<ActionResult> CreateIngredients(List<IngredientRequest> requests)
        {
            try
            {
                var ret = await _ingredientBusiness.CreateIngredients(requests);
                return Created("Ingredien/", ret);
            }
            catch (NullReferenceException)
            {
                return Conflict("AlreadyExist");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
