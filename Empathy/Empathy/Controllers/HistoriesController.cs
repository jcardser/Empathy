using Empathy.Data;
using Empathy.Data.Entities;
using Empathy.Helpers;
using Empathy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Empathy.Controllers
{
    public class HistoriesController : Controller
    {
        private readonly DataContext _context;
        private readonly IComboxHelper _comboxHelper;

        public HistoriesController(DataContext context, IComboxHelper comboxHelper)
        {
            _context = context;
            _comboxHelper = comboxHelper;
        }

        // GET: Campus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Histories
                .Include(h => h.HistoryProcedures)
                .ThenInclude(h => h.Procedure)
                .ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            History history= await _context.Histories
                .Include(h => h.HistoryProcedures)  
                .ThenInclude(hp => hp.Procedure)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }


        public async Task<IActionResult> Create()
        {
            CreateHistoryViewModel model = new()
            {
                Procedures = await _comboxHelper.GetComboProceduresAsync(),
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHistoryViewModel model)
        {
            if (ModelState.IsValid)
            {

                History history = new()
                {
                    Date = model.Date,
                    Summary = model.Summary,
                    Symptoms = model.Symptoms,
                    Notes = model.Notes,
                    BloodPressure = model.BloodPressure,
                    HeartRate = model.HeartRate,
                    BreathingFrequency = model.BreathingFrequency,
                    Temperature = model.Temperature,
                    Diagnosis = model.Diagnosis,
                };

                history.HistoryProcedures = new List<HistoryProcedure>()
        {
            new HistoryProcedure
            {
                Procedure = await _context.Procedures.FindAsync(model.ProcedureId)
            }
        };

                try
                {
                    _context.Add(history);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una historia con el mismo nombre.");
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

            model.Procedures = await _comboxHelper.GetComboProceduresAsync();
            return View(model);
        }


    }
}
