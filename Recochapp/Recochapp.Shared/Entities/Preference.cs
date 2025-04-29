using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recochapp.Shared.Entities
{
    public class Preference
    {
        public int Id { get; set; }

        [Display(Name = "Presupuesto del plan")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El presupuesto es obligatorio.")]
        public string? Budget { get; set; }

        [MaxLength(50, ErrorMessage = "La categoría no puede superar los 50 caracteres.")]
        [Display(Name = "Categoría del plan")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string? Category { get; set; }

        [MaxLength(50, ErrorMessage = "La actividad no puede superar los 50 caracteres.")]
        [Display(Name = "Actividad del plan")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La actividad es obligatoria.")]
        public string? Activity { get; set; }

        [JsonIgnore]
        public Establishment? Establishment { get; set; }
        public int EstablishmentId { get; set; }

        [Display(Name = "Nombre del establecimiento")]
        public string? EstablishmentName { get; set; } = null!;

        [JsonIgnore]
        public ICollection<UserPreference>? UserPreferences { get; set; }
    }
}
