using AvioMicroservice.Data;
using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitMQMEssage;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace AvioMicroservice.Consumer
{
    public class StartFlightConsumer : IConsumer<IStartFlight>
    {
        private readonly MAANPP20ContextFlight _context;
        public StartFlightConsumer(MAANPP20ContextFlight context)
        {
            _context = context;
        }

        public StartFlightConsumer() { }

        public async Task Consume(ConsumeContext<IStartFlight> context)
        {
            ConsoleLogger.Log.Append("Avio", "StartFlightConsumer");
            var data = context.Message;

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
