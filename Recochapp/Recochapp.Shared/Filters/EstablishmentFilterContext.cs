using Recochapp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recochapp.Shared.Filters
{
    public class EstablishmentFilterContext
    {
        private readonly List<IFilterStrategy> _strategies = new();

        public void AddStrategy(IFilterStrategy strategy)
        {
            _strategies.Add(strategy);
        }

        public IEnumerable<Establishment> ApplyFilters(IEnumerable<Establishment> establishments, Preference preference)
        {
            IEnumerable<Establishment> result = establishments;

            foreach (var strategy in _strategies)
            {
                result = strategy.Filter(result, preference);
            }

            return result;
        }
    }
}
