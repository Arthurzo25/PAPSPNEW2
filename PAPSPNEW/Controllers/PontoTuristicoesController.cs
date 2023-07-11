using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAPSPNEW.Models;

namespace PAPSPNEW.Controllers
{
    public class PontoTuristicoesController : Controller
    {
        private readonly BdPapSpContext _context;

        public PontoTuristicoesController(BdPapSpContext context)
        {
            _context = context;
        }

        // GET: PontoTuristicoes
        public async Task<IActionResult> Index()
        {
              return _context.PontoTuristicos != null ? 
                          View(await _context.PontoTuristicos.ToListAsync()) :
                          Problem("Entity set 'BdPapSpContext.PontoTuristicos'  is null.");
        }

        // GET: PontoTuristicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PontoTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristicos
                .FirstOrDefaultAsync(m => m.IdPontoTuristico == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // GET: PontoTuristicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PontoTuristicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPontoTuristico,NomePontoTuristico,DescricaoPontoTuristico")] PontoTuristico pontoTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pontoTuristico);
        }

        // GET: PontoTuristicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PontoTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristicos.FindAsync(id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }
            return View(pontoTuristico);
        }

        // POST: PontoTuristicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPontoTuristico,NomePontoTuristico,DescricaoPontoTuristico")] PontoTuristico pontoTuristico)
        {
            if (id != pontoTuristico.IdPontoTuristico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoTuristicoExists(pontoTuristico.IdPontoTuristico))
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
            return View(pontoTuristico);
        }

        // GET: PontoTuristicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PontoTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristicos
                .FirstOrDefaultAsync(m => m.IdPontoTuristico == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // POST: PontoTuristicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PontoTuristicos == null)
            {
                return Problem("Entity set 'BdPapSpContext.PontoTuristicos'  is null.");
            }
            var pontoTuristico = await _context.PontoTuristicos.FindAsync(id);
            if (pontoTuristico != null)
            {
                _context.PontoTuristicos.Remove(pontoTuristico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoTuristicoExists(int id)
        {
          return (_context.PontoTuristicos?.Any(e => e.IdPontoTuristico == id)).GetValueOrDefault();
        }
    }
}
