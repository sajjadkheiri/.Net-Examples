using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net_Example.Identity.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<IdentityModelDbContext>(x=>x.UseSqlServer("Server=.;Initial catalog=IdentityDb;User Id=sa;Password=1qaz@WSX;TrustServerCertificate=True"));
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<IdentityModelDbContext>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.MapRazorPages();
app.MapDefaultControllerRoute();


app.Run();
