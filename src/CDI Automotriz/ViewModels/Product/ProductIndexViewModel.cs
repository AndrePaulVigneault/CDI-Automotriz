using CDI_Automotriz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDI_Automotriz.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Producto> ListaProductos { get; set; }
    }
}
