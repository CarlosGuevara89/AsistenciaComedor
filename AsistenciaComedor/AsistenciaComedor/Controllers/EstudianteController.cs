using AsistenciaComedor.Data;
using AsistenciaComedor.Helpers;
using AsistenciaComedor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace AsistenciaComedor.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public EstudianteController(DataContext dataContext,
                                    ICombosHelper combosHelper,
                                    IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        //Get: Estudiantes
        public ActionResult Index()
        {
            return View(_dataContext.Estudiantes
                .Include(e => e.Nivel));
        }

        //Get: Add Estudiante
        public ActionResult AddEstudent()
        {
            var model = new EstudianteViewModel
            {
                Niveles = _combosHelper.GetComboNivel()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEstudent(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!EstudianteExists(model.cedula))
                {
                    var estudiante = await _converterHelper.ToEstudianteAsync(model, true);
                    _dataContext.Estudiantes.Add(estudiante);
                    await _dataContext.SaveChangesAsync();
                    ViewBag.mensaje = "¡Registro guardado correctamente!";
                    ViewBag.identificador = 1;
                    model.Niveles = _combosHelper.GetComboNivel();
                    return View(model); 
                }
                ViewBag.mensaje = "¡El número de identificación que intenta registrar, ya existe en la base de datos, verfique por favor!";
                ViewBag.identificador = 2;
            }
            if (model == null)
            {
                return View(model);
            }
            
            model.Niveles = _combosHelper.GetComboNivel();
            return View(model);
        }

        //Get: Edit Estudiante
        public async Task<IActionResult> EditEstudiante(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _dataContext.Estudiantes
                .Include(e => e.Nivel)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToEstudianteViewModel(estudiante);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEstudiante(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estudiante = await _converterHelper.ToEstudianteAsync(model, false);
                _dataContext.Estudiantes.Update(estudiante);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteEstudiante(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _dataContext.Estudiantes
                .Include(e => e.Nivel)
                .FirstOrDefaultAsync(e => e.Id == id.Value);
            if (estudiante == null)
            {
                return NotFound();
            }
            _dataContext.Estudiantes.Remove(estudiante);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetailsEstudiante(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _dataContext.Estudiantes
                .Include(e => e.Asistencias)
                .Include(e => e.Nivel)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        private bool EstudianteExists(string cedula)
        {
            return _dataContext.Estudiantes.Any(e => e.cedula == cedula);
        }

    }

}


