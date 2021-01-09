using MassTransit.EntityFrameworkCoreIntegration;
using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RabbitMQSaga.DbConfiguration
{
    public class FlightStateDbContext : SagaDbContext
    {
        public FlightStateDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get { yield return new FlightStateMap(); }
        }
    }
}
