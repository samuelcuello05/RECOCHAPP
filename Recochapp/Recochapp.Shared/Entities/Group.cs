using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Group
    {
        public int Id { get; set; }

        [MaxLength(8)]
        [Display(Name = "Código de acceso")]
        [DataType(DataType.Text)]
        public string? AccessCode { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El Nombre solo puede contener letras.")]
        [Display(Name = "Nombre del grupo")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Cantidad de integrantes")]
        public int MembersQuantity { get; set; } = 0;

        [JsonIgnore]
        public ICollection<UserGroup>? UserGroups { get; set; }
    }
}
