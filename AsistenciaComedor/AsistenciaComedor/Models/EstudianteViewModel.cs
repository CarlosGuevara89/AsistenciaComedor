using AsistenciaComedor.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsistenciaComedor.Models
{
    public class EstudianteViewModel : Estudiante
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Nivel escolar")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe de seleccionar un nivel")]
        public int nivelId { get; set; }

        public IEnumerable<SelectListItem> Niveles { get; set; }

    }
}
