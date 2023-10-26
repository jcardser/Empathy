using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empathy.Data;
using Empathy.Data.Entities;

namespace Empathy.Controllers
{
    public class SedesController : Controller
    {
        private readonly DataContext _context;

        public SedesController(DataContext context)
        {
            _context = context;
        }

        // GET: Sedes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sedes.ToListAsync());
        }

        // GET: Sedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sedes == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sede == null)
            {
                return NotFound();
            }

            return View(sede);
        }

        // GET: Sedes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sede sede)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(sede);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una sede con este nombre.");
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
            return View(sede);

        }

        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sedes == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameCampus,AddressCampus,PhoneCampus")] Sede sede)
        {
            if (id != sede.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedeExists(sede.Id))
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
            return View(sede);
        }

        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sedes == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sede == null)
            {
                return NotFound();
            }

            return View(sede);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sedes == null)
            {
                return Problem("Entity set 'DataContext.Sedes'  is null.");
            }
            var sede = await _context.Sedes.FindAsync(id);
            if (sede != null)
            {
                _context.Sedes.Remove(sede);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedeExists(int id)
        {
          return (_context.Sedes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
