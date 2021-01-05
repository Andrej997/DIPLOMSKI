using AvioMicroservice.Data;
using Common.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IFlight
    {
        Task<ActionResult<IEnumerable<Flight>>> GetFlights(MAANPP20ContextFlight _context);
        Task<ActionResult<Flight>> GetFlight(MAANPP20ContextFlight _context, int id);
        Task<ActionResult<Flight>> GetFlightSeats(MAANPP20ContextFlight _context, int id);
        Task<ActionResult<Flight>> AddFlight(MAANPP20ContextFlight _context, Flight flight);
        Task<Flight> UpdateFlight(MAANPP20ContextFlight _context, Flight flight);
        Task<ActionResult<Flight>> DeleteFlight(MAANPP20ContextFlight _context, int id);
    }
}
