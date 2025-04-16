using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Plan
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        [Display(Name = "Plan name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Description can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Plan description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Display(Name = "Plan budget")]
        [Required(ErrorMessage = "Budget is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a positive number.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Budget must be a valid number with up to two decimal places.")]
        [DataType(DataType.Currency)]
        public double Budget { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Category can only contain letters.")]
        [Display(Name = "Plan category")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = null!;

        public double TotalCost { get; set; }

        public bool Status { get; set; }

        [Display(Name = "Plan date")]
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [JsonIgnore]
        public PlanDestination? Destination { get; set; }
        public int PlanDestinationId { get; set; }
        public string PlanDestinationName { get; set; } = null!;

        [JsonIgnore]
        public Group? Group { get; set; }
        public int GroupId { get; set; }

        [JsonIgnore]
        public ICollection<Expense> Expenses { get; set; } = null!;

    }
}
