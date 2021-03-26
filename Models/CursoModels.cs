using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Miel2.Models
{
    public class CursoModels
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string NombreDelCurso { get; set; }
        [Required]
        public DateTime FechaDeExpiracion { get; set; }

    }
}