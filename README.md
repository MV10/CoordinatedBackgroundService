# CoordinatedBackgroundService [![NuGet](https://img.shields.io/nuget/v/CoordinatedBackgroundService.svg)](https://nuget.org/packages/CoordinatedBackgroundService)

Repository for my `CoordinatedBackgroundService` package and the related article:

### 2020-Jan-05: [Lifecycle of Generic Host Background Services](https://mcguirev10.com/2020/01/05/lifecycle-of-generic-host-background-services.html)

### Purpose

A replacement for the .NET `IHostedService` which provides a separate initialization phase, distinct from the service startup phase. This can prevent startup race conditions in dependent services. Detailed examples are available in the article.

### Usage

Create and host a class which derives from the `CoordinatedBackgroundService` base class, which is in the _Microsoft.Extensions.Hosting_ namespace. At a minimum, you probably want to override `InitializingAsync` and `ExecuteAsync`, and maybe `StoppingAsync`.

If your service needs to initiate application shutdown, inject `IHostApplicationLifetime` into the constructor and call `StopApplication` where necessary.

Since these services execute on unmonitored threads, it is absolutely necessary to handle _all_ exceptions. Any unhandled exceptions will immediately terminate the application.