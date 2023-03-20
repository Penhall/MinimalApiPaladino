using DemoMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MinimalApiPaladino.Data
{
    public class PaladinoDbContext:DbContext
    {
        public PaladinoDbContext(DbContextOptions<PaladinoDbContext> options) : base(options) { }

        public DbSet<Master> Masters => Set<Master>();
    }
}
