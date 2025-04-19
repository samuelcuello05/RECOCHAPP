using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Establishment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Category can only contain letters.")]
        [Display(Name = "Category")]
        [DataType(DataType.Text)]
        public string Category { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Description can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Address can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number can only contain numbers.")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [MaxLength(200)]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        public double AverageRating { get; set; } = 0;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Establishment image")]
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<Review>? Reviews { get; set; }

    }
}
