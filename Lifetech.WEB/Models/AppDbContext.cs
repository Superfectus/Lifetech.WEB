using Microsoft.EntityFrameworkCore;

namespace Lifetech.WEB.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }
    public DbSet<Email> Emails { get; set; }
        
}