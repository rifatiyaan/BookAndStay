using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndStay.Domain.Entities
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Room Type")]
        [MaxLength(50)]
        public required string RoomType { get; set; }
        public required double Price { get; set; }
        public required string Description { get; set; }
        [Range(0, 10)]
        public int Occupancy { get; set; }
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        [ValidateNever]
        public IEnumerable<Amenity> CategoryAmenity { get; set; }
    }
}
