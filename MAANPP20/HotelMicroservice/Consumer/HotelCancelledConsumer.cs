using HotelMicroservice.Data;
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
        private readonly MAANPP20ContextHotel _context;
        public HotelCancelledConsumer(MAANPP20ContextHotel context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<IHotelCancelEvent> context)
        {
            ConsoleLogger.Log.Append("Hotel", "HotelCancelledConsumer");
            var data = context.Message;

            var hotel = _context.Hotels.Where(x => x.Grad == data.grad).FirstOrDefault();
            ++hotel.Avaible;
            hotel.Updated = DateTime.Now;
            _context.SaveChanges();

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
