using Recochapp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recochapp.Shared.Filters
{
    public class CategoryFilterStrategy : IFilterStrategy
    {
        public IEnumerable<Establishment> Filter(IEnumerable<Establishment> establishments, Preference preference)
        {
            if (string.IsNullOrWhiteSpace(preference.Category))
                return establishments;

            return establishments.Where(e => e.Category?.Trim().ToLower() == preference.Category.Trim().ToLower());
        }
    }
}
