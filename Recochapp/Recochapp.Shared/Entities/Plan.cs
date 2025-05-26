using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recochapp.Shared.Entities
{
    public class Plan
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre del plan no puede contener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre del plan solo puede contener letras.")]
        [Display(Name = "Nombre del plan")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre del plan es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Presupuesto del plan")]
        [DataType(DataType.Text)]
        public string? Budget { get; set; }

        [MaxLength(50, ErrorMessage = "La categoría no puede tener más de 50 caracteres.")]
        [Display(Name = "Categoría del plan")]
        [DataType(DataType.Text)]
        public string? Category { get; set; }

        [MaxLength(50, ErrorMessage = "La actividad no puede tener más de 50 caracteres.")]
        [Display(Name = "Actividad del plan")]
        [DataType(DataType.Text)]
        public string? Activity { get; set; }

        [Display(Name = "Costo total")]
        public double TotalCost { get; set; }

        [Display(Name = "Estado")]
        public bool Status { get; set; }

        [Display(Name = "Fecha del plan")]
        [Required(ErrorMessage = "La fecha del plan es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar una fecha válida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Today; // Inicializar a la fecha actual

        [JsonIgnore]
        public Group? Group { get; set; }
        [Required(ErrorMessage = "El grupo es obligatorio.")]
        public int GroupId { get; set; }

        [JsonIgnore]
        public Establishment? Establishment { get; set; }
        [Required(ErrorMessage = "El establecimiento es obligatorio.")]
        public int EstablishmentId { get; set; }

        [JsonIgnore]
        public ICollection<Expense>? Expenses { get; set; }

        [JsonIgnore]
        public ICollection<UserPreference>? UserPreferences { get; set; }
    }
}
