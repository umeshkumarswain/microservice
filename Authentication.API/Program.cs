using Service.Authentication.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.RegisterEndPointDefinations();
app.Run();
