
using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.Repository;
using MasterManegmentSystem.DAL.IRepository;
using MasterManegmentSystem.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterManegmentSystem.DAL.Repository
{
    public class MasterMamegmentRepository  : Repository<MajorHead, MasterManagementDBContext>, IMasterManegmentRepository
    {
        MasterManagementDBContext _mContext;
        public MasterMamegmentRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _mContext.Set<T>().Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _mContext.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Func<MajorHead, bool> predicate)
        {
            return await Task.FromResult(_mContext.MajorHeads.Any(predicate));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _mContext.Set<T>().ToListAsync();
        }
    }
}