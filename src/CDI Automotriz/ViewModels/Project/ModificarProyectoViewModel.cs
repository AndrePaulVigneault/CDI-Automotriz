using CDI_Automotriz.Models;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.ViewModels
{
    public class ModificarProyectoViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EstadoProyecto { get; set; }
        [Display(Name = "Imagen de Perfil del Proyecto")]
        public IFormFile ImagenPerfil { get; set; }
        public ICollection<IFormFile> ImagenesForm { get; set; }
        public int ProyectoId { get; set; }
        public ICollection<ImagenProyecto> Imagenes { get; set; }
    }
}
