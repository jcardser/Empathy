using Empathy.Data;
using Empathy.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Empathy.Helpers
{
    public class ComboxHelper : IComboxHelper
    {
        private readonly DataContext _context;
        private readonly ILogger<ComboxHelper> _logger;

        public ComboxHelper(DataContext context, ILogger<ComboxHelper> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboCampusAsync()
        {

            List<SelectListItem> list = await _context.Campuses.Select(s => new SelectListItem
            {
                Text = s.NameCam,
                Value = s.Id.ToString(),
            })
            .OrderBy(s => s.Text)
            .ToListAsync();
            list.Insert(0, new SelectListItem { Text = "Seleccione una sede...", Value = "0" });
            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboDoctorAsync()
        {
            List<SelectListItem> List = await _context.Doctors.Select(p => new SelectListItem
            {
                Text = p.NameDoctor + " - " + p.SpecialtyDoc + " - " + p.Campus.NameCam,
                Value = p.Id.ToString(),
            })
            .OrderBy(p => p.Text)
            .ToListAsync();
            List.Insert(0, new SelectListItem { Text = "Seleccione un professional ...", Value = "0" });
            return List;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboDateTimerAsync()
        {
            List<SelectListItem> List = await _context.DateTimers.Select(p => new SelectListItem
                {
                    Text = p.Doctor.NameDoctor + " - " + p.Date + "-" + p.MediumTime,
                    Value = p.Id.ToString(),
                }).OrderBy(p => p.Text)
            .ToListAsync();
            List.Insert(0, new SelectListItem { Text = "Seleccione una Fecha disponible ...", Value = "0" });
            return List;
        }


        public async Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId)
        {
            List<SelectListItem> list = await _context.Cities
                .Where(s => s.State.Id == stateId)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .OrderBy(c => c.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione una ciudad...", Value = "0" });
            return list;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboCountriesAsync()
        {
            List<SelectListItem> list = await _context.Countries.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            })
                .OrderBy(c => c.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione un país...", Value = "0" });
            return list;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId)
        {
            List<SelectListItem> list = await _context.States
                .Where(s => s.Country.Id == countryId)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .OrderBy(c => c.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione un Departamento / Estado...", Value = "0" });
            return list;
        }


        public async Task<IEnumerable<SelectListItem>> GetComboProceduresAsync()
        {
            List<SelectListItem> List = await _context.Procedures.Select(p => new SelectListItem
            {
                Text = p.TypeProcedure,
                Value = p.Id.ToString(),
            }).OrderBy(p => p.Text)
           .ToListAsync();
            List.Insert(0, new SelectListItem { Text = "Seleccione un procedimiento ...", Value = "0" });
            return List;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboUserAsync()
        {
            List<SelectListItem> list = await _context.Users.Select(s => new SelectListItem
            {
                Text = s.FullName,
                Value = s.Id.ToString(),
            })

            .OrderBy(s => s.Text)
            .ToListAsync();
            list.Insert(0, new SelectListItem { Text = "Seleccione un paciente...", Value = "0" });
            return list;
        }


    }
}
