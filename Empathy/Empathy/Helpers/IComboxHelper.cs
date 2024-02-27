using Empathy.Data.Entities;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Empathy.Helpers
{
    public interface IComboxHelper
    {

        Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();

        Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId);

        Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);
        Task<IEnumerable<SelectListItem>> GetComboProceduresAsync();

        Task<IEnumerable<SelectListItem>> GetComboCampusAsync();
        //Pendiente por indice de campus
        Task<IEnumerable<SelectListItem>> GetComboDoctorAsync();
        Task<IEnumerable<SelectListItem>> GetComboDateTimerAsync();
        Task<IEnumerable<SelectListItem>> GetComboUserAsync();


    }
}
