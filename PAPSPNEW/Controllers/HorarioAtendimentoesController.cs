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
    public class HorarioAtendimentoesController : Controller
    {
        private readonly BdPapSpContext _context;

        public HorarioAtendimentoesController(BdPapSpContext context)
        {
            _context = context;
        }

        // GET: HorarioAtendimentoes
        public async Task<IActionResult> Index()
        {
            var bdPapSpContext = _context.HorarioAtendimentos.Include(h => h.IdPontoTuristicoNavigation);
            return View(await bdPapSpContext.ToListAsync());
        }

        // GET: HorarioAtendimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HorarioAtendimentos == null)
            {
                return NotFound();
            }

            var horarioAtendimento = await _context.HorarioAtendimentos
                .Include(h => h.IdPontoTuristicoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorarioAtendimento == id);
            if (horarioAtendimento == null)
            {
                return NotFound();
            }

            return View(horarioAtendimento);
        }

        // GET: HorarioAtendimentoes/Create
        public IActionResult Create()
        {
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico");
            return View();
        }

        // POST: HorarioAtendimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPontoTuristico,IdHorarioAtendimento,HorarioIntervalo,HorarioIntervalo2,HorarioIntervalo3,HorarioIntervalo4,HorarioInicio,HorarioFim,DiaSemana")] HorarioAtendimento horarioAtendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horarioAtendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", horarioAtendimento.IdPontoTuristico);
            return View(horarioAtendimento);
        }

        // GET: HorarioAtendimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HorarioAtendimentos == null)
            {
                return NotFound();
            }

            var horarioAtendimento = await _context.HorarioAtendimentos.FindAsync(id);
            if (horarioAtendimento == null)
            {
                return NotFound();
            }
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", horarioAtendimento.IdPontoTuristico);
            return View(horarioAtendimento);
        }

        // POST: HorarioAtendimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPontoTuristico,IdHorarioAtendimento,HorarioIntervalo,HorarioIntervalo2,HorarioIntervalo3,HorarioIntervalo4,HorarioInicio,HorarioFim,DiaSemana")] HorarioAtendimento horarioAtendimento)
        {
            if (id != horarioAtendimento.IdHorarioAtendimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horarioAtendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioAtendimentoExists(horarioAtendimento.IdHorarioAtendimento))
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
            ViewData["IdPontoTuristico"] = new SelectList(_context.PontoTuristicos, "IdPontoTuristico", "IdPontoTuristico", horarioAtendimento.IdPontoTuristico);
            return View(horarioAtendimento);
        }

        // GET: HorarioAtendimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HorarioAtendimentos == null)
            {
                return NotFound();
            }

            var horarioAtendimento = await _context.HorarioAtendimentos
                .Include(h => h.IdPontoTuristicoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorarioAtendimento == id);
            if (horarioAtendimento == null)
            {
                return NotFound();
            }

            return View(horarioAtendimento);
        }

        // POST: HorarioAtendimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HorarioAtendimentos == null)
            {
                return Problem("Entity set 'BdPapSpContext.HorarioAtendimentos'  is null.");
            }
            var horarioAtendimento = await _context.HorarioAtendimentos.FindAsync(id);
            if (horarioAtendimento != null)
            {
                _context.HorarioAtendimentos.Remove(horarioAtendimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioAtendimentoExists(int id)
        {
          return (_context.HorarioAtendimentos?.Any(e => e.IdHorarioAtendimento == id)).GetValueOrDefault();
        }
    }
}
