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
using Empathy.Enums;
using Empathy.Helpers;

namespace Empathy.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly DataContext _context;
        private readonly IComboxHelper _comboxHelper;

        public AppointmentsController(DataContext context, IComboxHelper comboxHelper)
        {
            _context = context;
            _comboxHelper = comboxHelper;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
              return View(await _context.Appointments
                  .Include(a => a.HealthConditions)
                  .Include(c => c.Doctor)
                  .ThenInclude(d => d.Campus)
                  .ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment appointment = await _context.Appointments
                .Include(a => a.HealthConditions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsHealthCondition(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HealthCondition healthCondition= await _context.HealthConditions.FirstOrDefaultAsync(d => d.Id == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // GET: Appointments/Create
        public async Task<IActionResult> Create()
        {

            Appointment appointment = new()
            {
                HealthConditions = new List<HealthCondition>(),

            };

            return View(appointment);
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment, AddAppointmentViewModel addAppointmentViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(appointment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe en la misma fecha");
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
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Reason")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            return View(appointment);
        }

        public async Task<IActionResult> EditHealthCondition(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HealthCondition healthCondition = await _context.HealthConditions.FirstOrDefaultAsync(s => s.Id == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            HealthConditionViewModel model = new()
            {
                AppointmentId = healthCondition.Id,
                Id = healthCondition.Id,
                ConditionHistory = healthCondition.ConditionHistory,
                Medicine = healthCondition.Medicine,
                Surgery = healthCondition.Surgery,
                CardiacHistory = healthCondition.CardiacHistory,
                Weight = healthCondition.Weight,
                Height = healthCondition.Height,
                Fracture = healthCondition.Fracture,
                Sport = healthCondition.Sport,
                Menstrual = healthCondition.Menstrual,
                MethodMenstrual = healthCondition.MethodMenstrual,
                Smoke = healthCondition.Smoke,
                Beer = healthCondition.Beer,
                Occupation = healthCondition.Occupation,

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHealthCondition(int id, HealthConditionViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HealthCondition healthCondition = new()
                    {
                        Id = model.Id,
                        ConditionHistory = model.ConditionHistory,
                        Medicine = model.Medicine,
                        Surgery = model.Surgery,
                        CardiacHistory = model.CardiacHistory,
                        Weight = model.Weight,
                        Height = model.Height,
                        Fracture = model.Fracture,
                        Sport = model.Sport,
                        Menstrual = model.Menstrual,
                        MethodMenstrual = model.MethodMenstrual,
                        Smoke = model.Smoke,
                        Beer = model.Beer,
                        Occupation = model.Occupation,
                    };
                    _context.Update(healthCondition);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = model.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un condición de salud con el mismo nombre en esta sede, cambialo.");
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
        public async Task<IActionResult> AddHealthCondition(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            HealthConditionViewModel model = new()
            {
                AppointmentId = appointment.Id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHealthCondition(HealthConditionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HealthCondition healthcondition = new()
                    {

                        Appointments = await _context.Appointments.FindAsync(model.AppointmentId),
                        ConditionHistory = model.ConditionHistory,
                        Medicine = model.Medicine,
                        Surgery = model.Surgery,
                        CardiacHistory = model.CardiacHistory,
                        Weight = model.Weight,
                        Height = model.Height,
                        Fracture = model.Fracture,
                        Sport = model.Sport,
                        Menstrual = model.Menstrual,
                        MethodMenstrual = model.MethodMenstrual,
                        Smoke = model.Smoke,
                        Beer = model.Beer,
                        Occupation = model.Occupation
                    };
                    _context.Add(healthcondition);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = model.AppointmentId });
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


        public async Task<IActionResult> DeleteHealthCondition(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HealthCondition healthCondition = await _context.HealthConditions.FirstOrDefaultAsync(s => s.Id == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("DeleteHealthCondition")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteHealthConditionConfirmed(int id)
        {
            HealthCondition healthCondition = await _context.HealthConditions
                .Include(d => d.Appointments)
                .FirstOrDefaultAsync(d => d.Id == id);
            _context.HealthConditions.Remove(healthCondition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = healthCondition.Appointments.Id });
        }
        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'DataContext.Appointments'  is null.");
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
