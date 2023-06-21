using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Domain.Business;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Models.Request;
using MyRecipes.WebApi.Identity;

namespace MyRecipes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private static IUserBusiness? _usersBusiness;

        public UsersController(IUserBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }

        [Authorize(Policy = IdentityData.SimpleUserPolicyName)]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var ret = await _usersBusiness.GetAllUsers();
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

        [Authorize(Policy = IdentityData.SimpleUserPolicyName)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var ret = await _usersBusiness.GetUserById(id);
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
        [HttpPost]
        public async Task<ActionResult> Post(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tmp = await _usersBusiness.AddUser(request);
                    return Created("Users/" + tmp.Id, tmp);
                }
                catch (NullReferenceException)
                {
                    return Conflict("User Allready Exist");
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> PostModifyUser(int Id, UserRequest user)
        {
            try
            {
                return Ok(await _usersBusiness.ChangeUserInformation(user, Id));
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

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPatch("{Id:int}/Access")]
        public async Task<ActionResult> PostModifyUserAccess(int Id, string newRole)
        {
            try
            {
                var ret = await _usersBusiness.EditUserAccess(Id, newRole);
                if (ret)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPatch("{Id:int}/Password")]
        public async Task<ActionResult> PostModifyPassword(int Id, ChangePasswordRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ret = await _usersBusiness.ChangePassword(Id, request);
                    if (ret)
                        return Ok();
                    else
                        return NotFound();
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }

            }
            return BadRequest(ModelState);

        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var ret = await _usersBusiness.DeleteUser(id);
                if (ret)
                    return Ok("User Delete");
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
