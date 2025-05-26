using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recochapp.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(25, ErrorMessage = "El nombre no puede superar los 25 caracteres.")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres.")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo puede contener letras y espacios.")]
        [Display(Name = "Apellido")]
        [DataType(DataType.Text)]
        public string Surname { get; set; } = null!;

        [MaxLength(200, ErrorMessage = "El correo electrónico no puede superar los 200 caracteres.")]
        [Required(ErrorMessage = "El campo Correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido.")]
        [Display(Name = "Correo electrónico")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Formato de correo electrónico no válido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [MaxLength(10, ErrorMessage = "El número de teléfono no puede superar los 10 caracteres.")]
        [Required(ErrorMessage = "El campo Número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de teléfono solo puede contener números.")]
        [Display(Name = "Número de teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "El campo Fecha de nacimiento es obligatorio.")]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Fecha de nacimiento no válida.")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<Review>? Reviews { get; set; }

        [JsonIgnore]
        public ICollection<Expense>? Expenses { get; set; }

        [JsonIgnore]
        public ICollection<UserGroup>? UserGroups { get; set; }
    }
}
