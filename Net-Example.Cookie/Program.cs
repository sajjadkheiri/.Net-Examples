var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/cookie", async (HttpContext context) =>
{
    int number01, number02 = 0;
    string number01Key = nameof(number01);
    string number02Key = nameof(number02);

    number01 = Convert.ToInt32(context.Request.Cookies[number01Key] ?? "0");
    number02 = Convert.ToInt32(context.Request.Cookies[number02Key] ?? "0");

    number01++;
    number02++;

    context.Response.Cookies.Append(number01Key, number01.ToString());
    context.Response.Cookies.Append(number02Key, number02.ToString(), new CookieOptions
    {
        Expires = DateTimeOffset.Now.AddSeconds(10),
        IsEssential = true,
        Path = "/cookie"
    });

    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"{number01}-{number02}");
});

app.MapGet("/clear", async context =>
{
    context.Response.Cookies.Delete("number01");
    context.Response.Cookies.Delete("number02");
});

app.MapGet("/", () => "Hello World!");

app.Run();
