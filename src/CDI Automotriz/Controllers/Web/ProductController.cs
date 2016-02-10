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



        #region MetodosGet

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
        public IActionResult ModificarProducto(int Id)
        {
            var Producto = Context.Productos.Include(m => m.Imagenes).SingleOrDefault(m => m.ProductoId == Id);
            var Modelo = new ModificarProductoViewModel();
            Modelo.Nombre = Producto.Nombre;
            Modelo.Descripcion = Producto.Descripcion;
            Modelo.ProductoId = Producto.ProductoId;
            Modelo.Imagenes = Producto.Imagenes;
            Modelo.Precio = Producto.Precio;
            return View(Modelo);
        }
        public IActionResult Detalles(int Id)
        {
            var Producto = Context.Productos.Include(m => m.Imagenes).SingleOrDefault(m => m.ProductoId == Id);
            var Modelo = new ProductDetallesViewModel();
            Modelo.producto = Producto;
            return View(Modelo);
        }
        public IActionResult EliminarProducto(int Id)
        {
            var Producto = Context.Productos.Include(m => m.Imagenes).SingleOrDefault(m => m.ProductoId == Id);
            if (Producto != null)
            {
                foreach (var Imagen in Producto.Imagenes)
                {
                    var RutaImagen = Path.Combine(Environment.WebRootPath, "Uploads", Imagen.Path);
                    if (System.IO.File.Exists(RutaImagen))
                    {
                        System.IO.File.Delete(RutaImagen);
                    }

                }

                var RutaImagenPerfil = Path.Combine(Environment.WebRootPath, "Uploads", Producto.ImagenPerfil);

                if (System.IO.File.Exists(RutaImagenPerfil))
                {
                    System.IO.File.Delete(RutaImagenPerfil);
                }

                Context.Productos.Remove(Producto);
                Context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult EliminarImagen(int Id)
        {
            var Imagen = Context.ImagenesProducto.SingleOrDefault(m => m.ImagenProductoId == Id);

            var RutaImagen = Path.Combine(Environment.WebRootPath, "Uploads", Imagen.Path);
            if (System.IO.File.Exists(RutaImagen))
            {
                System.IO.File.Delete(RutaImagen);
            }

            Context.ImagenesProducto.Remove(Imagen);
            Context.SaveChanges();

            return RedirectToAction("ModificarProducto", new { id = Imagen.ProductoId });
        }
        #endregion

        #region Post

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

                producto.ImagenPerfil = fileName;
            }
            foreach (var Imagen in modelo.Imagenes)
            {
                if (Imagen != null && Imagen.Length > 0)
                {
                    //var RutaUploads = Path.Combine(Environment.WebRootPath, "Uploads");
                    var fileName = ContentDispositionHeaderValue.Parse(Imagen.ContentDisposition).FileName.Trim('"');
                    var rutaImagen = Path.Combine("Uploads", fileName);
                    Imagen.SaveAs(rutaImagen);

                    producto.Imagenes.Add(new ImagenProducto
                    {
                        Path = fileName
                    });
                }
            }
            producto.Nombre = modelo.Nombre;
            producto.Descripcion = modelo.Descripcion;
            producto.Precio = modelo.Precio;
            Context.Productos.Add(producto);
            Context.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult ModificarProducto(int Id, ModificarProductoViewModel modelo)
        {
            var Producto = Context.Productos.Include(m => m.Imagenes).SingleOrDefault(m => m.ProductoId == Id);
            var RutaImagenPerfil = Path.Combine(Environment.WebRootPath, "Uploads", Producto.ImagenPerfil);

            if (System.IO.File.Exists(RutaImagenPerfil))
            {
                System.IO.File.Delete(RutaImagenPerfil);
            }

            if (modelo.ImagenPerfil != null && modelo.ImagenPerfil.Length > 0)
            {

                var fileName = ContentDispositionHeaderValue.Parse(modelo.ImagenPerfil.ContentDisposition).FileName.Trim('"');
                var rutaImagen = Path.Combine("Uploads", fileName);
                modelo.ImagenPerfil.SaveAs(rutaImagen);

                Producto.ImagenPerfil = fileName;
            }


            foreach (var Imagen in modelo.ImagenesForm)
            {
                if (Imagen != null && Imagen.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(Imagen.ContentDisposition).FileName.Trim('"');
                    var rutaImagen = Path.Combine("Uploads", fileName);
                    Imagen.SaveAs(rutaImagen);

                    Producto.Imagenes.Add(new ImagenProducto
                    {
                        Path = fileName
                    });
                }
            }

            Producto.Nombre = modelo.Nombre;
            Producto.Descripcion = modelo.Descripcion;
            Producto.Precio = modelo.Precio;
            Producto.EstadoProducto = modelo.EstadoProducto;
            Context.SaveChanges();

            return RedirectToAction("ModificarProducto", new { id = Producto.ProductoId });
        }
        #endregion

    }
}