using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

#region InMemory

// builder.Services.AddMemoryCache();

#endregion

#region Distribute
    
    builder.Services.AddDistributedSqlServerCache(option => {
        option.SchemaName = "dbo";
        option.TableName = "DataCache";
        option.ConnectionString = "Server=.;Database=Cache;User Id=sa;Password=1qaz@WSX";
    });

#endregion

var app = builder.Build();

#region InMemory

app.MapGet("/cache/InMemory", (HttpContext context, IMemoryCache cache) =>
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

#region Distribute

app.MapGet("/cache/distribute", (HttpContext context, IDistributedCache cache) =>
{
    int number = 0;
    string numberKey = nameof(number);

    number = Convert.ToInt32(cache.GetString(numberKey) ?? "0");
    number++;

    cache.SetString(numberKey, number.ToString(), new DistributedCacheEntryOptions
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
