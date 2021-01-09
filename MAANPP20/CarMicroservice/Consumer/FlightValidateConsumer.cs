using MassTransit;
using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMicroservice.Consumer
{
    public class FlightValidateConsumer : IConsumer<IFlightValidateEvent>
    {
        public async Task Consume(ConsumeContext<IFlightValidateEvent> context)
        {
            var data = context.Message;

            if (data.CarId == 0)
            {
                await context.Publish<IFlightCancelEvent>(
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
            {
                // send to next microservice
            }

        }
    }
}
