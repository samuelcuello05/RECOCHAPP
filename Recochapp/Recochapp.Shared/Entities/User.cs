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
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Surname can only contain letters.")]
        [Display(Name = "Surname")]
        [DataType(DataType.Text)]
        public string Surname { get; set; } = null!;

        [MaxLength(200)]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [MaxLength(30)]
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number can only contain numbers.")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Date if birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [DataType(DataType.ImageUrl)]
        [Display(Name = "Profile image")]
        public string? ImageUrl { get; set; }


        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Expense> Expenses { get; set; } = null!;
    }
}
