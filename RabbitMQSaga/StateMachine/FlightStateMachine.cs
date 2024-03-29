﻿using Automatonymous;
using RabbitMQMEssage.Events;
using System;

namespace RabbitMQSaga.StateMachine
{
    public class FlightStateMachine : MassTransitStateMachine<FlightStateData>
    {
        public State FlightStarted { get; private set; }
        public State Cancelled { get; private set; }
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
                    context.Instance.CreationDateTime = DateTime.Now;
                    context.Instance.FlightId = context.Data.FlightId;
                    context.Instance.UserId = context.Data.UserId;
                    context.Instance.CarId = context.Data.CarId;
                    context.Instance.HotelId = context.Data.HotelId;
                    context.Instance.PaymentId = context.Data.PaymentId;
                    context.Instance.price = context.Data.price;
                    context.Instance.grad = context.Data.grad;
                })
               .TransitionTo(FlightStarted));

            During(FlightStarted,
                When(CarStartedEvent)
                    .TransitionTo(CarStarted),
                When(FlightCancelledEvent)
                    .Then(context => context.Instance.CancelDateTime = DateTime.Now)
                    .TransitionTo(Cancelled)
                );

            During(CarStarted,
                When(HotelStartedEvent)
                    .TransitionTo(HotelStarted),
                 When(FlightCancelledEvent)
                    .Then(context => context.Instance.CancelDateTime = DateTime.Now)
                    .TransitionTo(Cancelled) // mena auto baci na flight cancel
                );

            During(HotelStarted,
                When(PaymentStartedEvent)
                    .TransitionTo(Completed),
                When(CarCancelledEvent)
                    .Then(context => context.Instance.CancelDateTime = DateTime.Now)
                    .TransitionTo(CarCancelled) // mena hotela baci na car cancel
                );

            During(CarCancelled,
                When(FlightCancelledEvent)
                    .Then(context => context.Instance.CancelDateTime = DateTime.Now)
                    .TransitionTo(Cancelled)); // ponistio si auto, baci na flight cancel

            During(Completed,
                When(HotelCancelledEvent)
                    .Then(context => context.Instance.CancelDateTime = DateTime.Now)
                    .TransitionTo(HotelCancelled)); // greska u zavrsnom trenutku, baci na hotel

            During(HotelCancelled,
                When(CarCancelledEvent)
                    .Then(context => context.Instance.CancelDateTime = DateTime.Now)
                    .TransitionTo(CarCancelled)); // ponistio si hotel, baci na car cancel
        }
    }
}
