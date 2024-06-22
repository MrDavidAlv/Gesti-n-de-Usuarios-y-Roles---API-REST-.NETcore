using Microsoft.EntityFrameworkCore;
using empleadosFYMtech.Models;

namespace empleadosFYMtech.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet para las entidades de la base de datos
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las relaciones entre entidades y restricciones
            modelBuilder.Entity<Ciudad>()
                .HasKey(c => c.IdCiudad);

            modelBuilder.Entity<Pais>()
                .HasKey(p => p.IdPais);

            modelBuilder.Entity<Rol>()
                .HasKey(r => r.idRol);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.id);

        

        

            // Especificar el esquema y nombre de las tablas
            modelBuilder.Entity<Ciudad>().ToTable("ciudad", "par");
            modelBuilder.Entity<Pais>().ToTable("pais", "par");
            modelBuilder.Entity<Rol>().ToTable("roles", "par");
            modelBuilder.Entity<Usuario>().ToTable("datosUsuario", "usuario");

            base.OnModelCreating(modelBuilder);
        }
    }
}
