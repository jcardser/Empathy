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

        /*
         * Sección Index
         */

        // GET: Campus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campuses
                .Include(ca => ca.Doctors)
                .ThenInclude(dt => dt.DateTimers)
                .ToListAsync());
        }

        /*
         * Sección Detalles
         */

        // GET: Campus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus campus = await _context.Campuses
                .Include(ca => ca.Doctors)
                .ThenInclude(dt => dt.DateTimers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        // GET: Campus/DetailsDoctor/5
        [HttpGet]
        public async Task<IActionResult> DetailsDoctor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors
                .Include(s => s.Campus)
                .Include(s => s.DateTimers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Campus/DetailsDateTimer/5
        [HttpGet]
        public async Task<IActionResult> DetailsDateTimer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DateTimer dateTimer = await _context.DateTimers
                .Include(c => c.Doctor)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dateTimer == null)
            {
                return NotFound();
            }

            return View(dateTimer);
        }

        /*
         * Sección Create 
         */

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

        /*
         * Sección Agregar - Add
         */

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


        [HttpGet]
        public async Task<IActionResult> AddDateTimer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            DateTimerViewModel model = new()
            {
                DoctorId = doctor.Id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDateTimer(DateTimerViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DateTimer dateTimer= new()
                    {

                        Doctor = await _context.Doctors.FindAsync(model.DoctorId),
                        Date = model.Date,
                        MediumTime = model.MediumTime,
                    };
                    _context.Add(dateTimer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(DetailsDoctor), new { Id = model.DoctorId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya éxiste está hora registrada");
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

        /*
         * Sección Editar 
         */

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

        public async Task<IActionResult> EditDateTimer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DateTimer dateTimer = await _context.DateTimers.FirstOrDefaultAsync(dt => dt.Id == id);
            if (dateTimer == null)
            {
                return NotFound();
            }

            DateTimerViewModel model = new()
            {
                DoctorId = dateTimer.Id,
                Id = dateTimer.Id,
                Date = dateTimer.Date,
                MediumTime = dateTimer.MediumTime
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDateTimer(int id, DateTimerViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DateTimer dateTimer = new()
                    {
                        Id = model.Id,
                        Date = model.Date,
                        MediumTime = model.MediumTime,
                    };
                    _context.Update(dateTimer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = model.DoctorId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esta fecha y hora.");
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

        /*
         * Sección Borrar
         */

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

        // GET: Countries/Delete/5
        public async Task<IActionResult> DeleteDateTimer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DateTimer dateTimer = await _context.DateTimers
                .Include(c => c.Doctor)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (dateTimer == null)
            {
                return NotFound();
            }

            return View(dateTimer);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("DeleteDateTimer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDateTimerConfirmed(int id)
        {
            DateTimer dateTimer = await _context.DateTimers
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(d => d.Id == id);
            _context.DateTimers.Remove(dateTimer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsDoctor), new { Id = dateTimer.Doctor.Id });
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
