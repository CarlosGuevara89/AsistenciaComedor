using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsistenciaComedor.Data.Entities
{
    public class Nivel
    {
        public int Id { get; set; }

        [Display(Name = "Nivel escolar")]
        [MaxLength(15, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string nombreNivel { get; set; }

        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
