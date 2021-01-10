using HotelMicroservice.Data;
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
        private readonly MAANPP20ContextHotel _context;
        public StartHotelConsumer(MAANPP20ContextHotel context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<ICarStartedEvent> context)
        {
            ConsoleLogger.Log.Append("Hotel", "StartHotelConsumer");
            var data = context.Message;

            var hotel = _context.Hotels.Where(x => x.Grad == data.grad).FirstOrDefault();
            --hotel.Avaible;
            hotel.Updated = DateTime.Now;
            if (hotel.Avaible > 0)
            {
                _context.SaveChanges();
                await context.Publish<IHotelStartedEvent>(new
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
}
