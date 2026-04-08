using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Legacy.EnterpriseOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeesController : ControllerBase
    {

        // This really shouldn't be hard coded data
        // If there's time I want this to be stored in its own SQL db that can then be --
        // synced with the local OdinDB to handle paid feeds.
        private readonly List<FeeDto> _mockFees = new()
    {
        new FeeDto { Id = 501, OffenderId = 1, FeeType = "Court Costs", Amount = 150.00m, Balance = 150.00m, DueDate = DateTime.Now.AddDays(30) },
        new FeeDto { Id = 502, OffenderId = 2, FeeType = "Restitution", Amount = 500.00m, Balance = 250.00m, DueDate = DateTime.Now.AddDays(-10) },
        new FeeDto { Id = 502, OffenderId = 2, FeeType = "Drug Screen", Amount = 50.00m, Balance = 50.00m, DueDate = DateTime.Now.AddDays(-15) },
        new FeeDto { Id = 502, OffenderId = 3, FeeType = "Dameges", Amount = 5000.00m, Balance = 2500.00m, DueDate = DateTime.Now.AddYears(-1) }

    };


        // TODO eventually add PayFees endpoint
        [HttpGet("offender/{offenderId}")]
        public ActionResult<List<FeeDto>> GetFees(int offenderId)
        {
            return Ok(_mockFees.Where(f => f.OffenderId == offenderId).ToList());
        }
    }
}
