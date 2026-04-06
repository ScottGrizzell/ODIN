using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Services;
using Shared;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffenderController : ControllerBase
    {
        private readonly IOffenderService _offenderService;

        public OffenderController(IOffenderService offenderService)
        {
            {
                _offenderService = offenderService;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OffenderDto>> GetOffender(int id)
        {
            var offender = await _offenderService.GetOffenderByIdAsync(id);
            if(offender == null)
            {
                return NotFound();
            }
            return Ok(offender);
        }
        
    }
}
