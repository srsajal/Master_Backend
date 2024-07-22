using master.DAL.Entity;
using master.DAL.IRepository;
using MasterManegmentSystem.Dto;
using System.Linq.Expressions;

namespace MasterManegmentSystem.DAL.IRepository
{
    public interface IMasterManegmentRepository : IRepository<MajorHead>
    {
        void Add<T>(T entity) where T : class;
        Task SaveChangesAsync();
        Task<bool> AnyAsync(Func<MajorHead, bool> predicate);
    }
}

