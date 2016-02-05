using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CDIAutomotriz.Migrations
{
    public partial class CDIDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Imagen_Proyecto_ProyectoId", table: "Imagen");
            migrationBuilder.DropForeignKey(name: "FK_ImagenProducto_Producto_ProductoId", table: "ImagenProducto");
            migrationBuilder.AddColumn<string>(
                name: "ImagenPerfil",
                table: "Proyecto",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Imagen_Proyecto_ProyectoId",
                table: "Imagen",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "ProyectoId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ImagenProducto_Producto_ProductoId",
                table: "ImagenProducto",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Imagen_Proyecto_ProyectoId", table: "Imagen");
            migrationBuilder.DropForeignKey(name: "FK_ImagenProducto_Producto_ProductoId", table: "ImagenProducto");
            migrationBuilder.DropColumn(name: "ImagenPerfil", table: "Proyecto");
            migrationBuilder.AddForeignKey(
                name: "FK_Imagen_Proyecto_ProyectoId",
                table: "Imagen",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "ProyectoId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ImagenProducto_Producto_ProductoId",
                table: "ImagenProducto",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
