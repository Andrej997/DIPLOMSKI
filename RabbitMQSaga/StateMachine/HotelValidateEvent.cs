using System;

namespace RabbitMQSaga.StateMachine
{
    public class HotelValidateEvent
    {
        private readonly FlightStateData flightSagaState;
        public HotelValidateEvent(FlightStateData flightSagaState)
        {
            this.flightSagaState = flightSagaState;
        }

        public string UserId => flightSagaState.UserId;
        public Guid FlightId => flightSagaState.FlightId;
        public int CarId => flightSagaState.CarId;
        public int HotelId => flightSagaState.HotelId;
        public int PaymentId => flightSagaState.PaymentId;
    }
}
