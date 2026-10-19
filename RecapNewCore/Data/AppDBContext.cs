using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecapNewCore.Modules;
using RecapNewCore.Modules.User;

namespace RecapNewCore.Data;

public class AppDbContext:IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {
        
    }
    public DbSet<Numbers>Numbers{ get; set; }
}