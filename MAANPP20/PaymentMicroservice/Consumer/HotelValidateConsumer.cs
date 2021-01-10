using MassTransit;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace PaymentMicroservice.Consumer
{
    public class HotelValidateConsumer : IConsumer<IHotelValidateEvent>
    {
        public async Task Consume(ConsumeContext<IHotelValidateEvent> context)
        {
            ConsoleLogger.Log.Append("Payment", "HotelValidateConsumer");
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
                        context.Message.PaymentId,
                        context.Message.price
                    });
            }

        }
    }
}
