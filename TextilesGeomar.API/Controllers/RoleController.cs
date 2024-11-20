using Microsoft.AspNetCore.Mvc;
using TextilesGeomar.Core.DTOs;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService _roleService;
        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetRoles()
        {
            var users = await _roleService.GetRoles();
            return Ok(users);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUserById(int id)
        //{
        //    var user = await _userService.GetUserById(id);
        //    return Ok(user);
        //}

        //[HttpPost]
        //public async Task<ActionResult> AddUser([FromBody] User user)
        //{
        //    await _userService.AddUser(user);
        //    return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        //}
        //[HttpPut]
        //public async Task<ActionResult> UpdateUser([FromBody] User user)
        //{
        //    await _userService.UpdateUser(user);
        //    return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteUser(int id)
        //{
        //    await _userService.DeleteUser(id);
        //    return NoContent();
        //}
    }
}
