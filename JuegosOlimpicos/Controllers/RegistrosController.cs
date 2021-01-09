using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuegosOlimpicos.Models;
using PortafolioProyectos.Context;

namespace JuegosOlimpicos
{
    public class RegistrosController : Controller
    {
        private readonly JuegosOlimpicosDbContext _context;

        public RegistrosController(JuegosOlimpicosDbContext context)
        {
            _context = context;
        }

        // GET: Registros
        public async Task<IActionResult> Index()
        {
            var juegosOlimpicosDbContext = _context.Registros.Include(r => r.Deportista).Include(r => r.TipoPrueba).OrderBy(r=>r.Deportista.Nombre);
            return View(await juegosOlimpicosDbContext.ToListAsync());
        }

        // GET: Registros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registros = await _context.Registros
                .Include(r => r.Deportista)
                .Include(r => r.TipoPrueba)
                .FirstOrDefaultAsync(m => m.DeportistaId == id);
            if (registros == null)
            {
                return NotFound();
            }

            return View(registros);
        }

        // GET: Registros/Create
        public IActionResult Create()
        {
            ViewData["DeportistaId"] = new SelectList(_context.Deportistas, "Id", "Nombre");
            ViewData["TipoPruebaId"] = new SelectList(_context.Set<TipoPrueba>(), "Id", "Descripcion");
            return View();
        }

        // POST: Registros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeportistaId,TipoPruebaId,Peso")] Registros registros)
        {
            if (ModelState.IsValid)
            {
                if (RegistrosCount(registros.DeportistaId, registros.TipoPruebaId) >= 3)
                {

                    ViewBag.Message = "No se puede grabar tres veces el mismo registro";
                    ModelState.AddModelError("Error", "Check ID");
                }
                else
                {
                    _context.Add(registros);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }

            ViewData["DeportistaId"] = new SelectList(_context.Deportistas, "Id", "Nombre", registros.DeportistaId);
            ViewData["TipoPruebaId"] = new SelectList(_context.Set<TipoPrueba>(), "Id", "Descripcion", registros.TipoPruebaId);
            return View(registros);
        }

        // GET: Registros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registros = await _context.Registros.FindAsync(id);
            if (registros == null)
            {
                return NotFound();
            }
            ViewData["DeportistaId"] = new SelectList(_context.Deportistas, "Id", "Nombre", registros.DeportistaId);
            ViewData["TipoPruebaId"] = new SelectList(_context.Set<TipoPrueba>(), "Id", "Id", registros.TipoPruebaId);
            return View(registros);
        }

        // POST: Registros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeportistaId,TipoPruebaId,Peso")] Registros registros)
        {
            if (id != registros.DeportistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrosExists(registros.DeportistaId))
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
            ViewData["DeportistaId"] = new SelectList(_context.Deportistas, "Id", "Nombre", registros.DeportistaId);
            ViewData["TipoPruebaId"] = new SelectList(_context.Set<TipoPrueba>(), "Id", "Id", registros.TipoPruebaId);
            return View(registros);
        }

        // GET: Registros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registros = await _context.Registros
                .Include(r => r.Deportista)
                .Include(r => r.TipoPrueba)
                .FirstOrDefaultAsync(m => m.DeportistaId == id);
            if (registros == null)
            {
                return NotFound();
            }

            return View(registros);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registros = await _context.Registros.FindAsync(id);
            _context.Registros.Remove(registros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrosExists(int DeportistaId, int TipoPruebaId)
        {
            return _context.Registros.Any(e => e.DeportistaId == DeportistaId && e.TipoPruebaId == TipoPruebaId);
        }

        private int RegistrosCount(int DeportistaId, int TipoPruebaId)
        {
            return _context.Registros.Count(e => e.DeportistaId == DeportistaId && e.TipoPruebaId == TipoPruebaId);
        }
        private bool RegistrosExists(int DeportistaId)
        {
            return _context.Registros.Any(e => e.DeportistaId == DeportistaId);
        }
    }
}
