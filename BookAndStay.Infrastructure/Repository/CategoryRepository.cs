using BookAndStay.Application.common.Interface;
using BookAndStay.Domain.Entities;
using BookAndStay.Infrastructure.Data;

namespace BookAndStay.Infrastructure.Repository

{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
