using CarMicroservice.Data;
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
        private readonly MAANPP20ContextCar _context;
        public StartCarConsumer(MAANPP20ContextCar context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<IFlightStartedEvent> context)
        {
            ConsoleLogger.Log.Append("Car", "StartCarConsumer");
            var data = context.Message;

            var auto = _context.Automobiles.Where(x => x.Grad == data.grad).FirstOrDefault();
            --auto.Avaible;
            auto.Updated = DateTime.Now;
            if (auto.Avaible > 0)
            {
                _context.SaveChanges();
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
            else
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
                
        }
    }
}
