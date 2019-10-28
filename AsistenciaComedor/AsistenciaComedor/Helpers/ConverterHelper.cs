using AsistenciaComedor.Data;
using AsistenciaComedor.Data.Entities;
using AsistenciaComedor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsistenciaComedor.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext dataContext,
                               ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }
        public async Task<Estudiante> ToEstudianteAsync(EstudianteViewModel model, bool isNew)
        {
            return new Estudiante
            {
                Id = isNew ? 0 : model.Id,
                cedula = model.cedula,
                nombre = model.nombre,
                apellido = model.apellido,
                edad = model.edad,
                sexo = model.sexo,
                Nivel = await _dataContext.Niveles.FindAsync(model.nivelId)
            };
        }
 
        public EstudianteViewModel ToEstudianteViewModel(Estudiante estudiante)
        {
            return new EstudianteViewModel
            {
                cedula = estudiante.cedula,
                nombre = estudiante.nombre,
                apellido = estudiante.apellido,
                Id = estudiante.Id,
                sexo = estudiante.sexo,
                edad = estudiante.edad,
                Nivel = estudiante.Nivel,
                nivelId = estudiante.Nivel.Id,
                Niveles = _combosHelper.GetComboNivel()
            };
        }
    }
}
