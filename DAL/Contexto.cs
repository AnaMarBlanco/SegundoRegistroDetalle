using Microsoft.EntityFrameworkCore;
using SegundoRegistroDetalle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoRegistroDetalle.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data/Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 1,
                Nombres = "Tecnologias Perez"
            });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 2,
                Nombres = "Absatos Martes"
            });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 3,
                Nombres = "Mercadom"
            });

            modelBuilder.Entity<Productos>().HasData(new Productos 
            {
                ProductoId = 1,
                Descripcion = "Crema humectante",
                Costo = 300,
                Inventario = 0
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 2,
                Descripcion = "Alimento para aves",
                Costo = 400,
                Inventario = 0
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 3,
                Descripcion = "Shampoo para mascotas",
                Costo = 350,
                Inventario = 0
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 4,
                Descripcion = "Cargador android",
                Costo = 350,
                Inventario = 0
            });

        }
    }
}
