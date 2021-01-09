using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RabbitMQSaga.StateMachine;

namespace RabbitMQSaga.DbConfiguration
{
    public class FlightStateMap : SagaClassMap<FlightStateData>
    {
        protected override void Configure(EntityTypeBuilder<FlightStateData> entity, ModelBuilder model)
        {
            entity.Property(x => x.CurrentState).HasMaxLength(64);
            entity.Property(x => x.CreationDateTime);
        }
    }
}
