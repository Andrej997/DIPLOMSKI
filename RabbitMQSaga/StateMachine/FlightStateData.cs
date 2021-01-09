using Automatonymous;
using System;

namespace RabbitMQSaga.StateMachine
{
    public class FlightStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? CancelDateTime { get; set; }
        public string UserId { get; set; }
        public Guid FlightId { get; set; }
        public int CarId { get; set; }
        public int HotelId { get; set; }
        public int PaymentId { get; set; }
    }
}
