
using Microsoft.AspNetCore.Identity;

namespace BookAndStay.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
