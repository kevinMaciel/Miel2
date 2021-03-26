using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Miel2.Models;

namespace Miel2.Controllers.Api
{
    public class CursosController : ApiController
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
        [HttpDelete]
        public void BorrarCurso(int id)
        {
            var cursoInDb = _context.Cursos.SingleOrDefault(c => c.Id == id);
           
            _context.Cursos.Remove(cursoInDb);
            _context.SaveChanges();
        }
    }
}
