using AvioMicroservice.Data;
using Common.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IFlightCompany
    {
        Task<ActionResult<IEnumerable<FlightCompany>>> GetFlightCompany(MAANPP20ContextFlight _context);
        Task<ActionResult<FlightCompany>> GetFlightCompany(MAANPP20ContextFlight _context, int id);
        Task<ActionResult<FlightCompany>> AddFlightCompany(MAANPP20ContextFlight _context, FlightCompany flightCompany);
        Task<FlightCompany> UpdateFlightCompany(MAANPP20ContextFlight _context, FlightCompany flightCompany);
        Task<ActionResult<FlightCompany>> DeleteFlightCompany(MAANPP20ContextFlight _context, int id);
        Task<ActionResult<int>> GetUsersFlightCompanyId(MAANPP20ContextFlight _context, string id);
    }
}
