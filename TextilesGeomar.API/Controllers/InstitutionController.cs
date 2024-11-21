using Microsoft.AspNetCore.Mvc;
using System.Data;
using TextilesGeomar.API.Services;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _service;
        public InstitutionController(IInstitutionService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult> AddInstitution([FromBody] Institution institution)
        {
            await _service.AddInstitution(institution);
            return CreatedAtAction(nameof(GetInstitutionById), new { id = institution.InstitutionId }, institution);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstitution(int id)
        {
            await _service.DeleteInstitution(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Institution>> GetInstitutionById(int id)
        {
            return await _service.GetInstitutionById(id);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutionS()
        {
            var institutions = await _service.GetInstitutions();
            return Ok(institutions);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateInstitution([FromBody] Institution institution)
        {
            await _service.UpdateInstitution(institution);
            return NoContent();
        }
    }
}
