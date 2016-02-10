using System;
using System.Collections.Generic;

namespace CDI_Automotriz.Models
{
    public class Producto
    {
        public Producto() {
            Imagenes = new List<ImagenProducto>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string EstadoProducto { get; set; }
        public string ImagenPerfil { get; set; }
        public ICollection<ImagenProducto> Imagenes { get; set; }



    }
}
