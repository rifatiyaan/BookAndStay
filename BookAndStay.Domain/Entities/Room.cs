using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndStay.Domain.Entities
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, 1000)]
        public int Room_Number { get; set; }
        [ForeignKey("Category")]
        public int Room_ID { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
