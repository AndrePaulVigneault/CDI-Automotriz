using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.Models
{
    public class Imagen
    {
        public int ImagenId { get; set; }
        public string Path { get; set; }

        public int ProyectoId { get; set;}
        public Proyecto Proyecto { get; set; }
        
        
    }
}
