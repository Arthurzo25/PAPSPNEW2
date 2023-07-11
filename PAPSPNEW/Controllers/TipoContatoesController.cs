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
    public class TipoContatoesController : Controller
    {
        private readonly BdPapSpContext _context;

        public TipoContatoesController(BdPapSpContext context)
        {
            _context = context;
        }

        // GET: TipoContatoes
        public async Task<IActionResult> Index()
        {
            var bdPapSpContext = _context.TipoContatos.Include(t => t.IdPontoTuristicoNavigation);
            return View(await bdPapSpContext.ToListAsync());
        }

        // GET: TipoContatoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoContatos == null)
            {
                return NotFound();
            }

            var tipoContato = await _context.TipoContatos
                .Include(t => t.IdPontoTuristicoNavigation)
                .FirstOrDefaultAsync(m => m.IdContato == id);
            if (tipoContato == null)
            {
                return NotFound();
            }

            return View(tipoContato);
        }

        // GET: TipoContatoes/Create
        public IActionResult Create()
        {
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico");
            return View();
        }

        // POST: TipoContatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContato,Email,TelefoneComer,Celular,IdPontoTuristico,Telefone1,Whatsapp")] TipoContato tipoContato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoContato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", tipoContato.IdPontoTuristico);
            return View(tipoContato);
        }

        // GET: TipoContatoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoContatos == null)
            {
                return NotFound();
            }

            var tipoContato = await _context.TipoContatos.FindAsync(id);
            if (tipoContato == null)
            {
                return NotFound();
            }
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", tipoContato.IdPontoTuristico);
            return View(tipoContato);
        }

        // POST: TipoContatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContato,Email,TelefoneComer,Celular,IdPontoTuristico,Telefone1,Whatsapp")] TipoContato tipoContato)
        {
            if (id != tipoContato.IdContato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContatoExists(tipoContato.IdContato))
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
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", tipoContato.IdPontoTuristico);
            return View(tipoContato);
        }

        // GET: TipoContatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoContatos == null)
            {
                return NotFound();
            }

            var tipoContato = await _context.TipoContatos
                .Include(t => t.IdPontoTuristicoNavigation)
                .FirstOrDefaultAsync(m => m.IdContato == id);
            if (tipoContato == null)
            {
                return NotFound();
            }

            return View(tipoContato);
        }

        // POST: TipoContatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoContatos == null)
            {
                return Problem("Entity set 'BdPapSpContext.TipoContatos'  is null.");
            }
            var tipoContato = await _context.TipoContatos.FindAsync(id);
            if (tipoContato != null)
            {
                _context.TipoContatos.Remove(tipoContato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContatoExists(int id)
        {
          return (_context.TipoContatos?.Any(e => e.IdContato == id)).GetValueOrDefault();
        }
    }
}
