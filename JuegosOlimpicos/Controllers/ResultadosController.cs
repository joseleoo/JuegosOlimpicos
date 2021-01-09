using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuegosOlimpicos.Models;
using PortafolioProyectos.Context;

namespace JuegosOlimpicos.Controllers
{
    public class ResultadosController : Controller
    {
        private readonly JuegosOlimpicosDbContext _context;

        public ResultadosController(JuegosOlimpicosDbContext context)
        {
            _context = context;
        }

        // GET: Resultados
        public async Task<IActionResult> Index()
        {

            var juegosOlimpicosDbContext = _context.Resultados.FromSqlRaw("select  p.Descripcion as Pais, Nombre, coalesce( (select max(peso) from Registros where DeportistaId=d.Id and TipoPruebaId=1 ),0) as ARRANQUE,coalesce( (select max(peso) from Registros where DeportistaId=d.Id and TipoPruebaId=2 ),0) as ENVION,coalesce((select max(peso) from Registros where DeportistaId=d.Id and TipoPruebaId=2 ),0)+ coalesce( (select max(peso) from Registros where DeportistaId=d.Id and TipoPruebaId=1 ),0) AS Total from Deportistas d inner join Paises p on  p.Id=d.PaisId order by Total desc");
            return View(await juegosOlimpicosDbContext.ToListAsync());

            //return View(await _context.Resultados.ToListAsync());
        }

        // GET: Resultados/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var resultados = await _context.Resultados
        //    //    .FirstOrDefaultAsync(m => m.Id == id);
        //    //if (resultados == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return View(resultados);
        //}

        // GET: Resultados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resultados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pais,Nombre,Arranque,Envion,Total")] Resultados resultados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultados);
        }

        // GET: Resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.Resultados.FindAsync(id);
            if (resultados == null)
            {
                return NotFound();
            }
            return View(resultados);
        }

        // POST: Resultados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Pais,Nombre,Arranque,Envion,Total")] Resultados resultados)
        //{
        //    //if (id != resultados.Id)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //if (ModelState.IsValid)
        //    //{
        //    //    try
        //    //    {
        //    //        _context.Update(resultados);
        //    //        await _context.SaveChangesAsync();
        //    //    }
        //    //    catch (DbUpdateConcurrencyException)
        //    //    {
        //    //        if (!ResultadosExists(resultados.Id))
        //    //        {
        //    //            return NotFound();
        //    //        }
        //    //        else
        //    //        {
        //    //            throw;
        //    //        }
        //    //    }
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //return View(resultados);
        //}

        // GET: Resultados/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var resultados = await _context.Resultados
        //    //    .FirstOrDefaultAsync(m => m.Id == id);
        //    //if (resultados == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return View(resultados);
        //}

        //// POST: Resultados/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultados = await _context.Resultados.FindAsync(id);
            _context.Resultados.Remove(resultados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ResultadosExists(int id)
        //{
        //    //return _context.Resultados.Any(e => e.Id == id);
        //}
    }
}
