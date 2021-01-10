using RabbitMQMEssage.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQSaga.StateMachine
{
    public class PaymentValidateEvent : IPaymentValidateEvent
    {
        private readonly FlightStateData flightSagaState;
        public PaymentValidateEvent(FlightStateData flightSagaState)
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
