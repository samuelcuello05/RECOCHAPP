using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Preference
    {
        public int Id { get; set; }

        [Display(Name = "Presupuesto del plan")]
        [DataType(DataType.Text)]
        public string? Budget { get; set; }

        [MaxLength(50)]
        [Display(Name = "Categoria del plan")]
        [DataType(DataType.Text)]
        public string? Category { get; set; }

        [MaxLength(50)]
        [Display(Name = "Actividad del plan")]
        [DataType(DataType.Text)]
        public string? Activity { get; set; }

        [JsonIgnore]
        public ICollection<UserPreference>? UserPreferences { get; set; }

    }
}
