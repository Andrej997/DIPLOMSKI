using Common.Models.Flights;
using AvioMicroservice.Data;
using AvioMicroservice.FlightInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightRepositories
{
    public class PlaneRepo : IPlane
    {
        public async Task<ActionResult<Aeroplane>> AddPlane(MAANPP20ContextFlight _context, Aeroplane aeroplane)
        {
            _context.Aeroplanes.Add(aeroplane);

            await _context.SaveChangesAsync();

            return aeroplane;
        }

        public async Task<ActionResult<Aeroplane>> DeletePlane(MAANPP20ContextFlight _context, int id)
        {
            var plane = await _context.Aeroplanes
                .Where(x => x.deleted == false)
                .FirstOrDefaultAsync(i => i.id == id);

            if (plane == null)
            {
                return null;
            }
            else if (plane.deleted == true)
            {
                return null;
            }

            plane.deleted = true;

            _context.Entry(plane).State = EntityState.Modified;

            //_context.Aeroplanes.Remove(plane);
            await _context.SaveChangesAsync();

            return plane;
        }

        public async Task<ActionResult<Aeroplane>> GetAeroplane(MAANPP20ContextFlight _context, int id)
        {
            var aeroplane = await _context.Aeroplanes
                .Where(x => x.deleted == false)
                .FirstOrDefaultAsync(i => i.id == id);

            if (aeroplane == null)
            {
                return null;
            }
            return aeroplane;
        }

        public async Task<ActionResult<IEnumerable<Aeroplane>>> GetAeroplanes(MAANPP20ContextFlight _context)
        {
            return await _context.Aeroplanes
                .Where(x => x.deleted == false)
                .ToListAsync();
        }

        public async Task<Aeroplane> UpdatePlane(MAANPP20ContextFlight _context, Aeroplane aeroplane)
        {
            _context.Entry(aeroplane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaneExists(_context, aeroplane.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return aeroplane;
        }

        private bool PlaneExists(MAANPP20ContextFlight _context, int id) => _context.Aeroplanes.Any(e => e.id == id);
    }
}
