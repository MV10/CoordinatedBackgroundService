using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CorrectUsage
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Program.Main caught {ex.GetType().Name}");
            }

            await Task.Delay(250);
        }
    }
}
