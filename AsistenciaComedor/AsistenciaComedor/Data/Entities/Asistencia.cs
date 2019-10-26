using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsistenciaComedor.Data.Entities
{
    public class Asistencia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime fecha { get; set; }

        public Estudiante Estudiante { get; set; }

    }
}
