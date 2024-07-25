using master.DAL.Entity;
using master.Dto;

namespace master.DAL.IRepository
{
    public interface ImasterDepartmentRepository : IRepository<Department>
    {
        void Add<T>(T entity) where T : class;
        Task SaveChangesAsync();
        Task<bool> AnyAsync(Func<Department, bool> predicate);
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    }
}
