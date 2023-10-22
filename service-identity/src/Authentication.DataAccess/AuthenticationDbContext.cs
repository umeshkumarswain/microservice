using Authentication.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccess
{
    public class AuthenticationDbContext : IdentityDbContext<IdentityUser>
    {
   

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options) { }

   

        public DbSet<Post>? Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:sql-astrotech-dev.database.windows.net,1433;Initial Catalog=db-astrotech-dev;Persist Security Info=False;User ID=astrotech-development;Password=Password!@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }
    }
}