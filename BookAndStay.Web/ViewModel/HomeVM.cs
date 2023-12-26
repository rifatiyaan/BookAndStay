using BookAndStay.Domain.Entities;

namespace BookAndStay.Web.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Category> CategoryList { get; set; }

        public DateOnly CheckIn { get; set; }

        public DateOnly? CheckOut { get; set; }

        public int Nights { get; set; }

    }
}
