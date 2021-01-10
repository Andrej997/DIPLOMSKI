using MassTransit;
using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMicroservice.Consumer
{
    public class HotelCancelledConsumer : IConsumer<IHotelCancelEvent>
    {
        public async Task Consume(ConsumeContext<IHotelCancelEvent> context)
        {
            ConsoleLogger.Log.Append("Hotel", "HotelCancelledConsumer");
            var data = context.Message;
            //_orderDataAccess.DeleteOrder(data.OrderId);
            await context.Publish<ICarCancelEvent>(
                     new
                     {
                         context.Message.FlightId,
                         context.Message.UserId,
                         context.Message.CarId,
                         context.Message.HotelId,
                         context.Message.PaymentId,
                         context.Message.price,
                         context.Message.grad
                     });
        }
    }
}
