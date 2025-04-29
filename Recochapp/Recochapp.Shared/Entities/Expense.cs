using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recochapp.Shared.Entities
{
    public class Expense
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser un número positivo.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El valor debe ser un número válido con hasta dos decimales.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        public double Value { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?#-]+$", ErrorMessage = "La descripción solo puede contener letras, números y signos de puntuación.")]
        [Display(Name = "Descripción del gasto")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [JsonIgnore]
        public User? User { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Plan? Plan { get; set; }
        public int PlanId { get; set; }
    }
}
