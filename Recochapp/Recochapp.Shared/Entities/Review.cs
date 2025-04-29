using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recochapp.Shared.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La calificación es obligatoria.")]
        [Display(Name = "Calificación")]
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public double Rating { get; set; }

        [MaxLength(500, ErrorMessage = "El comentario no puede superar los 500 caracteres.")]
        [Required(ErrorMessage = "El comentario es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?áéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El comentario solo puede contener letras, números y signos de puntuación.")]
        [Display(Name = "Comentario")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; } = null!;

        [JsonIgnore]
        public Establishment? Establishment { get; set; }
        public int EstablishmentId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
