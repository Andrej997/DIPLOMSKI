using MassTransit;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace AvioMicroservice.Consumer
{
    public class FlightCancelledConsumer : IConsumer<IFlightCancelEvent>
    {
        public async Task Consume(ConsumeContext<IFlightCancelEvent> context)
        {
            ConsoleLogger.Log.Append("Avio", "FlightCancelledConsumer");
            var data = context.Message;
            //_orderDataAccess.DeleteOrder(data.OrderId);
        }
    }
}
