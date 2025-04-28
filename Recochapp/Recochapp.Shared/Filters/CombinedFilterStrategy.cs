using Recochapp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recochapp.Shared.Filters
{
    public class CombinedFilterStrategy : IFilterStrategy
    {
        public IEnumerable<Establishment> Filter(IEnumerable<Establishment> establishments, Preference preference)
        {
            // Si no hay criterios definidos, devolver todos los establecimientos
            if (string.IsNullOrWhiteSpace(preference.Budget) && string.IsNullOrWhiteSpace(preference.Category))
                return establishments;

            // Filtrar por la condición OR: que cumpla al menos un criterio
            return establishments.Where(e =>
                (string.IsNullOrWhiteSpace(preference.Budget) || e.Prices == preference.Budget) ||
                (string.IsNullOrWhiteSpace(preference.Category) ||
                 e.Category?.Trim().ToLower() == preference.Category.Trim().ToLower())
            );
        }
    }
}
