using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndStay.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }




    }
}
