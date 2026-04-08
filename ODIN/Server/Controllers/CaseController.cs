using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Shared;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaseController : ControllerBase
    {
        private readonly IDoc400Service _caseService;

        public CaseController(IDoc400Service caseService)
        {
            _caseService = caseService;
        }

        [HttpGet("offender/{offenderId}")]
        public async Task<ActionResult<List<CaseDto>>> GetCases(int offenderId)
        { 
            return Ok(await _caseService.GetCaseByOffenderId(offenderId));
        }
    }
}
