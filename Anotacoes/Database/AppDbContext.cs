using Anotacoes.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Anotacoes.Database {
    public class AppDbContext : DbContext {
        public DbSet<Registro> Registros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=banco.db");
        }
    }
}
