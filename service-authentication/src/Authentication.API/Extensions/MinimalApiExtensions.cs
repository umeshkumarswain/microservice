using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Commands;
using Authentication.DataAccess;
using Authentication.DataAccess.Repositories;
using Authentication.Domain.Models.User;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Service.Authentication.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Default");
            
            builder.Services.AddDbContext<AuthenticationDbContext>(
                opt => opt.UseSqlServer(connectionString)
            );

            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                   .AddEntityFrameworkStores<AuthenticationDbContext>();;

            // builder.Services
            //     .AddIdentity<User, IdentityRole>()
            //     .AddEntityFrameworkStores<AuthenticationDbContext>();
                
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            
            
            builder.Services.AddMediatR(
                x => x.RegisterServicesFromAssemblies(typeof(CreatePost).Assembly)
            );
        }

        // public static void RegisterEndPointDefinations(this WebApplication app)
        // {
        //     var endPointDefinations = typeof(Program).Assembly
        //         .GetTypes()
        //         .Where(
        //             (type) =>
        //                 type.IsAssignableTo(typeof(IEndPointDefinations))
        //                 && !type.IsAbstract
        //                 && !type.IsInterface
        //         )
        //         .Select(Activator.CreateInstance)
        //         .Cast<IEndPointDefinations>();

        //     foreach (var endPointDefination in endPointDefinations)
        //     {
        //         endPointDefination.RegisterEndPoints(app);
        //     }
        // }
    }
}
