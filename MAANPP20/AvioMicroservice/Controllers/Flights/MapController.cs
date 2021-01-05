using System.Threading.Tasks;
using Common.Models.Common;
using AvioMicroservice.Data;
using AvioMicroservice.FlightRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AvioMicroservice.Controllers.Flights
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private MapRepo mapRepo = new MapRepo();
        private readonly MAANPP20ContextFlight _context;

        public MapController(MAANPP20ContextFlight context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetFlightCompanyAddress(int id)
        {
            return await mapRepo.GetFlightCompanyAddress(_context, id);
        }
    }
}