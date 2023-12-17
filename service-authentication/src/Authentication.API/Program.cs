using Authentication.Domain.Models.User;
using Authentication.DataAccess;
using Microsoft.EntityFrameworkCore;
using Authentication.Application.Features.Post.Commands;
using Authentication.Application.Abstractions;
using Authentication.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AuthenticationDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
 builder.Services.AddScoped<IPostRepository, PostRepository>();
  builder.Services.AddScoped<IExternalLoginProviders, ExternalLoginProviderRepository>();
 builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePost>());


builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AuthenticationDbContext>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapGroup("/account").MapIdentityApi<User>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();