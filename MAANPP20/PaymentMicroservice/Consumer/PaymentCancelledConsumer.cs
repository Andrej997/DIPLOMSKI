using MassTransit;
using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMicroservice.Consumer
{
    public class PaymentCancelledConsumer : IConsumer<IPaymentCancelEvent>
    {
        public async Task Consume(ConsumeContext<IPaymentCancelEvent> context)
        {
            ConsoleLogger.Log.Append("Payment", "PaymentCancelledConsumer");
            var data = context.Message;
            //_orderDataAccess.DeleteOrder(data.OrderId);
            await context.Publish<IHotelCancelEvent>(
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
