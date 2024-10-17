
using Microsoft.Extensions.Options;
using Net_Example.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("appsettings.Sajjad.json");

#region First option config

builder.Services.Configure<LocationOtions>(builder.Configuration.GetSection("Location"));

#endregion

#region Second option config

CourseOtions courseOtions = new CourseOtions();
builder.Configuration.Bind("Course", courseOtions);
builder.Services.AddSingleton<CourseOtions>();

#endregion

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

#region First option config

app.MapGet("/FirstOtion", async (HttpContext context, IOptions<LocationOtions> options) =>
{
    context.Response.ContentType = "text/html";
    context.Response.StatusCode = 200;
    context.Response.WriteAsync($"{options.Value.City} - {options.Value.Province}");
});

#endregion

#region Second option config

app.MapGet("/SecondOtion", async (HttpContext context, IConfiguration config) =>
{
    context.Response.ContentType = "text/html";
    context.Response.StatusCode = 200;
    context.Response.WriteAsync($"{courseOtions.Name} - {courseOtions.Author}");
});

#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
