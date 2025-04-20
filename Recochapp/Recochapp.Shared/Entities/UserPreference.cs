using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class UserPreference
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Plan? Plan { get; set; }
        public int PlanId { get; set; }

        [JsonIgnore]
        public Preference? Preference { get; set; }
        public int PreferenceId { get; set; }
    }
}
