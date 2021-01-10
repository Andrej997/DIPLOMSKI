using System;
using System.Threading.Tasks;
using AvioMicroservice.Data;
using Common.Models.Flights;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQMEssage;
using RabbitMQMEssage.BusConfiguration;

namespace AvioMicroservice.Controllers
{
    /// <summary>
    /// This controller is only for initial dev purpose
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlightSagaController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly MAANPP20ContextFlight _context;
        public FlightSagaController(ISendEndpointProvider sendEndpointProvider, MAANPP20ContextFlight context)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _context = context;
        }

        [HttpPost]
        [Route("reserve")]
        public async Task<IActionResult> CreateFlightUsingStateMachineInDb(SagaFlightReservation reservation)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.StartOrderTranastionQueue));

            _context.SagaFlightReservations.Add(reservation);
            _context.SaveChanges();

            await endpoint.Send<IStartFlight>(new
            {
                UserId = reservation.UserId,
                FlightId = reservation.Guid,
                CarId = 0,
                HotelId = 0,
                PaymentId = 0,
                price = reservation.Cena,
                grad = reservation.Grad
            });

            return Ok("Success");
        }
    }
}