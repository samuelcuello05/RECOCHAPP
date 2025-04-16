using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Expense
    {
        public int Id { get; set; }

        [DisplayName]
        [Required(ErrorMessage = "Value is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Value must be a positive number.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Budget must be a valid number with up to two decimal places.")]
        [DataType(DataType.Currency)]
        public double Value { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Description can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Expense description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = null!;


        [JsonIgnore]
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        [JsonIgnore]
        public Plan Plan { get; set; } = null!;
        public int PlanId { get; set; }
    }
}
