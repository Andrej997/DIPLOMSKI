using MassTransit;
using MassTransit.Definition;
using MassTransit.Saga;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using RabbitMQSaga.StateMachine;
using System;
using System.Threading.Tasks;

namespace SagaMachine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var saga = new FlightStateMachine();
            //var repo = new InMemorySagaRepository<FlightStateData>();

            //var builder = new HostBuilder()
            //   .ConfigureServices((hostContext, services) =>
            //   {
            //       services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
            //       services.AddMassTransit(cfg =>
            //       {
            //           cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider, (cfg, host) =>
            //           {
            //               cfg.ReceiveEndpoint(BusConstants.SagaBusQueue, e =>
            //               {
            //                   e.StateMachineSaga(saga, repo);
            //               });
            //           }));

            //       });
            //       services.AddMassTransitHostedService();
            //   });

            //await builder.RunConsoleAsync();
        }
    }
}
