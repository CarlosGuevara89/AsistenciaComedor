using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsistenciaComedor.Data.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Display(Name = "Identificación")]
        [MaxLength(15, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string cedula { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string nombre { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(20, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string apellido { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int edad { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string sexo { get; set; }

        public Nivel Nivel { get; set; }

        public ICollection<Asistencia> Asistencias{ get; set; }

        [Display(Name = "Nombre de estudiante")]
        public string nombreCompleto => $"{nombre} {apellido}";



    }

}
