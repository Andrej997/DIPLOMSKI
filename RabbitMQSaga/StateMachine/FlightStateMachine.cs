using Automatonymous;
using RabbitMQMEssage.Events;
using System;

namespace RabbitMQSaga.StateMachine
{
    public class FlightStateMachine : MassTransitStateMachine<FlightStateData>
    {
        public State FlightStarted { get; private set; }
        public State FlightCancelled { get; private set; }
        public Event<IFlightStartedEvent> FlightStartedEvent { get; private set; }
        public Event<IFlightCancelEvent> FlightCancelledEvent { get; private set; }

        public State CarStarted { get; private set; }
        public State CarCancelled { get; private set; }
        public Event<ICarStartedEvent> CarStartedEvent { get; private set; }
        public Event<ICarCancelEvent> CarCancelledEvent { get; private set; }

        public State HotelStarted { get; private set; }
        public State HotelCancelled { get; private set; }
        public Event<IHotelStartedEvent> HotelStartedEvent { get; private set; }
        public Event<IHotelCancelEvent> HotelCancelledEvent { get; private set; }

        public State Completed { get; private set; }
        public State PaymentCancelled { get; private set; }
        public Event<IPaymentStartedEvent> PaymentStartedEvent { get; private set; }
        public Event<IPaymentCancelEvent> PaymentCancelledEvent { get; private set; }

        public FlightStateMachine()
        {
            Event(() => FlightStartedEvent, x => x.CorrelateById(m => m.Message.FlightId));
            Event(() => FlightCancelledEvent, x => x.CorrelateById(m => m.Message.FlightId));

            Event(() => CarStartedEvent, x => x.CorrelateById(m => m.Message.FlightId));
            Event(() => CarCancelledEvent, x => x.CorrelateById(m => m.Message.FlightId));

            Event(() => HotelStartedEvent, x => x.CorrelateById(m => m.Message.FlightId));
            Event(() => HotelCancelledEvent, x => x.CorrelateById(m => m.Message.FlightId));

            Event(() => PaymentStartedEvent, x => x.CorrelateById(m => m.Message.FlightId));
            Event(() => PaymentCancelledEvent, x => x.CorrelateById(m => m.Message.FlightId));

            InstanceState(x => x.CurrentState);

            Initially(
               When(FlightStartedEvent)
                .Then(context =>
                {
                    context.Instance.FlightCreationDateTime = DateTime.Now;
                    context.Instance.FlightId = context.Data.FlightId;
                    context.Instance.CarId = context.Data.CarId;
                    context.Instance.HotelId = context.Data.HotelId;
                    context.Instance.PaymentId = context.Data.PaymentId;
                    context.Instance.UserId = context.Data.UserId;
                })
               .TransitionTo(FlightStarted)
               .Publish(context => new FlightValidateEvent(context.Instance)));

            During(FlightStarted,
                When(FlightCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(FlightCancelled));
            
            // --------------------------------------------------

            During(FlightStarted,
                When(CarStartedEvent)
                    .TransitionTo(CarStarted)
                     .Publish(context => new CarValidateEvent(context.Instance)));
            

            During(CarStarted,
                When(CarCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(CarCancelled));

            During(CarCancelled,
                When(FlightCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(FlightCancelled));

            // ---------------------------------------------------

            During(CarStarted,
                When(HotelStartedEvent)
                    .TransitionTo(HotelStarted)
                     .Publish(context => new HotelValidateEvent(context.Instance)));

            During(HotelStarted,
                When(HotelCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(HotelCancelled));

            During(HotelCancelled,
                When(CarCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(CarCancelled));

            During(CarCancelled,
                When(FlightCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(FlightCancelled));

            // ---------------------------------------------------

            During(HotelStarted,
               When(PaymentStartedEvent)
                   .TransitionTo(Completed)
                    .Publish(context => new PaymentValidateEvent(context.Instance)));

            During(Completed,
               When(PaymentCancelledEvent)
               .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                   .TransitionTo(HotelCancelled));

            During(HotelCancelled,
                When(CarCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(CarCancelled));

            During(CarCancelled,
                When(FlightCancelledEvent)
                    .Then(context => context.Instance.FlightCancelDateTime = DateTime.Now)
                     .TransitionTo(FlightCancelled));
        }
    }
}
