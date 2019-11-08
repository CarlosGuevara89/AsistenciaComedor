using AsistenciaComedor.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AsistenciaComedor.Models
{
    public class AsistenciaViewModel : Asistencia
    {
        public int estudianteId { get; set; }

        public IEnumerable<SelectListItem> Estudiantes { get; set; }
    }
}
