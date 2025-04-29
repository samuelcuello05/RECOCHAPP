using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Recochapp.Shared.Entities
{
    public class Group
    {
        public int Id { get; set; }

        [MaxLength(8, ErrorMessage = "El código de acceso no puede tener más de 8 caracteres.")]
        [Display(Name = "Código de acceso")]
        [DataType(DataType.Text)]
        public string? AccessCode { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        [Required(ErrorMessage = "El nombre del grupo es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        [Display(Name = "Nombre del grupo")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen del grupo")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Cantidad de integrantes")]
        public int MembersQuantity { get; set; } = 0;

        [JsonIgnore]
        public ICollection<UserGroup>? UserGroups { get; set; }
    }
}
