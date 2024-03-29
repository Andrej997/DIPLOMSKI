﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.Flights;
using AvioMicroservice.Data;
using AvioMicroservice.FlightRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AvioMicroservice.Controllers.Flights
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastFlightReservationController : ControllerBase
    {
        FastFlightReservationRepo fastFlightReservationRepo = new FastFlightReservationRepo();
        private readonly MAANPP20ContextFlight _context;
        public FastFlightReservationController(MAANPP20ContextFlight context)
        {
            _context = context;
        }

        // GET: api/FastFlightReservation/546tr76f
        [HttpGet("{idUser}")]
        public async Task<ActionResult<IEnumerable<FastFlightReservation>>> GetFastFlightReservations(string idUser)
        {
            return await fastFlightReservationRepo.GetFastFlightReservations(_context, idUser);
            //return await _context.FastFlightReservations
            //    .Where(x => x.deleted == false)
            //    .Where(usersId => usersId.UserIdForPOST == idUser)
            //    .ToListAsync();
        }

        [HttpPost]
        [Route("Reserve")]
        public async Task<ActionResult<FastFlightReservation>> AddFastFlightReservations(FastFlightReservation fastFlightReservation)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (ValidateModel(fastFlightReservation, true))
            {
                var fastFlightReservationRet = await fastFlightReservationRepo.AddFastFlightReservations(_context, fastFlightReservation);
                if (fastFlightReservationRet == null) return BadRequest();
                return Ok();
                //User user = await _context.Users.Where(x => x.deleted == false)
                //    .Include(fastFlightReservations => fastFlightReservations.fastFlightReservations)
                //    .FirstOrDefaultAsync(id => id.Id == fastFlightReservation.UserIdForPOST);

                //if (user == null) return BadRequest();
                //AvioSediste avioSediste = await _context.AvioSedista
                //    .Where(x => x.deleted == false)
                //    .FirstOrDefaultAsync(id => id.id == fastFlightReservation.seatId);
                //if (avioSediste == null) return BadRequest();
                //if (avioSediste.isFastReservation == false) return BadRequest();
                //if (avioSediste.deleted == true) return BadRequest();
                //if (avioSediste.reserved == true) return BadRequest();
                //avioSediste.reserved = true;
                ////_context.Entry(avioSediste).State = EntityState.Modified;

                //bool saveFailed;
                //do
                //{
                //    saveFailed = false;
                //    try
                //    {
                //        _context.SaveChanges();
                //    }
                //    catch (DbUpdateConcurrencyException ex)
                //    {
                //        saveFailed = true;
                //        return Conflict();
                //    }
                //    catch (Exception e)
                //    {

                //        throw;
                //    }
                //} while (saveFailed);


                //user.fastFlightReservations.Add(fastFlightReservation);
                //// ako je user iskoristion svoj bonus
                //if (fastFlightReservation.userBonus == true)
                //{
                //    user.bonus = 0;
                //}
                //else
                //{
                //    // ako nije, proverava se da li je dosao do 100%?
                //    if (user.bonus < 100)
                //    {
                //        user.bonus += 1;
                //    }
                //}

                //try
                //{
                //    _context.Entry(user).State = EntityState.Modified;
                //}
                //catch (Exception e)
                //{

                //    throw;
                //}

                //_context.FastFlightReservations.Add(fastFlightReservation);



                //try
                //{
                //    await _context.SaveChangesAsync();
                //}
                //catch (Exception e)
                //{

                //    throw;
                //}
                ////await _context.SaveChangesAsync();

                //return Ok();//CreatedAtAction("GetFastFlightReservation", new { id = fastFlightReservation.id }, fastFlightReservation);
            }
            else return BadRequest();
        }

        // PUT: api/FastFlightReservation
        [HttpPut]
        public async Task<IActionResult> UpdateFastFlightReservation(FastFlightReservation fastFlightReservation)
        {
            var fastFlightReservationRet = await fastFlightReservationRepo.UpdateFastFlightReservation(_context, fastFlightReservation);
            if (fastFlightReservationRet == null) return NotFound();
            return Ok();
            //Flight flight = await _context.Flights.Where(x => x.deleted == false)
            //        .Include(ocene => ocene.ocene)
            //        .FirstOrDefaultAsync(id => id.id == fastFlightReservation.flightId);
            //if (flight == null) return BadRequest();
            //if (fastFlightReservation.ocenaLeta > 0)
            //{
            //    DoubleForICollection doubleForICollection = new DoubleForICollection();
            //    doubleForICollection.DoubleValue = fastFlightReservation.ocenaLeta;
            //    flight.ocene.Add(doubleForICollection);
            //    _context.Entry(flight).State = EntityState.Modified;
            //}

            //if (fastFlightReservation.ocenaKompanije > 0)
            //{
            //    FlightCompany flightCompany = await _context.FlightCompanies.Where(x => x.deleted == false)
            //        .Include(ocene => ocene.ocene)
            //        .FirstOrDefaultAsync(id => id.id == flight.idCompany);
            //    if (flightCompany == null) return BadRequest();
            //    DoubleForICollection doubleForICollection = new DoubleForICollection();
            //    doubleForICollection.DoubleValue = fastFlightReservation.ocenaKompanije;
            //    flightCompany.ocene.Add(doubleForICollection);
            //    _context.Entry(flightCompany).State = EntityState.Modified;
            //}

            //_context.Entry(fastFlightReservation).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FastFlightReservationExists(fastFlightReservation.id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return Ok();
        }

        // DELETE: api/FastFlightReservation/DeleteFFR/1
        [HttpDelete]
        [Route("DeleteFFR/{id}")]
        public async Task<ActionResult<FastFlightReservation>> DeleteFastFlightReservation(int id)
        {
            var fastFlightReservation = await fastFlightReservationRepo.DeleteFastFlightReservation(_context, id);
            if (fastFlightReservation == null) return NotFound();
            return Ok();
            //var fastFlightReservation = await _context.FastFlightReservations
            //    .Where(x => x.deleted == false)
            //    .FirstOrDefaultAsync(i => i.id == id);
            //if (fastFlightReservation == null)
            //{
            //    return NotFound();
            //}
            //else if (fastFlightReservation.deleted == true)
            //{
            //    return NotFound();
            //}

            //AvioSediste avioSediste = await _context.AvioSedista
            //        .Where(x => x.deleted == false)
            //        .FirstOrDefaultAsync(id => id.id == fastFlightReservation.seatId);
            //if (avioSediste == null) return BadRequest();
            //if (avioSediste.isFastReservation == false) return BadRequest();
            //if (avioSediste.deleted == true) return BadRequest();
            //if (avioSediste.reserved == false) return BadRequest();
            //avioSediste.reserved = false;
            //_context.Entry(avioSediste).State = EntityState.Modified;

            //fastFlightReservation.deleted = true;

            //_context.Entry(fastFlightReservation).State = EntityState.Modified;

            //await _context.SaveChangesAsync();

            //return Ok();
        }

        private bool FastFlightReservationExists(int id) => _context.FastFlightReservations.Any(e => e.id == id);

        private bool ValidateModel(FastFlightReservation fastFlightReservation, bool isPost)
        {
            if (fastFlightReservation.ocenaLeta < 0 && isPost == true) return false; 
            if (fastFlightReservation.ocenaKompanije < 0 && isPost == true) return false; 
            if (fastFlightReservation.flightId < 1) return false;
            if (fastFlightReservation.UserIdForPOST == null || fastFlightReservation.UserIdForPOST == "") return false;
            if (fastFlightReservation.price <= 0) return false;
            if (fastFlightReservation.seatNumeration <= 0) return false;

            return true;
        }

        [HttpGet("Statistics/{idFlight}")]
        public async Task<ActionResult<IEnumerable<FastFlightReservation>>> GetFastFlightReservationsStatistics(int idFlight)
        {
            return await fastFlightReservationRepo.GetFastFlightReservationsStatistics(_context, idFlight);
            //return await _context.FastFlightReservations
            //    .Where(x => x.deleted == false)
            //    .Where(id => id.flightId == idFlight)
            //    .ToListAsync();
        }
    }
}