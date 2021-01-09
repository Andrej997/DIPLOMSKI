using MassTransit;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace CarMicroservice.Consumer
{
    public class CarCancelledConsumer : IConsumer<ICarCancelEvent>
    {
        public async Task Consume(ConsumeContext<ICarCancelEvent> context)
        {
            var data = context.Message;
            //_orderDataAccess.DeleteOrder(data.OrderId);
        }
    }
}
