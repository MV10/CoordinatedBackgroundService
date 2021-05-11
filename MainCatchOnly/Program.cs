using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// still crashes, exception does not propagate

// could use a trick like this to capture the exception, but do what with it?
// https://devblogs.microsoft.com/pfxteam/tasks-and-unhandled-exceptions/

// https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskscheduler.unobservedtaskexception?view=netcore-3.1
// https://github.com/dotnet/corefx/issues/24705
// https://stackoverflow.com/questions/3284137/taskscheduler-unobservedtaskexception-event-handler-never-being-triggered/3284286#3284286
// https://www.reddit.com/r/csharp/comments/7rixw6/unobservedtaskexception_what_am_i_missing_why_is/
// https://devblogs.microsoft.com/pfxteam/tasks-and-unhandled-exceptions/


namespace MainCatchOnly
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
        }
    }
}
