using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuegosOlimpicos.Models
{
    public class Deportista
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }

        public Pais Pais { get; set; }

        [Required(ErrorMessage = "Pais requerido")]
        [Display(Name = "Pais")]
        public int PaisId { get; set; }

        public List<Registros> Registros { get; set; }
    }
}
