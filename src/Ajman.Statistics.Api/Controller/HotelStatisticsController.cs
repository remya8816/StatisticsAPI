using Ajman.Statistics.Application.Interfaces;
using Ajman.Statistics.Domain.Entities;
using Ajman.Statistics.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ajman.Statistics.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/hotel-statistics")]
    public class HotelStatisticsController : ControllerBase
    {
        private readonly IHotelStatsService _service;

        public HotelStatisticsController(IHotelStatsService service)
        {
            _service = service;
        }

        [HttpGet("inventory")]
        public async Task<IActionResult> GetInventory([FromQuery] HotelInventoryQuery query)
        {
            var result = await _service.GetInventoryAsync(query);
            return Ok(result);
        }
    }
}
