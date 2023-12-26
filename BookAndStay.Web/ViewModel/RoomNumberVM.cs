using BookAndStay.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookAndStay.Web.ViewModel
{
    public class RoomNumberVM
    {
        public Room? Room { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? RoomList { get; set; }

    }
}
