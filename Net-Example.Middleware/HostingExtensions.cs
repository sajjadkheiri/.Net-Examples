using Net_Example.Middleware;

namespace Net_Example.Platform;

public static class HostingExtensions
{
    public static WebApplication ConfiguringServices(this WebApplicationBuilder builder)
    {
        return builder.Build();
    }

    public static WebApplication ConfiguringPipeLines(this WebApplication app)
    {
        /// First implementation
        app.Use(async (httpcontext, next) =>
        {
            if (httpcontext.Request.Query.ContainsKey("AddText"))
            {
                httpcontext.Response.ContentType = "text/html";
                await httpcontext.Response.WriteAsync("First Middleware");
            }
            await next();
        });

        /// Second implementation

        app.UseMiddleware<MiddlewareTemplate>();

        app.Map("/Admin", myApp =>
        {
            myApp.UseMiddleware<MiddlewareTemplate>();
        });

        app.MapGet("/", () => "Hello World!");

        return app;
    }
}
