﻿using Empathy.Data.Entities;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Empathy.Helpers
{
    public interface IComboxHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();

        Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();

        Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId);

        Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);

        Task<IEnumerable<SelectListItem>> GetComboCampusAsync();

        Task<IEnumerable<SelectListItem>> GetComboProfessional();


    }
}
