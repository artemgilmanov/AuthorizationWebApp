using Microsoft.EntityFrameworkCore;
using Authorization.DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authorization.DB
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }
    }
}
