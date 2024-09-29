
namespace Net_Example.Middleware;

public class MiddlewareTemplate
{
    private readonly RequestDelegate _next;

    public MiddlewareTemplate(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext is null)
        {
            throw new ArgumentNullException(nameof(httpContext));
        }

        if (httpContext.Request.Query.ContainsKey("AddText"))
        {
            httpContext.Response.ContentType = "text/html";
            await httpContext.Response.WriteAsync("First Middleware");
        }
        await _next(httpContext);
    }
}
