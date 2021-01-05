using Common.Models.Common;
using AvioMicroservice.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IMap
    {
        Task<ActionResult<Address>> GetFlightCompanyAddress(MAANPP20ContextFlight _context, int id);
    }
}
