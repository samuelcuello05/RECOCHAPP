using Recochapp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recochapp.Shared.Filters
{
    public interface IFilterStrategy
    {
        IEnumerable<Establishment> Filter(IEnumerable<Establishment> establishments, Preference preference);
    }
}
