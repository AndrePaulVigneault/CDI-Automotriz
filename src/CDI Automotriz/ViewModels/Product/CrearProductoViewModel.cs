using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.ViewModels
{
    public class CrearProductoViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string EstadoProducto { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Display(Name = "Imagen de Perfil del Producto")]
        [Required]
        public IFormFile ImagenPerfil { get; set; }
        public ICollection<IFormFile> Imagenes { get; set; }
    }
}
