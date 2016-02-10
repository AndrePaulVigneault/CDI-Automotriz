using System;
using Microsoft.Data.Entity;

namespace CDI_Automotriz.Models
{
    public class CDIAutomotrizContext: DbContext
    {
        public CDIAutomotrizContext() {
            Database.EnsureCreated();
        }

        public DbSet<ImagenProyecto> Imagenes { get; set; }
        public DbSet<ImagenProducto> ImagenesProducto { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Producto> Productos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder opciones)
        {
            var connectionString = Startup.Configuration["Data:CDIAutomotrizContextConnection"];
            opciones.UseSqlServer(connectionString);
            base.OnConfiguring(opciones);
        }
    }
}
