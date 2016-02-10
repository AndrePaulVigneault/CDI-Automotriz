using System;
using System.Collections.Generic;

namespace CDI_Automotriz.Models
{
    public class Proyecto
    {
        public Proyecto() {
            Imagenes = new List<ImagenProyecto>();
        }

        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EstadoProyecto { get; set; }
        public string ImagenPerfil { get; set; }
        public ICollection<ImagenProyecto> Imagenes { get; set; }



    }
}
