using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.Models
{
    public class ImagenProducto
    {
        public int ImagenProductoId { get; set; }
        public string Path { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
