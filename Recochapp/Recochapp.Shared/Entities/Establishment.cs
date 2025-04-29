using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recochapp.Shared.Entities
{
    public class Establishment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [MaxLength(50, ErrorMessage = "La categoría no puede exceder los 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La categoría solo puede contener letras y espacios.")]
        [Display(Name = "Categoría")]
        [DataType(DataType.Text)]
        public string Category { get; set; } = null!;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?#-]+$", ErrorMessage = "La descripción solo puede contener letras, números y signos de puntuación.")]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?#-]+$", ErrorMessage = "La dirección solo puede contener letras, números y signos de puntuación.")]
        [Display(Name = "Dirección")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El número de teléfono no puede exceder los 30 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de teléfono solo puede contener números.")]
        [Display(Name = "Número de teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El correo electrónico no puede exceder los 200 caracteres.")]
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico inválida.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Formato de correo electrónico inválido.")]
        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Rango de precios")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El rango de precios es obligatorio.")]
        public string? Prices { get; set; }

        [Display(Name = "Calificación promedio")]
        public double AverageRating { get; set; } = 0;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen del establecimiento")]
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<Review>? Reviews { get; set; }
    }
}
