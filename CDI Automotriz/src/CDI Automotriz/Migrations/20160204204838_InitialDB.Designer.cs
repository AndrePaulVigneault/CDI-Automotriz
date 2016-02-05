using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CDI_Automotriz.Models;

namespace CDIAutomotriz.Migrations
{
    [DbContext(typeof(CDIAutomotrizContext))]
    [Migration("20160204204838_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CDI_Automotriz.Models.Imagen", b =>
                {
                    b.Property<int>("ImagenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.Property<int>("ProyectoId");

                    b.HasKey("ImagenId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.ImagenProducto", b =>
                {
                    b.Property<int>("ImagenProductoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.Property<int>("ProductoId");

                    b.HasKey("ImagenProductoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

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

                    b.Property<string>("Nombre");

                    b.HasKey("ProyectoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.Imagen", b =>
                {
                    b.HasOne("CDI_Automotriz.Models.Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("CDI_Automotriz.Models.ImagenProducto", b =>
                {
                    b.HasOne("CDI_Automotriz.Models.Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId");
                });
        }
    }
}
