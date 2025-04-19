using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Review rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public double Rating { get; set; }

        [MaxLength(500)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Comment can only contain letters, numbers, and punctuation.")]
        [Display(Name = "Review comment")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; } = null!;


        [JsonIgnore]
        public Establishment? Establishment { get; set; }
        public int EstablishmentId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
