using MessageBrokerPublisher;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobScheduler
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            

            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<INotificationSender, NotificationSender>();
                    services.AddScoped<IConfig, Config>();
                    services.AddScoped<IApiRequestHandler, ApiRequestHandler>();
                    services.AddHostedService<GraduationWorker>();
                });
    }
}