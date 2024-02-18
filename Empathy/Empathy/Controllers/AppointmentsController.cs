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
using Empathy.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Empathy.Controllers
{
    //[Authorize(Roles ="Admin")]
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
            var appointments = await _context.Appointments
                .Include(a => a.AppointmentProfessionals)
                    .ThenInclude(ap => ap.Professional)
                .Include(a => a.Sede)
                .ToListAsync();

            return View(appointments);
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Appointments/Create
        public async Task<IActionResult> Create()
        {
            var professionals = await _context.Professionals.ToListAsync();
            var sedes = await _context.Sedes.ToListAsync();

            var model = new AddAppointmentViewModel
            {
                ProfessionalOptions = professionals.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.NameProfessional} - {p.Specialty}"
                }),
                // Asignar opciones de sede al modelo
                SedeOptions = sedes.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.NameCampus} - {s.Address}"
                })
            };

            return View(model);
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var professional = await _context.Professionals.FindAsync(model.SelectedProfessionalId);
                var sede = await _context.Sedes.FindAsync(model.SelectedSedeId);

                if (professional == null || sede == null)
                {
                    // Manejar el caso donde el profesional o la sede no se encuentran
                    return NotFound();
                }

                var appointment = new Appointment
                {
                    Date = model.Date,
                    Reason = model.Reason,
                    SedeId = sede.Id
                };

                appointment.AppointmentProfessionals = new List<AppointmentProfessional>
        {
            new AppointmentProfessional
            {
                ProfessionalId = professional.Id
            }
        };

                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // En caso de que el modelo no sea válido, recargar las opciones para profesionales y sede
            var professionals = await _context.Professionals.ToListAsync();
            var sedes = await _context.Sedes.ToListAsync();

            model.ProfessionalOptions = professionals.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.NameProfessional} - {p.Specialty}"
            });

            // Asignar opciones de sede al modelo
            model.SedeOptions = sedes.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.NameCampus} - {s.Address}"
            });

            return View(model);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.AppointmentProfessionals)
                    .ThenInclude(ap => ap.Professional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            // Cargar los profesionales para la vista
            var professionals = await _context.Professionals.ToListAsync();
            var model = new EditAppointmentViewModel
            {
                Id = appointment.Id,
                Date = appointment.Date,
                Reason = appointment.Reason,
                ProfessionalOptions = professionals.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.NameProfessional} - {p.Specialty}"
                })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Reason,ConditionHistory,CardiacHistory,PressureHistory,SugarHistory,Weight,Height,Smoke,Beer,Fracture,Status")] Appointment appointment)
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
            return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
