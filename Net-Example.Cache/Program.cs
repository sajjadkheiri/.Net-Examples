using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

#region InMemory

builder.Services.AddMemoryCache();

#endregion

var app = builder.Build();

#region InMemory

app.MapGet("/cache", (HttpContext context, IMemoryCache cache) =>
{
    int number = 0;
    string numberKey = nameof(number);

    number = cache.Get<int>(numberKey);
    number++;

    cache.Set(numberKey, number, new MemoryCacheEntryOptions
    {
        AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30),
        SlidingExpiration = TimeSpan.FromMinutes(1)
    });

    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    context.Response.WriteAsync($"{number}");
});



#endregion

app.Run();
