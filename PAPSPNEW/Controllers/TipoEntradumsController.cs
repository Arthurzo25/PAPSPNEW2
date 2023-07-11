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
    public class TipoEntradumsController : Controller
    {
        private readonly BdPapSpContext _context;

        public TipoEntradumsController(BdPapSpContext context)
        {
            _context = context;
        }

        // GET: TipoEntradums
        public async Task<IActionResult> Index()
        {
              return _context.TipoEntrada != null ? 
                          View(await _context.TipoEntrada.ToListAsync()) :
                          Problem("Entity set 'BdPapSpContext.TipoEntrada'  is null.");
        }

        // GET: TipoEntradums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEntrada == null)
            {
                return NotFound();
            }

            var tipoEntradum = await _context.TipoEntrada
                .FirstOrDefaultAsync(m => m.IdEntrada == id);
            if (tipoEntradum == null)
            {
                return NotFound();
            }

            return View(tipoEntradum);
        }

        // GET: TipoEntradums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEntradums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntrada,IdPontoTuristico,ValorEstudante,ValorProfessor,ValorAdulto,ValorMaior60,ValorAcompanhantePcd,EntradaGratuita,EntradaGratuita1,EntradaGratuita2,EntradaGratuita3")] TipoEntradum tipoEntradum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEntradum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEntradum);
        }

        // GET: TipoEntradums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEntrada == null)
            {
                return NotFound();
            }

            var tipoEntradum = await _context.TipoEntrada.FindAsync(id);
            if (tipoEntradum == null)
            {
                return NotFound();
            }
            return View(tipoEntradum);
        }

        // POST: TipoEntradums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntrada,IdPontoTuristico,ValorEstudante,ValorProfessor,ValorAdulto,ValorMaior60,ValorAcompanhantePcd,EntradaGratuita,EntradaGratuita1,EntradaGratuita2,EntradaGratuita3")] TipoEntradum tipoEntradum)
        {
            if (id != tipoEntradum.IdEntrada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEntradum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEntradumExists(tipoEntradum.IdEntrada))
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
            return View(tipoEntradum);
        }

        // GET: TipoEntradums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEntrada == null)
            {
                return NotFound();
            }

            var tipoEntradum = await _context.TipoEntrada
                .FirstOrDefaultAsync(m => m.IdEntrada == id);
            if (tipoEntradum == null)
            {
                return NotFound();
            }

            return View(tipoEntradum);
        }

        // POST: TipoEntradums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEntrada == null)
            {
                return Problem("Entity set 'BdPapSpContext.TipoEntrada'  is null.");
            }
            var tipoEntradum = await _context.TipoEntrada.FindAsync(id);
            if (tipoEntradum != null)
            {
                _context.TipoEntrada.Remove(tipoEntradum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEntradumExists(int id)
        {
          return (_context.TipoEntrada?.Any(e => e.IdEntrada == id)).GetValueOrDefault();
        }
    }
}
