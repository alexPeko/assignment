using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        public DbSet<Entity> Entities { get; set; } = null!;
    }
}
