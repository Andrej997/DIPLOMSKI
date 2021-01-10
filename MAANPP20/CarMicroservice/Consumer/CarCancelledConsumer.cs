using CarMicroservice.Data;
using MassTransit;
using RabbitMQMEssage.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarMicroservice.Consumer
{
    public class CarCancelledConsumer : IConsumer<ICarCancelEvent>
    {
        private readonly MAANPP20ContextCar _context;
        public CarCancelledConsumer(MAANPP20ContextCar context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<ICarCancelEvent> context)
        {
            ConsoleLogger.Log.Append("Car", "CarCancelledConsumer");
            var data = context.Message;

            var auto = _context.Automobiles.Where(x => x.Grad == data.grad).FirstOrDefault();
            ++auto.Avaible;
            auto.Updated = DateTime.Now;
            _context.SaveChanges();
            
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
