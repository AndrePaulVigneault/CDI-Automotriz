using CDI_Automotriz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.ViewModels.Project
{
    public class ProjectIndexViewModel
    {
        public IEnumerable<Proyecto> ListaProyectos { get; set; }
    }
}
