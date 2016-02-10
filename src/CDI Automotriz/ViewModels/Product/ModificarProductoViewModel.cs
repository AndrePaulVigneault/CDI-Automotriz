using CDI_Automotriz.Models;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.ViewModels
{
    public class ModificarProductoViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EstadoProducto { get; set; }
        public decimal Precio { get; set; }
        [Display(Name = "Imagen de Perfil del Producto")]
        public IFormFile ImagenPerfil { get; set; }
        public ICollection<IFormFile> ImagenesForm { get; set; }
        public int ProductoId { get; set; }
        public ICollection<ImagenProducto> Imagenes { get; set; }
    }
}
