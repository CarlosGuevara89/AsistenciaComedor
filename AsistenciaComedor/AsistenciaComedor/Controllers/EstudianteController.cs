using System;
using AsistenciaComedor.Data;
using AsistenciaComedor.Helpers;
using AsistenciaComedor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AsistenciaComedor.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public EstudianteController(DataContext dataContext,
                                    ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        //Get: Estudiantes
        public ActionResult Index()
        {
            return View(_dataContext.Estudiantes
                .Include(e => e.Nivel));
        }

        public ActionResult AddEstudent()
        {
            var model = new EstudianteViewModel
            {
                Niveles = _combosHelper.GetComboNivel()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProperty(PropertyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var property = await _converterhelper.ToPropertyAsync(model, true);
                _dataContext.Properties.Add(property);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.OwnerId}");
            }

            model.PropertyTypes = _comboshelper.GetComboPropertyTypes();
            return View(model);
        }

    }

}
    

