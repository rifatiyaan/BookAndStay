using System.Linq.Expressions;

namespace BookAndStay.Application.common.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includedProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includedProperties = null);
        void Add(T entity);

        void Delete(T entity);

        bool Any(Expression<Func<T, bool>> filter);

    }
}
