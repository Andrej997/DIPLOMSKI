using MassTransit;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace HotelMicroservice.Consumer
{
    public class CarValidateConsumer : IConsumer<ICarValidateEvent>
    {
        public async Task Consume(ConsumeContext<ICarValidateEvent> context)
        {
            ConsoleLogger.Log.Append("Hotel", "CarValidateConsumer");
            var data = context.Message;

            if (data.CarId == 2)
            {
                await context.Publish<ICarCancelEvent>(
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
                await context.Publish<IHotelStartedEvent>(
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
