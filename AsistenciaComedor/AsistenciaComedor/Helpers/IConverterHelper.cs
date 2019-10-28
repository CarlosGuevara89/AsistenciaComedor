using System.Threading.Tasks;
using AsistenciaComedor.Data.Entities;
using AsistenciaComedor.Models;

namespace AsistenciaComedor.Helpers
{
    public interface IConverterHelper
    {
        Task<Estudiante> ToEstudianteAsync(EstudianteViewModel model, bool isNew);

        EstudianteViewModel ToEstudianteViewModel(Estudiante estudiante);
    }
}