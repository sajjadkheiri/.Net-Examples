
namespace Net_Example.Platform;

/// <summary>
/// Hosted service is a long running task that excuting by CreateBuilder()
/// in Program.cs
/// </summary>
public class MyHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
