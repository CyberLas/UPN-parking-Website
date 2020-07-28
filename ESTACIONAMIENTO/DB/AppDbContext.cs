using Microsoft.EntityFrameworkCore;
using Parking_Lot.DB.Confingurations;
using Parking_Lot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.DB
{
    public class AppDbContext :DbContext
    {
        //DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Estacionamiento> Estacionamientos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        //Conexion a base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = CYBERCUP-PC; Initial Catalog = ParkingLot; Integrated Security = True; MultipleActiveResultSets = true");

        }
        //Conexion a tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // coddigo tabla tabla
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TarjetaConfiguration());
            modelBuilder.ApplyConfiguration(new VehiculoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoConfiguration());
            modelBuilder.ApplyConfiguration(new EstacionamientoConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        }
    }
}
