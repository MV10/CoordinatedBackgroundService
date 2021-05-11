using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Run5sec : BackgroundService
{
    private readonly IHostApplicationLifetime appLifetime;

    public Run5sec(IHostApplicationLifetime appLifetime)
    {
        this.appLifetime = appLifetime;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Run5sec.ExecuteAsync");
        for (int i = 5; i > 0; i--)
        {
            if (stoppingToken.IsCancellationRequested) break;
            Console.WriteLine($"tick {i}");
            await Task.Delay(1000);
        }
        Console.WriteLine("Run5sec calling StopApplication");
        appLifetime.StopApplication();
    }
}
