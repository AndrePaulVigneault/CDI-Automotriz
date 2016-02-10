using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CDI_Automotriz.Models;

namespace CDIAutomotriz.Migrations
{
    [DbContext(typeof(CDIAutomotrizContext))]
    partial class CDIAutomotrizContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CDI_Automotriz.Models.ImagenProducto", b =>
                {
                    b.Property<int>("ImagenProductoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.Property<int>("ProductoId");

                    b.HasKey("ImagenProductoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.ImagenProyecto", b =>
                {
                    b.Property<int>("ImagenProyectoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.Property<int>("ProyectoId");

                    b.HasKey("ImagenProyectoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("EstadoProducto");

                    b.Property<string>("ImagenPerfil");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio");

                    b.HasKey("ProductoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.Proyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("EstadoProyecto");

                    b.Property<string>("ImagenPerfil");

                    b.Property<string>("Nombre");

                    b.HasKey("ProyectoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.ImagenProducto", b =>
                {
                    b.HasOne("CDI_Automotriz.Models.Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.ImagenProyecto", b =>
                {
                    b.HasOne("CDI_Automotriz.Models.Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId");
                });
        }
    }
}
