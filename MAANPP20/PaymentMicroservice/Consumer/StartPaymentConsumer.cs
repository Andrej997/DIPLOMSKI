using MassTransit;
using PaymentMicroservice.Data;
using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMicroservice.Consumer
{
    public class StartPaymentConsumer : IConsumer<IHotelStartedEvent>
    {
        private readonly MAANPP20ContextPayment _context;
        public StartPaymentConsumer(MAANPP20ContextPayment context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<IHotelStartedEvent> context)
        {
            ConsoleLogger.Log.Append("Payment", "StartPaymentConsumer");
            var data = context.Message;
            Guid newGuid = Guid.Parse(data.UserId);
            var payment = _context.Payments.Where(x => x.UserId == newGuid).FirstOrDefault();
            payment.Avaible -= data.price;
            if (payment.Avaible > 0)
            {
                payment.Updated = DateTime.Now;
                _context.SaveChanges();
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

            else // ovde ce se implementirati ako nema para
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
                
        }
    }
}
