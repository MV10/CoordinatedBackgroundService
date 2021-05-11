using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Loop250ms : CoordinatedBackgroundService
{
    public Loop250ms(IHostApplicationLifetime appLifetime)
        : base(appLifetime)
    { }

    protected override Task InitializingAsync(CancellationToken cancelInitToken)
    {
        Console.WriteLine("Loop250ms.InitializingAsync");
        return Task.CompletedTask;
    }

    protected override async Task ExecuteAsync(CancellationToken appStoppingToken)
    {
        try
        {
            Console.WriteLine("Loop250ms.ExecuteAsync");
            while (true)
            {
                appStoppingToken.ThrowIfCancellationRequested();
                Console.WriteLine("(loop)");
                await Task.Delay(250);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loop250ms caught {ex.GetType().Name}");
        }
        finally
        {
            Console.WriteLine("Loop250ms exiting");
        }
    }

    protected override Task StoppingAsync(CancellationToken cancelStopToken)
    {
        Console.WriteLine("Loop250ms.StoppingAsync");
        return Task.CompletedTask;
    }
}
