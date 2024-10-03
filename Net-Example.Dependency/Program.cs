using Net_Example.Dependency;
using Net_Example.Dependency.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SingletonDependency>();

#region Life cycle

builder.Services.AddTransient<ITransientCycle, TransientCycle>();
builder.Services.AddScoped<IScopeCycle, ScopeCycle>();
builder.Services.AddSingleton<ISingletonDependency, SingletonDependency>();

#endregion

#region Factory

// builder.Services.AddScoped<IFactorySample>(x =>
// {
//     var isOdd = DateTime.Now.Second % 2 != 0;

//     if (isOdd)
//     {
//         return new FirstFactorySample();
//     }
//     else
//     {
//         return new SecondFactorySample();
//     }
// });

// OR

builder.Services.AddScoped<IFactorySample, FirstFactorySample>();
builder.Services.AddScoped<IFactorySample, SecondFactorySample>();

#endregion



var app = builder.Build();

app.MapGet("/SingletonDI", async (HttpContext context, ISingletonDependency singletonDependency) =>
{
    await context.Response.WriteAsync(singletonDependency.GetGuid());
});

app.MapGet("/Transient", async (HttpContext context, ITransientCycle transient1, ITransientCycle transient2) =>
{
    await context.Response.WriteAsync($"{transient1.GetGuid()} --- {transient2.GetGuid()}");
});

app.MapGet("/Scope", async (HttpContext context, ISingletonDependency scope1, ISingletonDependency scope2) =>
{
    await context.Response.WriteAsync($"{scope1.GetGuid()} --- {scope2.GetGuid()}");
});

app.MapGet("/Singleton", async (HttpContext context, ITransientCycle singleton1, ITransientCycle singleton2) =>
{
    await context.Response.WriteAsync($"{singleton1.GetGuid()} --- {singleton2.GetGuid()}");
});

app.MapGet("/Concrete", async (HttpContext context, SingletonDependency singletonDependency) =>
{
    await context.Response.WriteAsync(singletonDependency.GetGuid());
});

app.MapGet("/Factory", async (HttpContext context, IFactorySample factory) =>
{
    await context.Response.WriteAsync(factory.GetName());
});

app.MapGet("/FactoryList", async (HttpContext context, IEnumerable<IFactorySample> factory) =>
{
    foreach (var item in factory)
    {
        await context.Response.WriteAsync(item.GetName());
    }
});

app.MapGet("/", () => "Hello World!");

app.Run();
