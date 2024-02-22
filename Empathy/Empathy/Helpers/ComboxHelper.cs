using Empathy.Data;
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

        /*public async Task<IEnumerable<SelectListItem>> GetComboCampusAsync()
        {
            _logger.LogInformation("Obteniendo lista de sedes...");
            List<SelectListItem> list = await _context.Sedes.Select(s => new SelectListItem
            {
                Text = s.NameCampus,
                Value = s.Id.ToString(),
            })
            .OrderBy(s => s.Text)
            .ToListAsync();
            _logger.LogInformation($"Se encontraron {list.Count} sedes.");
            list.Insert(0, new SelectListItem { Text = "[Seleccione una sede...", Value = "0" });
            return list;
        }*/


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

        /*public async Task<IEnumerable<SelectListItem>> GetComboProfessional()
        {
            List<SelectListItem> List = await _context.Professionals.Select(p => new SelectListItem
            {
                Text = p.NameProfessional,
                Value = p.Id.ToString(),
            }).OrderBy( p => p.Text)
            .ToListAsync();
            List.Insert(0, new SelectListItem { Text = "[Seleccione un professional ...", Value = "0" });
            return List;
        }*/
       
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
    }
}
