using Service.Authentication.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.RegisterServices();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.RegisterEndPointDefinations();
app.Run();
