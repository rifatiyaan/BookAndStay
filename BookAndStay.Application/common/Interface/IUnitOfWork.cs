namespace BookAndStay.Application.common.Interface
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IRoomRepository Room { get; }

        IAmenityRepository Amenity { get; }
    }
}
