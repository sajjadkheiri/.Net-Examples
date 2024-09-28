namespace Net_Example.Platform;

public static class HostingExtensions
{
    public static WebApplication ConfiguringServices(this WebApplicationBuilder builder)
    {
        return builder.Build();
    }

    public static WebApplication ConfiguringPipeLines(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
        
        return app;
    }
}
