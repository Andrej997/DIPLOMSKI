using AvioMicroservice.Data;
using Common.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.Common;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IFlightReservation
    {
        Task<ActionResult<IEnumerable<FlightReservation>>> GetFlightReservations(MAANPP20ContextFlight _context, string idUser);
        Task<ActionResult<FlightReservation>> AddFlightReservation(MAANPP20ContextFlight _context, FlightReservation flightReservation);
        Task<FlightReservation> UpdateFlightReservation(MAANPP20ContextFlight _context, FlightReservation flightReservation);
        Task<ActionResult<FlightReservation>> DeleteFlightReservation(MAANPP20ContextFlight _context, int id);
        Task<FriendForFlight> AcceptFriendForFlight(MAANPP20ContextFlight _context, StringForICollection invitationString);
        Task<FriendForFlight> DeclineFriendForFlight(MAANPP20ContextFlight _context, string invitationString);
        Task<ActionResult<IEnumerable<FriendForFlight>>> GetCallsForFlight(MAANPP20ContextFlight _context, string email);
        Task<ActionResult<IEnumerable<FlightReservation>>> GetFlightReservationsStatistics(MAANPP20ContextFlight _context, int idFlight);
    }
}
