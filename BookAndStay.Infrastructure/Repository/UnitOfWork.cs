using BookAndStay.Application.common.Interface;
using BookAndStay.Infrastructure.Data;

namespace BookAndStay.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public IRoomRepository Room { get; private set; }

        public IAmenityRepository Amenity { get; private set; }

        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Room = new RoomRepository(_db);
            Amenity = new AmenityRepository(_db);

        }

    }
}

