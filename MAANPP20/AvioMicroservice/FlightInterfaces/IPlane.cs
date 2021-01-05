using Common.Models.Flights;
using AvioMicroservice.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IPlane
    {
        Task<ActionResult<IEnumerable<Aeroplane>>> GetAeroplanes(MAANPP20ContextFlight _context);

        Task<ActionResult<Aeroplane>> GetAeroplane(MAANPP20ContextFlight _context, int id);

        Task<ActionResult<Aeroplane>> AddPlane(MAANPP20ContextFlight _context, Aeroplane aeroplane);

        Task<Aeroplane> UpdatePlane(MAANPP20ContextFlight _context, Aeroplane aeroplane);

        Task<ActionResult<Aeroplane>> DeletePlane(MAANPP20ContextFlight _context, int id);
    }
}
