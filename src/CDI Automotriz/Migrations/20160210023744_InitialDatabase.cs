using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CDIAutomotriz.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ImagenProducto_Producto_ProductoId", table: "ImagenProducto");
            migrationBuilder.DropForeignKey(name: "FK_ImagenProyecto_Proyecto_ProyectoId", table: "ImagenProyecto");
            migrationBuilder.AddForeignKey(
                name: "FK_ImagenProducto_Producto_ProductoId",
                table: "ImagenProducto",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ImagenProyecto_Proyecto_ProyectoId",
                table: "ImagenProyecto",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "ProyectoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ImagenProducto_Producto_ProductoId", table: "ImagenProducto");
            migrationBuilder.DropForeignKey(name: "FK_ImagenProyecto_Proyecto_ProyectoId", table: "ImagenProyecto");
            migrationBuilder.AddForeignKey(
                name: "FK_ImagenProducto_Producto_ProductoId",
                table: "ImagenProducto",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ImagenProyecto_Proyecto_ProyectoId",
                table: "ImagenProyecto",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "ProyectoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
