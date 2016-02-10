using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.Models
{
    public class ImagenProyecto
    {
        public int ImagenProyectoId { get; set; }
        public string Path { get; set; }
        public int ProyectoId { get; set;}
        public Proyecto Proyecto { get; set; }
        
        
    }
}
