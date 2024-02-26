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
    public class HealthConditionsController : Controller
    {
        private readonly DataContext _context;

        public HealthConditionsController(DataContext context)
        {
            _context = context;
        }

        // GET: HealthConditions
        public async Task<IActionResult> Index()
        {
              return View(await _context.HealthConditions.ToListAsync());
        }

        // GET: HealthConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthConditions == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // GET: HealthConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Identification,NameUser,Emergengy,PhoneEmergengy,ConditionHistory,Medicine,Surgery,CardiacHistory,Weight,Height,Fracture,Sport,Menstrual,MethodMenstrual,Smoke,Beer,Occupation")] HealthCondition healthCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthCondition);
        }

        // GET: HealthConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthConditions == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions.FindAsync(id);
            if (healthCondition == null)
            {
                return NotFound();
            }
            return View(healthCondition);
        }

        // POST: HealthConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Identification,NameUser,Emergengy,PhoneEmergengy,ConditionHistory,Medicine,Surgery,CardiacHistory,Weight,Height,Fracture,Sport,Menstrual,MethodMenstrual,Smoke,Beer,Occupation")] HealthCondition healthCondition)
        {
            if (id != healthCondition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthConditionExists(healthCondition.Id))
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
            return View(healthCondition);
        }

        // GET: HealthConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthConditions == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // POST: HealthConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthConditions == null)
            {
                return Problem("Entity set 'DataContext.HealthConditions'  is null.");
            }
            var healthCondition = await _context.HealthConditions.FindAsync(id);
            if (healthCondition != null)
            {
                _context.HealthConditions.Remove(healthCondition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthConditionExists(int id)
        {
          return _context.HealthConditions.Any(e => e.Id == id);
        }
    }
}
