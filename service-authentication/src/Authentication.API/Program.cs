using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Commands;
using Authentication.DataAccess;
using Authentication.DataAccess.Repositories;
using Authentication.Domain.Models.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthenticationDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IExternalLoginProviders, ExternalLoginProviderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePost>());
builder
    .Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder?.Configuration["ExternalAuthentication:Google:ClientId"];
        googleOptions.ClientSecret = builder?.Configuration[
            "ExternalAuthentication:Google:ClientSecret"
        ];
        googleOptions.Scope.Add("user:email");
        googleOptions.SaveTokens = true;
    });
builder
    .Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AuthenticationDbContext>();

// Add services to the container.

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddCors(
    (opt) =>
    {
        opt.AddPolicy(
            name: "CorsPolicy",
            builder =>
            {
                builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }
        );
    }
);

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
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
