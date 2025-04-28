using Recochapp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recochapp.Shared.Filters
{
    public class BudgetFilterStrategy : IFilterStrategy
    {
        public IEnumerable<Establishment> Filter(IEnumerable<Establishment> establishments, Preference preference)
        {
            if (string.IsNullOrWhiteSpace(preference.Budget))
                return establishments;

            return establishments.Where(e => e.Prices == preference.Budget);
        }
    }
}
