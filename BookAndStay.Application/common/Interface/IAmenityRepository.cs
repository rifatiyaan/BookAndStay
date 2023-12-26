using BookAndStay.Domain.Entities;

namespace BookAndStay.Application.common.Interface
{
    public interface IAmenityRepository : IRepository<Amenity>
    {
        void Update(Amenity amenity);
        void Save();
    }
}
