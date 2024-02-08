using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empathy.Data;
using Empathy.Data.Entities;
using Empathy.Helpers;
using Empathy.Models;

namespace Empathy.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly DataContext _context;
        private readonly IComboxHelper _comboxHelper;

        public ProfessionalsController(DataContext context, IComboxHelper comboxHelper)
        {
            _context = context;
            _comboxHelper = comboxHelper;
        }

        // GET: Professionals
        public async Task<IActionResult> Index()
        {
              return View(await _context.Professionals
                  .Include(ps => ps.Sedes)
                  .ToListAsync());
        }

        // GET: Professionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Professionals == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        public async Task<IActionResult> Create()
        {
            var sedes = await _context.Sedes.ToListAsync(); // Obtener todas las sedes
            var model = new CreateProfessionalViewModel
            {
                Sedes = sedes.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.NameCampus
                })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProfessionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var professional = new Professional
                {
                    NameProfessional = model.NameProfessional,
                    Specialty = model.Specialty,
                    Sedes = new List<Sede> { await _context.Sedes.FindAsync(model.SedeId) }
                };

                _context.Add(professional);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Professionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Professionals == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }
            return View(professional);
        }

        // POST: Professionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameProfessional,Specialty")] Professional professional)
        {
            if (id != professional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalExists(professional.Id))
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
            return View(professional);
        }

        // GET: Professionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Professionals == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        // POST: Professionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Professionals == null)
            {
                return Problem("Entity set 'DataContext.Professionals'  is null.");
            }
            var professional = await _context.Professionals.FindAsync(id);
            if (professional != null)
            {
                _context.Professionals.Remove(professional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalExists(int id)
        {
          return _context.Professionals.Any(e => e.Id == id);
        }
    }
}
