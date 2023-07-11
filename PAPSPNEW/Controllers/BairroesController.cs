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
    public class BairroesController : Controller
    {
        private readonly BdPapSpContext _context;

        public BairroesController(BdPapSpContext context)
        {
            _context = context;
        }

        // GET: Bairroes
        public async Task<IActionResult> Index()
        {
            var bdPapSpContext = _context.Bairros.Include(b => b.IdPontoTuristicoNavigation);
            return View(await bdPapSpContext.ToListAsync());
        }

        // GET: Bairroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bairros == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairros
                .Include(b => b.IdPontoTuristicoNavigation)
                .FirstOrDefaultAsync(m => m.IdBairro == id);
            if (bairro == null)
            {
                return NotFound();
            }

            return View(bairro);
        }

        // GET: Bairroes/Create
        public IActionResult Create()
        {
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico");
            return View();
        }

        // POST: Bairroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBairro,IdPontoTuristico,NomeBairro")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bairro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", bairro.IdPontoTuristico);
            return View(bairro);
        }

        // GET: Bairroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bairros == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairros.FindAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", bairro.IdPontoTuristico);
            return View(bairro);
        }

        // POST: Bairroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBairro,IdPontoTuristico,NomeBairro")] Bairro bairro)
        {
            if (id != bairro.IdBairro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bairro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BairroExists(bairro.IdBairro))
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
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", bairro.IdPontoTuristico);
            return View(bairro);
        }

        // GET: Bairroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bairros == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairros
                .Include(b => b.IdPontoTuristicoNavigation)
                .FirstOrDefaultAsync(m => m.IdBairro == id);
            if (bairro == null)
            {
                return NotFound();
            }

            return View(bairro);
        }

        // POST: Bairroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bairros == null)
            {
                return Problem("Entity set 'BdPapSpContext.Bairros'  is null.");
            }
            var bairro = await _context.Bairros.FindAsync(id);
            if (bairro != null)
            {
                _context.Bairros.Remove(bairro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BairroExists(int id)
        {
          return (_context.Bairros?.Any(e => e.IdBairro == id)).GetValueOrDefault();
        }
    }
}
