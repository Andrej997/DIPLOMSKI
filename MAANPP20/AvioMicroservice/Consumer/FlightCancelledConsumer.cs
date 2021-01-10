using AvioMicroservice.Data;
using MassTransit;
using RabbitMQMEssage.Events;
using System.Linq;
using System.Threading.Tasks;

namespace AvioMicroservice.Consumer
{
    public class FlightCancelledConsumer : IConsumer<IFlightCancelEvent>
    {
        private readonly MAANPP20ContextFlight _context;
        public FlightCancelledConsumer(MAANPP20ContextFlight context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<IFlightCancelEvent> context)
        {
            ConsoleLogger.Log.Append("Avio", "FlightCancelledConsumer");
            var data = context.Message;

           var sagaFlightReservations = _context.SagaFlightReservations
                .Where(x => x.Guid == data.FlightId)
                .FirstOrDefault();

            //var flightReservations = _context.FlightReservations
            //    .Where(x => x.id == sagaFlightReservations.Id)
            //    .FirstOrDefault();

            //_context.FlightReservations.Remove(flightReservations);

            _context.SagaFlightReservations.Remove(sagaFlightReservations);

            _context.SaveChanges();
        }
    }
}
