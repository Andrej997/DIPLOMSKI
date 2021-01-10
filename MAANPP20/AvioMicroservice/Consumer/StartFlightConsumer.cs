using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitMQMEssage;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace AvioMicroservice.Consumer
{
    public class StartFlightConsumer : IConsumer<IStartFlight>
    {
        readonly ILogger<StartFlightConsumer> _logger;

        public StartFlightConsumer() { }
        public StartFlightConsumer(ILogger<StartFlightConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IStartFlight> context)
        {
            ConsoleLogger.Log.Append("Avio", "StartFlightConsumer");
            _logger.LogInformation("--Application Event-- Order Transation Started and event published: {FlightId}", context.Message.FlightId);

            await context.Publish<IFlightStartedEvent>(new
            {
                context.Message.UserId,
                context.Message.FlightId,
                context.Message.CarId,
                context.Message.HotelId,
                context.Message.PaymentId,
                context.Message.price,
                context.Message.grad
            });
        }
    }
}
