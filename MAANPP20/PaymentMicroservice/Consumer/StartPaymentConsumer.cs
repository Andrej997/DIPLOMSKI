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
            var data = context.Message;
            if (data.PaymentId == 0) // ovde ce se implementirati ako nema para
            {
                await context.Publish<IHotelCancelEvent>(
                    new
                    {
                        context.Message.FlightId,
                        context.Message.UserId,
                        context.Message.CarId,
                        context.Message.HotelId,
                        context.Message.PaymentId
                    });
            }
            else 
            await context.Publish<IPaymentStartedEvent>(new
            {
                context.Message.UserId,
                context.Message.FlightId,
                context.Message.CarId,
                context.Message.HotelId,
                context.Message.PaymentId
            });
        }
    }
}
