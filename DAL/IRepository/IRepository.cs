using master.DAL.Entity;
using master.Dto;
using System.Linq.Expressions;

namespace master.DAL.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> get();
        Task<T> GetByIdAsync<TKey>(TKey id);
        //Task<T> get(int id);
        bool add(T entity);
        bool update(T entity);
        void Detach(T entity);
        bool delete(T entity);
        void saveChangesManage();
        Task saveChangesAsync();
        Task<ICollection<TResult>> GetSelectedColumnByConditionAsync<TResult>(
            Expression<Func<T, TResult>> selectExpression,
            int pageIndex = 0,
            int pageSize = 10,
            List<FilterParameter> dynamicFilters = null,
            string orderByField = null,
            string orderByOrder = null
        );
        Task<ICollection<TResult>> GetSelectedColumnAsync<TResult>(Expression<Func<T, TResult>> selectExpression);
        int CountWithCondition(Expression<Func<T, bool>> condition, List<FilterParameter> dynamicFilters = null);
    }
}
