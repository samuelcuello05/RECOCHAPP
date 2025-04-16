using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Place
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        [Display(Name = "Place name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Description can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Place description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [MaxLength(200)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Location can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Place location")]
        [DataType(DataType.MultilineText)]
        public string Location { get; set; } = null!;

    }
}
