using System;

namespace RabbitMQMEssage.Events
{
    public interface IFlightStartedEvent
    {
        public string UserId { get; set; }

        public Guid FlightId { get; set; }

        public int CarId { get; set; }

        public int HotelId { get; set; }

        public int PaymentId { get; set; }

        public double price { get; set; }
    }
}
