using RabbitMQMEssage.Events;
using System;

namespace RabbitMQSaga.StateMachine
{
    public class FlightValidateEvent : IFlightValidateEvent
    {
        private readonly FlightStateData flightSagaState;
        public FlightValidateEvent(FlightStateData flightSagaState)
        {
            this.flightSagaState = flightSagaState;
        }

        public string UserId => flightSagaState.UserId;
        public Guid FlightId => flightSagaState.FlightId;
        public int CarId => flightSagaState.CarId;
        public int HotelId => flightSagaState.HotelId;
        public int PaymentId => flightSagaState.PaymentId;
        public double price => flightSagaState.price;
        public string grad => flightSagaState.grad;
    }
}
