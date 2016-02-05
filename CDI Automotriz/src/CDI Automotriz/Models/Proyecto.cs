﻿using System;
using System.Collections.Generic;

namespace CDI_Automotriz.Models
{
    public class Proyecto
    {
        public Proyecto() {
            Imagenes = new List<Imagen>();
        }

        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EstadoProyecto { get; set; }

        
        public virtual ICollection<Imagen> Imagenes { get; set; }



    }
}
