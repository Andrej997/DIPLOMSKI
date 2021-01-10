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
            ConsoleLogger.Log.Append("Car", "FlightValidateConsumer");
            var data = context.Message;

            if (data.CarId == 1)
            {
                await context.Publish<IFlightCancelEvent>(
                    new
                    {
                        context.Message.FlightId,
                        context.Message.UserId,
                        context.Message.CarId,
                        context.Message.HotelId,
                        context.Message.PaymentId,
                        context.Message.price
                    });
            }
            else
            {
                await context.Publish<ICarStartedEvent>(
                    new
                    {
                        context.Message.FlightId,
                        context.Message.UserId,
                        context.Message.CarId,
                        context.Message.HotelId,
                        context.Message.PaymentId,
                        context.Message.price
                    });
            }

        }
    }
}
