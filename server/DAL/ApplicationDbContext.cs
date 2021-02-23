using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}