using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

// https://github.com/aspnet/Extensions/issues/1245

// IHostedService start and appstarted event
// https://github.com/aspnet/Extensions/blob/master/src/Hosting/Hosting/src/Internal/Host.cs#L47
// https://github.com/aspnet/Extensions/blob/master/src/Hosting/Hosting/src/Internal/Host.cs#L54

// BackgroundService
// https://github.com/aspnet/Extensions/blob/master/src/Hosting/Abstractions/src/BackgroundService.cs

public class Loop250ms : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Loop250ms.ExecuteAsync");
        while(!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("(loop)");
            await Task.Delay(250);
        }
        Console.WriteLine("Loop250ms.ExecuteAsync token cancelled");
    }
}
