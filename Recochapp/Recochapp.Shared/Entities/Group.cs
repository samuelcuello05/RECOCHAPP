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
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Access code can only contain letters and numbers.")]
        [Display(Name = "Access code")]
        [DataType(DataType.Text)]
        public string AccessCode { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        [Display(Name = "Group name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Description can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Group description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Group image")]
        public string? ImageUrl { get; set; }

        public int MembersQuantity { get; set; } = 0;

        [JsonIgnore]
        public ICollection<UserGroup> UserGroups { get; set; } = null!;
    }
}
