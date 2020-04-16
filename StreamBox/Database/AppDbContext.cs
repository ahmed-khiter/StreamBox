using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StreamBox.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Stream> Streams { get; set; }

        public DbSet<Server> Servers { get; set; }
        
        public DbSet<Bouquet> Bouquets { get; set; }

    }
}
