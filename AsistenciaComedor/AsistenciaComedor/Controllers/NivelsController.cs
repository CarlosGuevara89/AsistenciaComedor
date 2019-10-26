using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsistenciaComedor.Data;
using AsistenciaComedor.Data.Entities;

namespace AsistenciaComedor.Controllers
{
    public class NivelsController : Controller
    {
        private readonly DataContext _context;

        public NivelsController(DataContext context)
        {
            _context = context;
        }

        // GET: Nivels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Niveles.ToListAsync());
        }

        // GET: Nivels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivel = await _context.Niveles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivel == null)
            {
                return NotFound();
            }

            return View(nivel);
        }

        // GET: Nivels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nivels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombreNivel")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivel);
        }

        // GET: Nivels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivel = await _context.Niveles.FindAsync(id);
            if (nivel == null)
            {
                return NotFound();
            }
            return View(nivel);
        }

        // POST: Nivels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombreNivel")] Nivel nivel)
        {
            if (id != nivel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelExists(nivel.Id))
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
            return View(nivel);
        }

        // GET: Nivels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivel = await _context.Niveles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivel == null)
            {
                return NotFound();
            }

            return View(nivel);
        }

        // POST: Nivels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nivel = await _context.Niveles.FindAsync(id);
            _context.Niveles.Remove(nivel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelExists(int id)
        {
            return _context.Niveles.Any(e => e.Id == id);
        }
    }
}
