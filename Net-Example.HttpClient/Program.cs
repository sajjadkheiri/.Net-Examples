using Net_Example.HttpClient.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient("posts", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

builder.Services.AddHttpClient<PostServices>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();