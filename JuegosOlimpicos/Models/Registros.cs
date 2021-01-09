using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuegosOlimpicos.Models
{
    public class Registros
    {
        public int Id { get; set; }
        [Display(Name = "Deportista")]
        public int DeportistaId { get; set; }
        public Deportista Deportista{ get; set; }
        [Display(Name = "Tipo de prueba")]
        public int TipoPruebaId { get; set; }
        public TipoPrueba TipoPrueba{ get; set; }
        public int Peso { get; set; }
    }
}
