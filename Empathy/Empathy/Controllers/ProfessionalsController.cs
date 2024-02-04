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
                  .Include(p => p.SedeProfessionals)
                  .ThenInclude(ps => ps.Sede)
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

        // GET: Professionals/Create
        public async Task<IActionResult> Create()
        {
            CreateProfessionalViewModel model = new()
            {
                Categories = await _comboxHelper.GetComboCategoriesAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProfessionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                Professional professional = new()
                {
                    NameProfessional = model.NameProfessional,
                    Specialty = model.Specialty,
                };

                professional.SedeProfessionals = new List<SedeProfessional>()
                {
                    new SedeProfessional
                    {
                        Category = await _context.Categories.FindAsync(model.CategoryId)
                    }
                };
                try
                {
                    _context.Add(professional);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un profesional con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            model.Categories = await _comboxHelper.GetComboCategoriesAsync();
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
