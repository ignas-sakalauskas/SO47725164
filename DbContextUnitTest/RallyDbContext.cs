using Microsoft.EntityFrameworkCore;

namespace DbContextUnitTest
{
    public class RallyDbContext : DbContext
    {
        public RallyDbContext(DbContextOptions<RallyDbContext> options)
            : base(options) { }

        public DbSet<Rally> Rallies { get; set; }
    }
}