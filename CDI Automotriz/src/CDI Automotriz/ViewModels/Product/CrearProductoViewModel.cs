using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.ViewModels
{
    public class CrearProductoViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public IFormFile ImagenPerfil { get; set; }
        public decimal Precio { get; set; }
    }
}
