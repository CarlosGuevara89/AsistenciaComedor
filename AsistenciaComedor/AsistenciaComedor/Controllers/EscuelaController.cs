using AsistenciaComedor.Data;
using AsistenciaComedor.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AsistenciaComedor.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly DataContext _dataContext;

        public EscuelaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: Escuela
        public  IActionResult Index()
        {
            return View(_dataContext.Escuelas);
        }

        // GET: Escuela/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = await _dataContext.Escuelas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escuela == null)
            {
                return NotFound();
            }

            return View(escuela);
        }

        // GET: Escuela/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escuela/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,direccion,codigo,direccionRegional")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(escuela);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escuela);
        }

        // GET: Escuela/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = await _dataContext.Escuelas.FindAsync(id);
            if (escuela == null)
            {
                return NotFound();
            }
            return View(escuela);
        }

        // POST: Escuela/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,direccion,codigo,direccionRegional")] Escuela escuela)
        {
            if (id != escuela.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(escuela);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscuelaExists(escuela.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(escuela);
        }

        // GET: Escuela/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = await _dataContext.Escuelas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escuela == null)
            {
                return NotFound();
            }

            return View(escuela);
        }

        // POST: Escuela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escuela = await _dataContext.Escuelas.FindAsync(id);
            _dataContext.Escuelas.Remove(escuela);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscuelaExists(int id)
        {
            return _dataContext.Escuelas.Any(e => e.Id == id);
        }
    }
}
