using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using orderApi.Model;
using System.Data;

namespace orderApi.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {
            
        }

        public DbSet<Chamado>? Chamados { get; set; }
        public DbSet<Setor>? Setores{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);
            */
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Setor)
                .WithMany()
                .HasForeignKey(c => c.SetorId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
