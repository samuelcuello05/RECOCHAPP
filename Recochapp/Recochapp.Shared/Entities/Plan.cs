using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Plan
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El Nombre del plan no puede contener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El Nombre del plan solo puede contener letras.")]
        [Display(Name = "Nombre del plan")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El Nombre del plan es obligatorio.")]
        public string Name { get; set; } = null!;

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

        public double TotalCost { get; set; }

        public bool Status { get; set; }

        [Display(Name = "Fecha del plan")]
        [Required(ErrorMessage = "La Fecha del plan es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar una Fecha para el plan.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [JsonIgnore]
        public Group? Group { get; set; }
        public int GroupId { get; set; }

        [JsonIgnore]
        public Establishment? Establishment { get; set; }
        public int EstablishmentId { get; set; }

        [JsonIgnore]
        public ICollection<Expense>? Expenses { get; set; }

        [JsonIgnore]
        public ICollection<UserPreference>? UserPreferences { get; set; }

    }
}
