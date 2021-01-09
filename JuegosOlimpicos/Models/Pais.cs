using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuegosOlimpicos.Models
{
    public class Pais
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Solo se permiten 10DE0 caracteres")]
        public string Descripcion { get; set; }
    }
}
