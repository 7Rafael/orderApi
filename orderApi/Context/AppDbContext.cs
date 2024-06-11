using Microsoft.EntityFrameworkCore;
using orderApi.Model;
using System.Data;

namespace orderApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {
            
        }

        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Setor> Setores{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Role)
                .WithMany()
                .HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Setor)
                .WithMany()
                .HasForeignKey(c => c.SetorId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
