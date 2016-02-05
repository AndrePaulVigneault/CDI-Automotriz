using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CDI_Automotriz.Models;
using CDI_Automotriz.ViewModels;
using System.IO;
using Microsoft.AspNet.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using CDI_Automotriz.ViewModels.Product;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CDI_Automotriz.Controllers.Web
{
    public class ProductController : Controller
    {
        private CDIAutomotrizContext Context;
        private IHostingEnvironment Environment;


        public ProductController(CDIAutomotrizContext _Context, IHostingEnvironment _environment)
        {
            Context = _Context;
            Environment = _environment;
        }

        

        // GET: /<controller>/
        public IActionResult Index()
        {
            var Productos = Context.Productos.Include(m => m.Imagenes).ToList();
            ProductIndexViewModel modelo = new ProductIndexViewModel();
            modelo.ListaProductos = Productos;
            return View(modelo);           
        }

        public IActionResult CrearProducto()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult CrearProducto(CrearProductoViewModel modelo)
        {
            var producto = new Producto();
            
            if (modelo.ImagenPerfil != null && modelo.ImagenPerfil.Length > 0)
            {
                var uploads = Path.Combine(Environment.WebRootPath, "Uploads");
                var fileName = ContentDispositionHeaderValue.Parse(modelo.ImagenPerfil.ContentDisposition).FileName.Trim('"');
                var rutaImagen = Path.Combine("Uploads", fileName);
                modelo.ImagenPerfil.SaveAs(rutaImagen);
                
                producto.Imagenes.Add(new ImagenProducto{
                    Path = fileName
                });
            }
            producto.Nombre = modelo.Nombre;
            producto.Descripcion = modelo.Descripcion;
            Context.Productos.Add(producto);
            Context.SaveChanges();
            return View();
        }
    }
}
