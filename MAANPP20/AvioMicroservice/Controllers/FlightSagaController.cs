using System;
using System.Threading.Tasks;
using AvioMicroservice.Data;
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

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> CreateFlightUsingStateMachineInDb(int id)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.StartOrderTranastionQueue));

            var reservationGuid = Guid.NewGuid();

            _context.SagaFlightReservations.Add(new Common.Models.Flights.SagaFlightReservation
            {
                Guid = reservationGuid,
                UserId = Guid.Parse("108C6CD3-DFBC-45D6-A5C0-D42DCCFFA4DD"),
                Id = id
            });

            _context.SaveChanges();

            await endpoint.Send<IStartFlight>(new
            {
                UserId = "108C6CD3-DFBC-45D6-A5C0-D42DCCFFA4DD",
                FlightId = reservationGuid.ToString(),
                CarId = 0,
                HotelId = 0,
                PaymentId = 0,
                price = 68.1,
                grad = "Belgrade"
            });

            return Ok("Success");
        }
    }
}