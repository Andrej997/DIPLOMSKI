using MassTransit;
using RabbitMQMEssage.Events;
using System.Threading.Tasks;

namespace HotelMicroservice.Consumer
{
    public class CarValidateConsumer : IConsumer<ICarValidateEvent>
    {
        public async Task Consume(ConsumeContext<ICarValidateEvent> context)
        {
            var data = context.Message;

            if (data.HotelId == 0)
            {
                await context.Publish<ICarCancelEvent>(
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
                await context.Publish<IHotelStartedEvent>(
                    new
                    {
                        context.Message.FlightId,
                        context.Message.UserId,
                        context.Message.CarId,
                        context.Message.HotelId,
                        context.Message.PaymentId
                    });
            }

        }
    }
}
