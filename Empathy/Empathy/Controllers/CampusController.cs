using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empathy.Data;
using Empathy.Data.Entities;
using System.Diagnostics.Metrics;
using Empathy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Empathy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CampusController : Controller
    {
        
        private readonly DataContext _context;

        public CampusController(DataContext context)
        {
            _context = context;
        }

        // GET: Campus
        public async Task<IActionResult> Index()
        {
              return View(await _context.Campuses
                  .Include(ca => ca.Doctors)
                  .ToListAsync());
        }

        // GET: Campus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus campus = await _context.Campuses
                .Include(ca => ca.Doctors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsDoctor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Campus/Create
        public IActionResult Create()
        {
            Campus campus = new()
            {
                Doctors = new List<Doctor>()
            };
            return View(campus);
        }

        // POST: Campus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campus campus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(campus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe campus con el mismo nombre");
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
            return View(campus);
        }

        [HttpGet]
        public async Task<IActionResult> AddDoctor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus campus = await _context.Campuses.FindAsync(id);
            if (campus == null)
            {
                return NotFound();
            }
            DoctorViewModel model = new()
            {
                CampusId = campus.Id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDoctor(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Doctor doctor = new()
                    {
                       
                        Campus = await _context.Campuses.FindAsync(model.CampusId),
                        NameDoctor = model.NameDoctor,
                        SpecialtyDoc = model.SpecialtyDoc,
                    };
                    _context.Add(doctor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = model.CampusId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un doctor con el mismo nombre exacto en esta sede, actualizalo");
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
            return View(model);

        }


        // GET: Campus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campuses == null)
            {
                return NotFound();
            }

            var campus = await _context.Campuses.FindAsync(id);
            if (campus == null)
            {
                return NotFound();
            }
            return View(campus);
        }

        // POST: Campus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameCam,AddressCam,PhoneCam")] Campus campus)
        {
            if (id != campus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampusExists(campus.Id))
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
            return View(campus);
        }

        public async Task<IActionResult> EditDoctor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(s => s.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            DoctorViewModel model = new()
            {
                CampusId = doctor.Id,
                Id = doctor.Id,
                NameDoctor = doctor.NameDoctor,
                SpecialtyDoc = doctor.SpecialtyDoc
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDoctor(int id, DoctorViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Doctor doctor = new()
                    {
                        Id = model.Id,
                        NameDoctor = model.NameDoctor,
                        SpecialtyDoc = model.SpecialtyDoc,
                    };
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = model.CampusId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un Doctor con el mismo nombre en esta sede, cambialo.");
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
            return View(model);

        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> DeleteDoctor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor= await _context.Doctors.FirstOrDefaultAsync(s => s.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("DeleteDoctor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDoctorConfirmed(int id)
        {
            Doctor doctor= await _context.Doctors
                .Include(d => d.Campus)
                .FirstOrDefaultAsync(d => d.Id == id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = doctor.Campus.Id });
        }


        // GET: Campus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campuses == null)
            {
                return NotFound();
            }

            var campus = await _context.Campuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campuses == null)
            {
                return Problem("Entity set 'DataContext.Campuses'  is null.");
            }
            var campus = await _context.Campuses.FindAsync(id);
            if (campus != null)
            {
                _context.Campuses.Remove(campus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampusExists(int id)
        {
          return _context.Campuses.Any(e => e.Id == id);
        }
    }
}
