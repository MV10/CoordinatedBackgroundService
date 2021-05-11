using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Run5sec : CoordinatedBackgroundService
{
    public Run5sec(IHostApplicationLifetime appLifetime)
        :base(appLifetime)
    { }

    protected override Task InitializingAsync(CancellationToken cancelInitToken)
    {
        Console.WriteLine("Run5sec.InitializingAsync");
        return Task.CompletedTask;
    }

    protected override async Task ExecuteAsync(CancellationToken appStoppingToken)
    {
        try
        {
            Console.WriteLine("Run5sec.ExecuteAsync");
            for (int i = 5; i > 0; i--)
            {
                appStoppingToken.ThrowIfCancellationRequested();
                Console.WriteLine($"tick {i}");
                await Task.Delay(1000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Run5sec caught {ex.GetType().Name}");
        }
        finally
        {
            Console.WriteLine("Run5sec calling StopApplication");
            appLifetime.StopApplication(); // inherited
        }
    }

    protected override Task StoppingAsync(CancellationToken cancelStopToken)
    {
        Console.WriteLine("Run5sec.StoppingAsync");
        return Task.CompletedTask;
    }
}
