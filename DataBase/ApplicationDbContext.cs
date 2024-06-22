using empleadosFYMtech.Models;
using Microsoft.EntityFrameworkCore;

namespace empleadosFYMtech.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Pais> Pais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "SuperAdmin" },
                new Role { Id = 2, Name = "Admin" },
                new Role { Id = 3, Name = "User" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), // Usar hash seguro en producción
                    Email = "admin@example.com",
                    RoleId = 1 // SuperAdmin role
                }
            );

          

            base.OnModelCreating(modelBuilder);


            // Configuración de la entidad Ciudad
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("ciudad", "par");

                entity.HasKey(e => e.idCiudad);

                entity.Property(e => e.idCiudad)
                    .HasColumnName("idCiudad")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.nombreCiudad)
                    .HasColumnName("nombreciudad")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.idPais)
                    .HasColumnName("idPais")
                    .IsRequired();
            });

            // Configuración de la entidad Pais
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.ToTable("pais", "par");

                entity.HasKey(e => e.idPais);

                entity.Property(e => e.idPais)
                    .HasColumnName("idPais")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.nombrePais)
                    .HasColumnName("nombrePais")
                    .IsRequired()
                    .HasMaxLength(50);
            });


        }
    }
}
