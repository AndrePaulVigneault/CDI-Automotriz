using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CDI_Automotriz.Models;
using CDI_Automotriz.ViewModels.Project;
using CDI_Automotriz.ViewModels;
using System.IO;
using Microsoft.AspNet.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CDI_Automotriz.Controllers.Web
{
    public class ProjectController : Controller
    {
        private CDIAutomotrizContext Context;
        private IHostingEnvironment Environment;


        public ProjectController(CDIAutomotrizContext _Context, IHostingEnvironment _environment)
        {
            Context = _Context;
            Environment = _environment;
        }

        

        // GET: /<controller>/
        public IActionResult Index()
        {
            var Proyectos = Context.Proyectos.Include(m => m.Imagenes).ToList();
            ProjectIndexViewModel modelo = new ProjectIndexViewModel();
            modelo.ListaProyectos = Proyectos;
            return View(modelo);           
        }

        public IActionResult CrearProyecto()
        {
            return View(); 
        }

        public IActionResult Detalles(int Id)
        {
            var Proyecto = Context.Proyectos.Include(m => m.Imagenes).SingleOrDefault(m => m.ProyectoId == Id);
            var Modelo = new ProjectDetallesViewModel();
            Modelo.proyecto = Proyecto;
            return View(Modelo);
        }

        [HttpPost]
        public IActionResult CrearProyecto(CrearProyectoViewModel modelo)
        {
            var proyecto = new Proyecto();
            
            if (modelo.ImagenPerfil != null && modelo.ImagenPerfil.Length > 0)
            {
                //var RutaUploads = Path.Combine(Environment.WebRootPath, "Uploads");
                var fileName = ContentDispositionHeaderValue.Parse(modelo.ImagenPerfil.ContentDisposition).FileName.Trim('"');
                var rutaImagen = Path.Combine("Uploads", fileName);
                modelo.ImagenPerfil.SaveAs(rutaImagen);

                proyecto.ImagenPerfil = fileName;
            }
            foreach (var Imagen in modelo.Imagenes)
            {
                if (Imagen != null && Imagen.Length > 0)
                {
                    //var RutaUploads = Path.Combine(Environment.WebRootPath, "Uploads");
                    var fileName = ContentDispositionHeaderValue.Parse(Imagen.ContentDisposition).FileName.Trim('"');
                    var rutaImagen = Path.Combine("Uploads", fileName);
                    Imagen.SaveAs(rutaImagen);

                    proyecto.Imagenes.Add(new Imagen
                    {
                        Path = fileName
                    });
                }
            }
            proyecto.Nombre = modelo.Nombre;
            proyecto.Descripcion = modelo.Descripcion;
            Context.Proyectos.Add(proyecto);
            Context.SaveChanges();
            return View();
        }
    }
}
