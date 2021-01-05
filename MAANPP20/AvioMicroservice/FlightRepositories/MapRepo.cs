using Common.Models.Common;
using AvioMicroservice.Data;
using AvioMicroservice.FlightInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightRepositories
{
    public class MapRepo : IMap
    {
        public async Task<ActionResult<Address>> GetFlightCompanyAddress(MAANPP20ContextFlight _context, int id)
        {
            var flightCompany = await _context.FlightCompanies
                 .Include(address => address.address)
                 .FirstOrDefaultAsync(i => i.id == id);

            if (flightCompany == null)
            {
                return null;
            }
            else if (flightCompany.deleted == true)
            {
                return null;
            }

            return flightCompany.address;
        }
    }
}
