using AsistenciaComedor.Data;
using AsistenciaComedor.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AsistenciaComedor.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IConverterHelper _converterHelper;

        public AsistenciaController(DataContext dataContext,
                                    IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _converterHelper = converterHelper;
        }
        public IActionResult Index()
        {
            if (TempData["mensaje"] != null)
                ViewBag.mensaje = TempData["mensaje"].ToString();

            return View(_dataContext.Estudiantes
                .Include(e => e.Nivel));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsistencia(int Id, string fecha)
        {
            if (fecha == null)
            {
                TempData["mensaje"] = "¡Por favor seleccione una fecha para continuar!";
                return RedirectToAction("Index");
            }
            var asistencia = await _converterHelper.ToAsistenciaAsync(Id, fecha);
            _dataContext.Asistencias.Add(asistencia);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}