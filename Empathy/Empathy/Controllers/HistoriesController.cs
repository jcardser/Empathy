using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empathy.Data;
using Empathy.Data.Entities;
using Empathy.Models;

namespace Empathy.Controllers
{
    public class HistoriesController : Controller
    {
        private readonly DataContext _context;

        public HistoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Histories
                .Include(h=>h.Procedures)
                .ToListAsync());
        }

        // GET: Histories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Histories == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // GET: Histories/Create
        public async Task<IActionResult> Create()
        {
            var procedures = await _context.Procedures.ToListAsync();
            var model = new CreateHistoryViewModel
            {
                Procedures = procedures.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.TypeProcedure
                })
            };

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var history = new History
                {
                    Date = model.Date,
                    Summary = model.Summary,
                    Symptoms = model.Symptoms,
                    Notes = model.Notes,
                    BloodPressure = model.BloodPressure,
                    HeartRate = model.HeartRate,
                    BreathingFrequency = model.BreathingFrequency,
                    Temperature = model.Temperature,
                    PhysicalExam = model.PhysicalExam,
                    Diagnosis = model.Diagnosis
                };

                // Obtener el procedimiento seleccionado
                var selectedProcedure = await _context.Procedures.FindAsync(model.ProcedureId);
                if (selectedProcedure != null)
                {
                    // Agregar el procedimiento a la historia
                    history.Procedures = new List<Procedure> { selectedProcedure };
                }

                _context.Add(history);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Si llegamos aquí, algo falló, devolver la vista con los datos del modelo
            var procedures = await _context.Procedures.ToListAsync();
            model.Procedures = procedures.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.TypeProcedure
            });

            return View(model);
        }

        // GET: Histories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Histories == null)
            {
                return NotFound();
            }

            var history = await _context.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Summary,Symptoms,Notes,BloodPressure,HeartRate,BreathingFrequency,Temperature,PhysicalExam,Diagnosis")] History history)
        {
            if (id != history.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.Id))
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
            return View(history);
        }

        // GET: Histories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Histories == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // POST: Histories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Histories == null)
            {
                return Problem("Entity set 'DataContext.Histories'  is null.");
            }
            var history = await _context.Histories.FindAsync(id);
            if (history != null)
            {
                _context.Histories.Remove(history);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryExists(int id)
        {
          return (_context.Histories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
