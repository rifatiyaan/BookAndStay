using BookAndStay.Application.common.Interface;
using BookAndStay.Domain.Entities;
using BookAndStay.Infrastructure.Data;

namespace BookAndStay.Infrastructure.Repository
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        public AmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Amenity amenity)
        {
            _db.SaveChanges();
        }

        public void Edit(Amenity amenity)
        {
            _db.Update(amenity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}
