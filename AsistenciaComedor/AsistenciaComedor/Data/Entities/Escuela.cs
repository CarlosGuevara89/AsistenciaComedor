using System.ComponentModel.DataAnnotations;

namespace AsistenciaComedor.Data.Entities
{
    public class Escuela
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(25, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string nombre { get; set; }

        [Display(Name ="Dirección")]
        [MaxLength(100, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string direccion{ get; set; }

        [Display(Name = "Código de escuela")]
        [MaxLength(100, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string codigo { get; set; }

        [Display(Name = "Dirección regional")]
        [MaxLength(100, ErrorMessage = "EL Campo {0} no puede tener mas de {1} caracteres.")]
        public string direccionRegional { get; set; }
    }
}
