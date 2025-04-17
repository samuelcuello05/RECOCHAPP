using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Preference
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Preference name can only contain letters.")]
        [Display(Name = "Preference name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.,;:!?]+$", ErrorMessage = "Description can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Preference description")]
        [DataType(DataType.Text)]
        public string Description { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Profile image")]
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<UserPreference> UserPreferences { get; set; } = null!;

    }
}
