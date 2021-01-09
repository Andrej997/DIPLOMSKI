using MassTransit;
using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMicroservice.Consumer
{
    public class StartHotelConsumer : IConsumer<ICarStartedEvent>
    {
        public async Task Consume(ConsumeContext<ICarStartedEvent> context)
        {
            await context.Publish<IHotelStartedEvent>(new
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
