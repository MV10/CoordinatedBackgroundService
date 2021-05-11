using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WithCoordinatedService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
            .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning))
            .UseConsoleLifetime() // Ctrl+C support
            .ConfigureServices((ctx, svc) =>
            {
                svc.AddHostedService<Loop250ms>();
                svc.AddHostedService<Run5sec>();
            })
            .RunConsoleAsync();
        }

    }
}
