using System.Threading.Tasks;
using AsistenciaComedor.Data.Entities;
using AsistenciaComedor.Models;

namespace AsistenciaComedor.Helpers
{
    public interface IConverterHelper
    {
        Task<Estudiante> ToEstudianteAsync(EstudianteViewModel model, bool isNew);

        Task<Asistencia> ToAsistenciaAsync(int id, string fecha);

        EstudianteViewModel ToEstudianteViewModel(Estudiante estudiante);
    }
}