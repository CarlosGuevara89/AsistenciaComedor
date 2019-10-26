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
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Nivel> Niveles{ get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
    }
}
