using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Domain.Business;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Models.Request;
using MyRecipes.WebApi.Identity;
using MyRecipes.WebApi.Tools;
using System.Security.Claims;

namespace MyRecipes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
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

        [Authorize]
        [HttpGet("Self")]
        public ActionResult GetCurrentUserInformation()
        {
            var test  = HttpContext.User;
            return Ok(test);
        }

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

        [Authorize]
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> PutModifyUser(int Id, UserRequest user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userConnect = HttpContext.User.Identity as ClaimsIdentity;
                    if (userConnect != null) 
                    {
                        if (CurrentUserTools.CheckCurrentUserAccess(userConnect, Id))
                            return Ok(await _usersBusiness.ChangeUserInformation(user, Id));
                        return StatusCode(403, "Not Allow");
                    }
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

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPatch("{Id:int}/Access")]
        public async Task<ActionResult> PatchModifyUserAccess(int Id, string newRole)
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
        public async Task<ActionResult> PatchModifyPassword(int Id, ChangePasswordRequest request)
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

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var userConnect = HttpContext.User.Identity as ClaimsIdentity;
                if (userConnect != null)
                {
                    if (CurrentUserTools.CheckCurrentUserAccess(userConnect, id))
                    {
                        var ret = await _usersBusiness.DeleteUser(id);
                        if ( ret)
                            return Ok();
                    }
                    return StatusCode(403, "Not Allow");
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return NotFound();
        }

    }
}
