using BookAndStay.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookAndStay.Web.ViewModel
{
    public class AmenityVM
    {
        public Amenity? Amenity { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }

    }
}
