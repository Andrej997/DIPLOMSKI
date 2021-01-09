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

        public FlightSagaController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> CreateFlightUsingStateMachineInDb()
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.StartOrderTranastionQueue));

            //_orderDataAccess.SaveOrder(orderModel);

            await endpoint.Send<IStartFlight>(new
            {
                UserId = Guid.NewGuid().ToString(),
                FlightId = Guid.NewGuid().ToString(),
                CarId = 1,
                HotelId = 1,
                PaymentId = 1
            });

            return Ok("Success");
        }
    }
}