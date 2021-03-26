using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Miel2.Models;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Miel2.Controllers
{
    public class CursosController : Controller
    {
        public ApplicationDbContext _context;

        public CursosController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Cursos
        public ActionResult Index()
        {
            var curso = _context.Cursos.ToList();
            return View(curso);
        }

        public ActionResult Detalle(int id)
        {
            if (id == 1)
                return RedirectToAction("VistaAlumno", "Cursos");
            else
                return RedirectToAction("VistaProfesor", "Cursos");
        }

        public ActionResult VistaAlumno()
        {
            return View();
        }

        public ActionResult VistaProfesor()
        {
            return View();
        }

        public ActionResult NuevoCurso() 
        {
            var cursos = new CursoModels();

            return View("CursosFormulario",cursos);
            
        }

        public ActionResult EditarCurso(int id)
        {
            var curso = _context.Cursos.SingleOrDefault(c => c.Id == id);

            if (curso == null)
            {
                return HttpNotFound();
            }

            return View("CursosFormulario",curso);
        }

        public ActionResult Guardar(CursoModels curso)
        {
            

            if (curso.Id == 0)
                _context.Cursos.Add(curso);
            else
            {
                var customerInDb = _context.Cursos.Single(c => c.Id == curso.Id);

                //Mapper.map(customer,customerInDb);

                customerInDb.NombreDelCurso = curso.NombreDelCurso;
                customerInDb.FechaDeExpiracion = curso.FechaDeExpiracion;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Cursos");
            
        }
        
    }
}