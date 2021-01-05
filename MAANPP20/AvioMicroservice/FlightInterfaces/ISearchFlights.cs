using Common.Models.Flights;
using AvioMicroservice.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface ISearchFlights
    {
        Task<ActionResult<IEnumerable<FlightCompany>>> GetFlightCompany(MAANPP20ContextFlight _context, SearchFlight search);
        Task<ActionResult<IEnumerable<Flight>>> GetFlights(MAANPP20ContextFlight _context, SearchFlight search);
    }
}
