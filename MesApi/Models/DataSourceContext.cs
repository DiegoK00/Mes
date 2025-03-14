using Microsoft.EntityFrameworkCore;

namespace MesApi.Models
{
    public class DataSourceContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Commesse> Commesse { get; set; }
        public DbSet<Clienti> Clienti { get; set; }
        public DbSet<Utenti> Utenti { get; set; }

    }
}