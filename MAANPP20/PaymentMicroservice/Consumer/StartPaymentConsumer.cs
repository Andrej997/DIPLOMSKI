using MassTransit;
using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMicroservice.Consumer
{
    public class StartPaymentConsumer : IConsumer<IHotelStartedEvent>
    {
        public async Task Consume(ConsumeContext<IHotelStartedEvent> context)
        {
            ConsoleLogger.Log.Append("Payment", "StartPaymentConsumer");
            var data = context.Message;
            if (data.CarId == 3) // ovde ce se implementirati ako nema para
            {
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
            else // Completed
                await context.Publish<IPaymentStartedEvent>(new
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
