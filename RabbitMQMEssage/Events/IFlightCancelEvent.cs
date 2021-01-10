using System;

namespace RabbitMQMEssage.Events
{
    public interface IFlightCancelEvent
    {
        public string UserId { get; }

        public Guid FlightId { get; }

        public int CarId { get; }

        public int HotelId { get; }

        public int PaymentId { get; }

        public double price { get; }

        public string grad { get; }
    }
}
