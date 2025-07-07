using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Proprietario> Proprietario { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proprietario>().ToTable("Proprietario");            
        }
    }
}

