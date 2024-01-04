using BookAndStay.Domain.Entities;

namespace BookAndStay.Application.common.Interface
{
    public interface IRoomRepository : IRepository<Room>
    {
        void Update(Room room);
        void Save();
    }
}
