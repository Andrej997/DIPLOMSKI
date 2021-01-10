using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMicroservice.Consumer
{
    public class StartCarConsumer : IConsumer<IFlightStartedEvent>
    {
        public async Task Consume(ConsumeContext<IFlightStartedEvent> context)
        {
            ConsoleLogger.Log.Append("Car", "StartCarConsumer");
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
                       context.Message.price,
                       context.Message.grad
                   });
            }
            else
            {
                await context.Publish<ICarStartedEvent>(new
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
}
