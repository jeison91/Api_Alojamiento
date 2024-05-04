using Alojamiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Infrastructure
{
    public class AlojamientoDbContext : DbContext
    {
        public AlojamientoDbContext(DbContextOptions<AlojamientoDbContext> option) : base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                SqlServerOptionsExtension CnxOptios = optionsBuilder.Options.Extensions.OfType<SqlServerOptionsExtension>().First();
                string? cnx = CnxOptios.ConnectionString;

                if (cnx != null)
                    optionsBuilder.UseSqlServer(cnx).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Agregamos datos a la tablas maestras.
            modelBuilder.Entity<TipoHabitacionEntity>().HasData(
                new TipoHabitacionEntity { Id = 1, Descripcion = "Suite" },
                new TipoHabitacionEntity { Id = 2, Descripcion = "Junior suite" },
                new TipoHabitacionEntity { Id = 3, Descripcion = "Individuales" },
                new TipoHabitacionEntity { Id = 4, Descripcion = "Dobles" },
                new TipoHabitacionEntity { Id = 5, Descripcion = "Familiares" }
            );

            modelBuilder.Entity<UbicacionHabitacionEntity>().HasData(
                new UbicacionHabitacionEntity { Id = 1, Descripcion = "Centro Balcon" },
                new UbicacionHabitacionEntity { Id = 2, Descripcion = "Esquina balcon" },
                new UbicacionHabitacionEntity { Id = 3, Descripcion = "Centro sin balcon" },
                new UbicacionHabitacionEntity { Id = 4, Descripcion = "Esquina sin balcon" }
            );

            modelBuilder.Entity<GeneroEntity>().HasData(
                new GeneroEntity { Id = 1, Descripcion = "Femenino" },
                new GeneroEntity { Id = 2, Descripcion = "Masculino" },
                new GeneroEntity { Id = 3, Descripcion = "Otro" }
            );

            modelBuilder.Entity<CiudadEntity>().HasData(
                new CiudadEntity { Id = 1, Descripcion = "Medellín", Codigo = "050001" },
                new CiudadEntity { Id = 2, Descripcion = "Bogotá", Codigo = "11001" },
                new CiudadEntity { Id = 3, Descripcion = "Barranquilla", Codigo = "08001" },
                new CiudadEntity { Id = 4, Descripcion = "Santa Marta", Codigo = "47001" },
                new CiudadEntity { Id = 5, Descripcion = "Cartagena", Codigo = "13001" }
            );

            modelBuilder.Entity<TipoDocumentoEntity>().HasData(
                new TipoDocumentoEntity { Id = 11, Descripcion = "Registro civil de nacimiento" },
                new TipoDocumentoEntity { Id = 12, Descripcion = "Tarjeta de identidad" },
                new TipoDocumentoEntity { Id = 13, Descripcion = "Cédula de ciudadanía" },
                new TipoDocumentoEntity { Id = 21, Descripcion = "Tarjeta de extranjería" },
                new TipoDocumentoEntity { Id = 22, Descripcion = "Cédula de extranjería" },
                new TipoDocumentoEntity { Id = 31, Descripcion = "NIT" },
                new TipoDocumentoEntity { Id = 41, Descripcion = "Pasaporte" },
                new TipoDocumentoEntity { Id = 42, Descripcion = "Tipo de documento extranjero" }
            );

            modelBuilder.Entity<ClienteEntity>().HasData(
                new ClienteEntity { Id = 1, IdTipoDocumento = 13, Documento = "1128436325", Nombre = "Jeison Cañas", FechaNacimiento = new DateTime(1991, 01, 16),
                    IdGenero = 2, Email = "jeison9101@gmail.com", Telefono = "3137653881" },
                new ClienteEntity { Id = 2, IdTipoDocumento = 13, Documento = "1023468549", Nombre = "Carlos Perez", FechaNacimiento = new DateTime(1994, 03, 14),
                    IdGenero = 2, Email = "carlos@example.com",Telefono = "3012568423"},
                new ClienteEntity { Id = 3, IdTipoDocumento = 13, Documento = "1165794321", Nombre = "Catalina Cifuentes", FechaNacimiento = new DateTime(1998, 09, 14),
                    IdGenero = 1, Email = "cata21@example.com", Telefono = "3104526981" }
            );
        }

        public DbSet<CiudadEntity> Ciudades { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<GeneroEntity> Generos { get; set; }
        public DbSet<HabitacionEntity> Habitaciones { get; set; }
        public DbSet<HotelEntity> Hoteles { get; set; }
        public DbSet<HuespedEntity> Huespedes { get; set; }
        public DbSet<ReservasEntity> Reservas { get; set; }
        public DbSet<TipoDocumentoEntity> TipoDocumentos { get; set; }
        public DbSet<TipoHabitacionEntity> TipoHabitaciones { get; set; }
        public DbSet<UbicacionHabitacionEntity> UbicacionHabitaciones { get; set; }
        public DbSet<ReservaHuespedEntity> ReservaHuespedes { get; set; }
        
    }
}
