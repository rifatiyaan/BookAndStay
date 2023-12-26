using BookAndStay.Application.common.Interface;
using BookAndStay.Domain.Entities;
using BookAndStay.Infrastructure.Data;

namespace BookAndStay.Infrastructure.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public RoomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Room room)
        {
            _db.Update(room);
        }
    }
}
