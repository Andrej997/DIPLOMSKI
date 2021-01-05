using AvioMicroservice.Data;
using Common.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IFastFlightReservation
    {
        Task<ActionResult<IEnumerable<FastFlightReservation>>> GetFastFlightReservations(MAANPP20ContextFlight _context, string idUser);
        Task<ActionResult<FastFlightReservation>> AddFastFlightReservations(MAANPP20ContextFlight _context, FastFlightReservation fastFlightReservation);
        Task<FastFlightReservation> UpdateFastFlightReservation(MAANPP20ContextFlight _context, FastFlightReservation fastFlightReservation);
        Task<ActionResult<FastFlightReservation>> DeleteFastFlightReservation(MAANPP20ContextFlight _context, int id);
        Task<ActionResult<IEnumerable<FastFlightReservation>>> GetFastFlightReservationsStatistics(MAANPP20ContextFlight _context, int idFlight);
    }
}
