using AsistenciaComedor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsistenciaComedor.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Escuela> Escuelas { get; set; }
    }
}
