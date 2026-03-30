using Microsoft.EntityFrameworkCore;
using TMS.Api.Models;

namespace TMS.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
