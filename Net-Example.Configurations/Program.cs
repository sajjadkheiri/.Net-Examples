
var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

#region First Sample

app.MapGet("/stage", async (HttpContext context, IConfiguration config) =>
{
    var stage = config["Stage"];

    context.Response.ContentType = "text/html";
    context.Response.StatusCode = 200;
    context.Response.WriteAsync(stage);
});

#endregion

#region Second Sample

app.MapGet("/city", async (HttpContext context, IConfiguration config) =>
{
    var city = config["Location:Province"];

    context.Response.ContentType = "text/html";
    context.Response.StatusCode = 200;
    context.Response.WriteAsync(city);
});

#endregion

#region Third Sample

app.MapGet("/section", async (HttpContext context, IConfiguration config) =>
{
    var location = config.GetSection("Location");
    var city = location["City"];

    context.Response.ContentType = "text/html";
    context.Response.StatusCode = 200;
    context.Response.WriteAsync(city);
});

#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
