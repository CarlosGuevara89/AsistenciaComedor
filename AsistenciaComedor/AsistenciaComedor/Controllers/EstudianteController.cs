using System;
using System.Threading.Tasks;
using AsistenciaComedor.Data;
using AsistenciaComedor.Helpers;
using AsistenciaComedor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


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
                var estudiante = await _converterHelper.ToEstudianteAsync(model, true);
                _dataContext.Estudiantes.Add(estudiante);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             if (model == null)
            {
                model.Niveles = _combosHelper.GetComboNivel();
                return View(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "El estudiante .......");
                model.Niveles = _combosHelper.GetComboNivel();
                return View(model);
            }

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

        public async Task<IActionResult>DeleteEstudiante(int? id)
        {
            if(id == null)
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

    }

}
    

