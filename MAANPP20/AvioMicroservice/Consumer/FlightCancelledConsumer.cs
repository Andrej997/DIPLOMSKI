using MassTransit;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace AvioMicroservice.Consumer
{
    public class FlightCancelledConsumer : IConsumer<IFlightCancelEvent>
    {
        public async Task Consume(ConsumeContext<IFlightCancelEvent> context)
        {
            var data = context.Message;
            //_orderDataAccess.DeleteOrder(data.OrderId);
        }
    }
}
