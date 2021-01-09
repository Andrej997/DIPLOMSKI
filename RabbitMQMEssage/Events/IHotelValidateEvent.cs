using System;

namespace RabbitMQMEssage.Events
{
    public interface IHotelValidateEvent
    {
        public string UserId { get; }

        public Guid FlightId { get; }

        public int CarId { get; }

        public int HotelId { get; }

        public int PaymentId { get; }
    }
}
