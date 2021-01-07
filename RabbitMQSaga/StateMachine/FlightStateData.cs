using Automatonymous;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQSaga.StateMachine
{
    public class FlightStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? OrderCreationDateTime { get; set; }
        public DateTime? OrderCancelDateTime { get; set; }
        public int FligtId { get; set; }
    }
}
