using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Repository
{
    public class masterDepartmentRepository : Repository<Department, MasterManagementDBContext>, ImasterDepartmentRepository
    {
        MasterManagementDBContext _dContext;
        public masterDepartmentRepository(MasterManagementDBContext context) : base(context)
        {
            _dContext = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _dContext.Set<T>().Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dContext.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Func<Department, bool> predicate)
        {
            return await Task.FromResult(_dContext.Departments.Any(predicate));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _dContext.Set<T>().ToListAsync();
        }
    }
}
