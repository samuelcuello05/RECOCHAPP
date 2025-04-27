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
        [Required(ErrorMessage = "El presupuesto es obligatorio")]
        public string? Budget { get; set; }

        [MaxLength(50)]
        [Display(Name = "Categoria del plan")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string? Category { get; set; }

        [MaxLength(50)]
        [Display(Name = "Actividad del plan")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La actividad es obligatoria")]
        public string? Activity { get; set; }

        [JsonIgnore]
        public Establishment? Establishment { get; set; }
        public int EstablishmentId { get; set; }

        [JsonIgnore]
        public ICollection<UserPreference>? UserPreferences { get; set; }

    }
}
