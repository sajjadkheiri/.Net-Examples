using Net_Example.Platform;

var builder = WebApplication.CreateBuilder(args);

builder.ConfiguringServices();

var app = builder.Build();

app.ConfiguringPipeLines();

app.Run();
