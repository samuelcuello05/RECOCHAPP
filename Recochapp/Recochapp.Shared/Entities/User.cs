using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El Nombre solo puede contener letras.")]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El Apellido solo puede contener letras.")]
        [Display(Name = "Apellido")]
        [DataType(DataType.Text)]
        public string Surname { get; set; } = null!;

        [MaxLength(200)]
        [Required(ErrorMessage = "El campo Correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electrónico no valido.")]
        [Display(Name = "Correo electrónico")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Formato de correo electrónico no valido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [MaxLength(30)]
        [Required(ErrorMessage = "El campo Número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El Número de teléfono solo puede contener números.")]
        [Display(Name = "Número de teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "El campo Fecha de nacimiento es obligatorio.")]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Fecha de nacimiento no valida.")]
        public DateTime? DateOfBirth { get; set; }


        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? ImageUrl { get; set; }


        [JsonIgnore]
        public ICollection<Review>? Reviews { get; set; }

        [JsonIgnore]
        public ICollection<Expense>? Expenses { get; set; }

        [JsonIgnore]
        public ICollection<UserGroup>? UserGroups { get; set; }

        [JsonIgnore]
        public ICollection<UserPreference>? UserPreferences { get; set; }
    }
}
