using AvioMicroservice.Data;
using Common.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IFlightDestination
    {
        Task<ActionResult<FlightDestination>> GetFlightDestination(MAANPP20ContextFlight _context, int id);
        Task<ActionResult<FlightDestination>> AddFlightCompany(MAANPP20ContextFlight _context, FlightDestination flightDestination);
        Task<FlightDestination> UpdateFlightCompany(MAANPP20ContextFlight _context, FlightDestination flightDestination);
        Task<ActionResult<FlightDestination>> DeleteFlightDestination(MAANPP20ContextFlight _context, int id);
    }
}
