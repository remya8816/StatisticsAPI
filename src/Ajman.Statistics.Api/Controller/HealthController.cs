using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ajman.Statistics.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class HealthController : ControllerBase  // <-- inherit ControllerBase
    {
        [HttpGet("/health")]
        [AllowAnonymous]
        public IActionResult Health()
        {
            return Ok(new
            {
                status = "Healthy",
                timestampUtc = DateTime.UtcNow,
                version = "1.0.0"
            });
        }
    }
}
