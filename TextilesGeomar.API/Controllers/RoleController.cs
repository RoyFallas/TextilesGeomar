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

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            var user = await _roleService.GetRoleById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole([FromBody] Role role)
        {
            await _roleService.AddRole(role);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.RoleId }, role);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRole([FromBody] Role role)
        {
            await _roleService.UpdateRole(role);
            return CreatedAtAction($"{nameof(UpdateRole)}", new { id = role.RoleId }, role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRole(id);
            return NoContent();
        }
    }
}
