using BookAndStay.Domain.Entities;

namespace BookAndStay.Application.common.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category category);
        void Save();



    }
}
